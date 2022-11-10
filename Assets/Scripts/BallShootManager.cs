using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShootManager : MonoBehaviour
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

    public void initializePos()
    {
        BallShooter ballshooter = BallShooter.Instantiate(_gameState.ballShooter, _gameState.ballBornPoint, Quaternion.identity) as BallShooter;
    }
    // ballShooter再配置
    public void reposition()
    {
            Transform myTransform = _gameState.ballShooter.transform;
            Vector3 pos = myTransform.position;
    }

    // 発射
    public void shoot()
    {
        ballGene();
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 40;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;
        StartCoroutine("shooting", shotForward);
        Destroy(_gameState.ballShooter.gameObject);
    }

    IEnumerator shooting(Vector3 vec)
    {
        foreach ( Ball ball in _gameState.balls )
        {
            Rigidbody rig = ball.GetComponent<Rigidbody>();
            rig.velocity = vec * _gameState.speed;
            yield return new WaitForSeconds(0.2f);
        }
    }

    // 球生成
    void ballGene()
    {
        while ( _gameState.maxBalls > _gameState.balls.Count )
        {
            Ball ball = Ball.Instantiate(_gameState.ball, transform.position, Quaternion.identity) as Ball;
            _gameState.balls.Add(ball);
        }
    }
}
