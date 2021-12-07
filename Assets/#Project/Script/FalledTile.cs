using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalledTile : MonoBehaviour
{
    public Animator falledTileAnimator;
    public bool isFallingTile = false;
    void Start()
    {
        falledTileAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if(isFallingTile)
        {
            Debug.Log("start coroutine falledTile? ");
            StartCoroutine(DestroyTile());
            // falledTileAnimator.SetBool("isFalled",false);
            // isFallingTile= false;
        }
        // if(isFallingTile)
        // {
        //     falledTile();
        // }
    }
    public void falledTile()
    {
        // isFallingTile = true;
        falledTileAnimator.SetBool("isFalled",true);
        isFallingTile = true;
        //StartCoroutine(DestroyTile());
    }

    IEnumerator DestroyTile()
    {
        isFallingTile = false;
        //falledTileAnimator.SetBool("isFalled",false);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Debug.Log("destroy gameObject " +gameObject);
    }
}
