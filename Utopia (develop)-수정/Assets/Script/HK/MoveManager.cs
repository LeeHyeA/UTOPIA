using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour {

    Transform BG;

    private IEnumerator coroutine;
    private Coroutine control;

    // Use this for initialization
    void Start () {
        BG = transform.Find("BG");
	}
	
	// Update is called once per frame
	void Update () {
        if (BG.position.x <= -480.0f || BG.position.x >= 480.0f)
        {
            StopCoroutine(control);
        }
    }

    IEnumerator Move(Transform thisTransform, float distance, float speed)
    {
        float startPos = thisTransform.position.x;
        float endPos = startPos + distance;
        float rate = 1.0f / Mathf.Abs(distance) * speed;
        float t = 0.0f;

        while(t < 0.01247f)
        {
            t += Time.deltaTime * rate;
            Vector3 pos = thisTransform.position;
            pos.x = Mathf.Lerp(startPos, distance, t);
            thisTransform.position = pos;
            yield return 0;
            Debug.Log(t.ToString());
            
        }
    }

    public void RightButton()
    {
        //if(BG.position.x >= 480.0f)
        //StartCoroutine(Move(BG, -480.0f, 1.0f));

        control = StartCoroutine(Move(BG, -480.0f, 1.5f));
        coroutine = Move(BG, -480.0f, 1.5f);
        StartCoroutine(coroutine);
    }

    public void LeftButton()
    {
        //if (BG.position.x <= -480.0f)
        coroutine = Move(BG, 480.0f, 1.0f);
        StartCoroutine(coroutine);
    }
}
