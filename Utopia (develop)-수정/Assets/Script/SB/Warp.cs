using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public RectTransform warpTarget;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.이름 맞냐)
            other.gameObject.GetComponent<PlayerControl>().isdoor = true;
            other.gameObject.GetComponent<PlayerControl>().t = warpTarget;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<PlayerControl>().isdoor = false;
    }
    
}
