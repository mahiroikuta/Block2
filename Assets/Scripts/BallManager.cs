using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField]
    GameObject ball;

    [SerializeField]
    GameObject ballShooter;

    List<GameObject> balls = new List<GameObject>();
    Vector3 ballBornPoint;

    [SerializeField]
    int maxBall;

    [SerializeField]
    float speed;

    bool isShooting = false;

    public void Shooting()
    {
        isShooting = true;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shotForward = Vector3.Scale((mouseWorldPos - ballShooter.transform.position), new Vector3(1, 1, 0)).normalized;
        GameObject clone = Instantiate(ball, ballShooter.transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().velocity = shotForward * speed;
        // ballShooter.Shooting(balls.Count, shotForward);
        // StartCoroutine("shoot", shotForward);
    }

    // IEnumerator shoot(Vector3 vec)
    // {
    //     foreach ( GameObject obj in balls )
    //     {
    //         Rigidbody rig = obj.GetComponent<Rigidbody>();
    //         rig.velocity = vec * speed;
    //         yield return new WaitForSeconds(0.5f);
    //     }
    // }

    // public async void Shooting()
    // {
    //     isShooting = true;
    //     Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     Vector3 shotForward = Vector3.Scale((mouseWorldPos - ballShooter.transform.position), new Vector3(1, 1, 0)).normalized;

    //     foreach ( GameObject obj in balls )
    //     {
    //         Rigidbody rig = obj.GetComponent<Rigidbody>();
    //         rig.velocity = shotForward * speed;
    //         await Task.Delay(500);
    //     }
    // }

    void ballBorn()
    {
        while ( maxBall > balls.Count )
        {
            var ob = GameObject.Instantiate(ball, ballBornPoint, Quaternion.identity) as GameObject;
            balls.Add(ob);
        }
    }
}
