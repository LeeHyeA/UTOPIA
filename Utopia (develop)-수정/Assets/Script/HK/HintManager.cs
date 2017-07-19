using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{

    Transform HintSet;
    Transform Hint;
    int index = 0;
    int index_Max = 0;

    // Use this for initialization
    void Start()
    {
        HintSet = transform.Find("3_HintSet");

    }

    // Update is called once per frame
    void Update()
    {
        

        if (PlayerPrefs.GetInt("Hint", 0) > 0)
            HintCheck();

    }

    void HintCheck()
    {
        switch (PlayerPrefs.GetInt("Hint", 0))
        {
            case 1:
                Hint = HintSet.Find("0_Letter");
                Hint.gameObject.SetActive(true);
                Hint.Find("0_Text").gameObject.SetActive(true);

                index = 1;
                index_Max = Hint.childCount;
                PlayerPrefs.SetInt("Hint", 0);

                Debug.Log(index_Max.ToString());
                break;

            default:
                break;

        }
    }

    public void RightButton()
    {
        if (Hint.childCount > 0)
        {
            if (index < index_Max)
            {
                Debug.Log("index" + index.ToString());
                Hint.GetChild(index).gameObject.SetActive(false);
                index++;
                Debug.Log("index" + index.ToString());
                Hint.GetChild(index).gameObject.SetActive(true);
            }
        }
    }

    public void LeftButtom()
    {
        if (Hint.childCount > 0)
        {
            if (1 < index)
            {
                Debug.Log("index" + index.ToString());
                Hint.GetChild(index).gameObject.SetActive(false);
                index--;
                Debug.Log("index" + index.ToString());
                Hint.GetChild(index).gameObject.SetActive(true);
            }
        }
    }
}
