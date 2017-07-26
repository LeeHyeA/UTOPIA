using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RButtonInput : MonoBehaviour {

    public GameObject Hint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(1))
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(CurrentTouchPosition, CurrentTouchPosition, 0.5f);

            if (touches.Length > 1)
            {
                if (touches[0].transform.name == "0-Letter")
                {
                    Hint.SetActive(true);
                    PlayerPrefs.SetInt("Hint", 1);
                }

                else if (touches[0].transform.name == "3-Menual")
                {
                    Hint.SetActive(true);
                    PlayerPrefs.SetInt("Hint", 2);
                }
            }
        }
    }

    // 감지된 마우스의 현재 입력 위치를 반환
    Vector2 CurrentTouchPosition
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
