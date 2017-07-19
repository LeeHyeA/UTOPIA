using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangedMan : MonoBehaviour {

    // Use this for initialization
    Transform Tf;
	void Start ()
    {
        Tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Rot()
    {
        for (int i = 0; i < 10; i++)
        {
            if (Tf.rotation.z > 10)
            yield return new WaitForSeconds(1f);
        }
    }
}
