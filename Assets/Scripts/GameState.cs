using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState
{
    public BallShooter ballShooter;
    public Ball ball;
    public Block block;
    public float speed;
    public int maxBalls;
    public Vector3 ballBornPoint;
    public int blockLife;
    public bool isShooting;
    public bool posConf;

    [System.NonSerialized]
    public List<Block> blocks = new List<Block>();

    [System.NonSerialized]
    public List<Ball> balls = new List<Ball>();
}
