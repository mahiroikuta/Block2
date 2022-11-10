using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
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

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(_gameState.posConf);
        // if ( !_gameState.posConf && collision.gameObject.tag == "Floor" )
        // {
        //     _gameState.ballBornPoint = collision.gameObject.transform.position;
        //     Debug.Log(collision.gameObject.transform.position);
        //     _gameState.posConf = true;
        //     Destroy(gameObject);
        // }
        // if ( _gameState.posConf ) {
        //     Destroy(gameObject);
        // }
        if ( collision.gameObject.tag == "Floor" )
        {
            Destroy(gameObject);
        }

    }
}
