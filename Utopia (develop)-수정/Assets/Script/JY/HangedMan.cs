using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangedMan : MonoBehaviour {

    // Use this for initialization
    Transform Tf;
    public bool is_Turning=false;

    public int stat=0;

	void Start ()
    {
        Tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {


    }

    public void Turning()
    {
        if(!is_Turning)
            StartCoroutine("Rot");
        return;
    }
    IEnumerator Rot()
    {
        Debug.Log("코루틴시작");

        for (int i = 0; i < 45; i++)
        {
            Tf.Rotate(0, 0, 4);
            Debug.Log("중");
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("코루틴끝");
        stat = (stat + 1) % 8;
    }
    
}
