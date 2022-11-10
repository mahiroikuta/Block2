using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{    
    GameState _gameState;

    public void setUp(GameState gameState)
    {
        _gameState = gameState;
    }

    public GameState onUpdate()
    {
        return _gameState;
    }

    public bool checkBlocks()
    {
        return _gameState.blocks.Count==0;
    }
    // ブロック移動
    public void blockMove()
    {
        foreach ( Block block in _gameState.blocks )
        {
            Transform myTransform = block.transform;
            Vector3 pos = myTransform.position;
            pos.y += 2;
        }
    }

    // string lifeText = blockLife.ToString(); 
    void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "Ball" )
        {
            _gameState.blockLife = _gameState.blockLife - 1;
            Debug.Log("ball hit block");
            Debug.Log(_gameState.blockLife);
            // lifeText = blockLife.ToString();
        }
        if ( _gameState.blockLife == 0 )
        {
            Destroy(gameObject);
        }
    }
}
