using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    BlockManager blockManager = new BlockManager();
    BallManager ballManager = new BallManager();
    [SerializeField]
    GameObject ballShooter;

    public enum GameState
    {
        Waiting,
        Shooting,
        Clear,
        GameOver,
    }

    GameState currentState = GameState.Waiting;

    bool isShooting;
    int count;

    void checkClear()
    {
        // ブロックが全部消えてるか
        bool isClear = blockManager.noBlockCheck();
        if ( isClear ) currentState = GameState.Clear;
    }

    void checkGameOver()
    {
        // ブロックが線の座標を超えてるか
        bool isGameOver = blockManager.touchBlockCheck();
        if ( isGameOver ) currentState = GameState.GameOver;
    }

    void inputMouse()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - ballShooter.transform.position), new Vector3(1, 1, 0)).normalized;
            // shoot(num, vec); 球発射処理
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case GameState.Shooting:
                ++count;
                if ( count%50 == 1 ) ballManager.Shooting();
                
                break;
            case GameState.Waiting:
                if ( Input.GetMouseButtonDown(0) )
                {
                    count = 0;
                    ballManager.Shooting();
                    currentState = GameState.Shooting;
                }
                checkClear();
                checkGameOver();
                break;
            case GameState.Clear:
                // CLEAR画面表示
                break;
            case GameState.GameOver:
                // GAMEOVER画面表示
                break;

        }
    }
}
