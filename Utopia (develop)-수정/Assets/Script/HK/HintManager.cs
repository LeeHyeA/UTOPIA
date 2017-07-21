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

                index = 0;
                index_Max = Hint.childCount;
                PlayerPrefs.SetString("Letter", "true");
                PlayerPrefs.SetInt("Hint", 0);

                break;

            case 2:
                Hint = HintSet.Find("1_HeadGearMenual");
                Hint.gameObject.SetActive(true);
                Hint.Find("0_Text").gameObject.SetActive(true);

                index = 0;
                index_Max = Hint.childCount;
                PlayerPrefs.SetInt("Hint", 0);
                break;

            default:
                break;

        }
    }

    public void RightButton()
    {
        if (index_Max > index + 1)
        {
            Hint.GetChild(index).gameObject.SetActive(false);
            index++;
            Hint.GetChild(index).gameObject.SetActive(true);
            
        }
    }

    public void LeftButtom()
    {
        if (1 <= index)
        {
            if (index_Max > index - 1) 
            {
                Hint.GetChild(index).gameObject.SetActive(false);
                index--;
                Hint.GetChild(index).gameObject.SetActive(true);
            }
        }
    }
}
