using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager
{
    [SerializeField]
    GameObject block;

    Vector3 basePos = new Vector3 (-6f, 14f, -1f);
    
    List<GameObject> blocks = new List<GameObject>();
    
    void startSet()
    {
        // 初期ブロック生成

    }

    bool noBlockCheck()
    {
        if ( blocks.Count == 0 ) return true;
        else return false;
    }

    bool touchBlockCheck()
    {
        // ブロックが規定線を超えてるか
        if ( blocks.Count == 0 ) return true;
        else return false;
    }

    void geneBlock()
    {
        for ( int i=0 ; i<5 ; i++ ) {
            Vector3 blockBornPos = basePos;
            blockBornPos.x += 3f*i;
            var ob = GameObject.Instantiate(block, blockBornPos, Quaternion.identity) as GameObject;
            blocks.Add(ob);
        }
    }
}
