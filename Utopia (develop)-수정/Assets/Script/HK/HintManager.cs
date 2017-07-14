using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{

    public Transform HintSet;
    int index;

    // Use this for initialization
    void Start()
    {
        //HintSet = gameObject.transform.Find("4_HintSet");

        if (PlayerPrefs.GetInt("Pamphlet", 0) > 0)
            index = 2;
        if (PlayerPrefs.GetInt("Memo", 0) > 0)
            index = 1;


    }

    // Update is called once per frame
    void Update()
    {
        //IndexCheck(index);
        Debug.Log("index" + index.ToString());
    }

    public void IndexCheck()
    {
        switch (index)
        {
            case 1:
                if (PlayerPrefs.GetInt("Memo", 0) > 0)
                {
                    HintSet.Find("0_Memo").gameObject.SetActive(true);
                    HintSet.Find("1_Pamphlet").gameObject.SetActive(false);
                }
                break;

            case 2:
                if (PlayerPrefs.GetInt("Pamphlet", 0) > 0)
                {
                    HintSet.Find("0_Memo").gameObject.SetActive(false);
                    HintSet.Find("1_Pamphlet").gameObject.SetActive(true);
                }
                break;

            default:
                HintSet.Find("0_Memo").gameObject.SetActive(false);
                HintSet.Find("1_Pamphlet").gameObject.SetActive(false);
                break;

        }
    }

    public void PlusIndex(int i)
    {
        index += i;

        if (index >= 2)
            index = 2;

        if (index <= 1)
            index = 1;

        IndexCheck();
    }

    public void SetIndex(int i)
    {
        index = i;

        IndexCheck();
    }

    public void rightButton()
    {
        if (PlayerPrefs.GetInt("Pamphlet", 0) > 0)
        {
            HintSet.Find("0_Memo").gameObject.SetActive(false);
            HintSet.Find("1_Pamphlet").gameObject.SetActive(true);
        }
    }

    public void leftButtom()
    {
        if (PlayerPrefs.GetInt("Memo", 0) > 0)
        {
            HintSet.Find("0_Memo").gameObject.SetActive(true);
            HintSet.Find("1_Pamphlet").gameObject.SetActive(false);
        }
    }
}
