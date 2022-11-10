using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int life;

    public Block()
    {
        life = 3;
    }
    void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "Ball" )
        {
            this.life = this.life - 1;
            Debug.Log("ball hit block");
            // lifeText = blockLife.ToString();
        }
        if ( this.life == 0 )
        {
            Destroy(gameObject);
        }
    }
}
