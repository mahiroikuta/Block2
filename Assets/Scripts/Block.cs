using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    int blockLife;

    string lifeText = blockLife.ToString();
    void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "Ball" )
        {
            blockLife = blockLife - 1;
            lifeText = blockLife.ToString();
        }
        if ( blockLife == 0 )
        {
            Destroy(gameObject);
        }
    }
}
