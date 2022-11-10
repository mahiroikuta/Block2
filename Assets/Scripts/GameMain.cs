using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    // BlockManager blockManager = new BlockManager();
    public BallShootManager ballShootManager;
    public BlockGeneManager blockGeneManager;
    public BallManager ballManager;
    public BlockManager blockManager;

    [SerializeField]
    public GameState _gameState;

    // void inputMouse()
    // {
    //     if ( Input.GetMouseButtonDown(0) )
    //     {
    //         Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         Vector3 shotForward = Vector3.Scale((mouseWorldPos - ballShooter.transform.position), new Vector3(1, 1, 0)).normalized;
    //         // shoot(num, vec); 球発射処理
    //     }
    // }

    void Awake()
    {
        ballShootManager.setUp(_gameState);
        blockGeneManager.setUp(_gameState);
        ballManager.setUp(_gameState);
        blockManager.setUp(_gameState);
    }
    // Start is called before the first frame update
    void Start()
    {
        blockGeneManager.initializeBlock();
    }

    // Update is called once per frame
    void Update()
    {
        ballShootManager.onUpdate();
        blockGeneManager.onUpdate();
        ballManager.onUpdate();
        blockManager.onUpdate();

        if ( !_gameState.isShooting && Input.GetMouseButtonDown(0) )
        {
            ballShootManager.shoot();
            _gameState.isShooting = true;
        }
        if ( _gameState.isShooting && _gameState.balls.Count == 0 )
        {
            // ブロック数確認
            blockManager.checkBlocks();
            // ブロック移動
            blockManager.blockMove();
            // ブロック追加
            blockGeneManager.addBlock();
            _gameState.posConf = false;
            _gameState.isShooting = false;
        }
    }
}
