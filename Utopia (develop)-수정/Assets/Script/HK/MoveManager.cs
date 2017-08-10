using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour {

    Transform BG;
    Transform MOVE;

    private Coroutine control;

    // Use this for initialization
    void Start () {
        BG = transform.Find("BG");
        MOVE = transform.Find("Move");
	}
	
	// Update is called once per frame
	void Update () {
    }

    IEnumerator Move(Transform thisTransform, float distance, float speed)
    {
        float startPos = thisTransform.localPosition.x;
        float endPos = startPos + distance;
        float rate = 1.0f / Mathf.Abs(distance) * speed;
        float t = 0.0f;

        Debug.Log(startPos);
        Debug.Log(endPos);
        
        while (true)
        {

            t += Time.deltaTime * rate;
            Vector3 pos = thisTransform.localPosition;
            pos.x = Mathf.Lerp(startPos, distance, t);
            thisTransform.localPosition = pos;
            
            yield return 0;

            if(distance < 0 && thisTransform.localPosition.x <= endPos)
            {
                //Debug.Log("오른쪽");
                //Debug.Log("Before: " + thisTransform.localPosition);
                thisTransform.localPosition = new Vector3(endPos, 0.0f, 0.0f);
                //Debug.Log("After: " + thisTransform.localPosition);
                MOVE.Find("Left").gameObject.SetActive(true);
                yield break;
            }

            if (distance >= 0 && thisTransform.localPosition.x >= endPos)
            {
                //Debug.Log("왼쪽");
                thisTransform.localPosition = new Vector3(endPos, 0.0f, 0.0f);
                MOVE.Find("Right").gameObject.SetActive(true);
                yield break;
            }

        }
    }

    public void RightButton()
    {
		//if(BG.localPosition.x == 1920)
        	control = StartCoroutine(Move(BG, -1920.0f, 400.0f));
    }

    public void LeftButton()
    {
        control = StartCoroutine(Move(BG, 1920.0f, 400.0f));
    }
}
