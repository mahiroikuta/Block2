using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    int shootNum;

    // public void Shooting(int ballsCount, Vector3 vec)
    // {
    //     shootNum = ballsCount;
    //     StartCoroutine("shoot", vec);
    // }

    // IEnumerator shoot(Vector3 vec)
    // {
    //     for ( int i=0 ; i<shootNum ; i++ )
    //     {
    //         Rigidbody rig = obj.GetComponent<Rigidbody>();
    //         rig.velocity = vec * speed;
    //         yield return new WaitForSeconds(0.5f);
    //     }
    // }
}
