using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzleTile : MonoBehaviour {

    SlidePuzzle SP;
    Transform Tf;
    public int Hor;    //가로
    public int Ver;    //세로

    int direction; // 왼 - 위 - 오 - 아 : 0 - 1 - 2 - 3
    public bool is_blank = false;

    // Use this for initialization
    void Start()
    {
        SP = FindObjectOfType<SlidePuzzle>();
        Tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        Debug.Log(Ver);
        Debug.Log(Hor);
        SP.CheckDirection(this);
        return;
    }

    public void triggerMoving(int dir)
    {
        direction = dir;
        StartCoroutine(moving(direction));
    }

    IEnumerator moving(int direction)
    {
        int i = 0;
        switch(direction)
        {
            case 0:
                for (i = 0; i < 190; i++)
                {
                    Vector3 Vec = gameObject.transform.localPosition;
                    Vec.x = Vec.x - 1f;
                    gameObject.transform.localPosition = Vec;
                    Debug.Log(i);
                    yield return new WaitForSeconds(0.1f);
                }
                break;
            case 1:
                for (i = 0; i < 103; i++)
                {
                    Vector3 Vec = gameObject.transform.localPosition;
                    Vec.y = Vec.y + 1f;
                    gameObject.transform.localPosition = Vec;

                    Debug.Log(i);

                    yield return new WaitForSeconds(0.01f);
                }
                break;
            case 2:
                for (i = 0; i < 190; i++)
                {
                    Vector3 Vec = gameObject.transform.localPosition;
                    Vec.x = Vec.x + 1f;

                    Debug.Log(Vec.x-gameObject.transform.position.x);

                    gameObject.transform.localPosition = Vec;

                    yield return new WaitForSeconds(0.01f);
                }
                break;
            case 3:
                for (i = 0; i < 103; i++)
                {
                    Vector3 Vec = gameObject.transform.localPosition;
                    Vec.y = Vec.y - 1f;
                    gameObject.transform.localPosition = Vec;
                    Debug.Log(i);

                    yield return new WaitForSeconds(0.01f);
                }
                break;
        }

        yield break;
    }
}