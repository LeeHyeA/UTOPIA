using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    // 현재 활성화 중인 자식 UI
    GameObject UIView;


    void Update()
    {

         InputEsc();

         InputUIkey();
    }

    void InputEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            if (ChkChildActive())
            {
                UIView.SetActive(false);
                return;
            }

            if (!gameObject.transform.Find("1_Menu").gameObject.activeSelf)
            {
                gameObject.transform.Find("1_Menu").gameObject.SetActive(true);
                gameObject.transform.Find("1_Menu").GetComponent<AudioSource>().Play();
                return;
            }
            else
                gameObject.transform.Find("1_Menu").gameObject.SetActive(false);


        }
    }

    void InputUIkey()
    {


        if (Input.GetKey(KeyCode.I) == true && !gameObject.transform.Find("2_Inventory").gameObject.activeSelf)
        {
            gameObject.transform.Find("2_Inventory").gameObject.SetActive(true);
            gameObject.transform.Find("2_Inventory").GetComponent<AudioSource>().Play();
        }

        if (Input.GetKey(KeyCode.K) == true && !gameObject.transform.Find("3_Hint").gameObject.activeSelf)
        {
            gameObject.transform.Find("3_Hint").gameObject.SetActive(true);
            gameObject.transform.Find("3_Hint").GetComponent<AudioSource>().Play();
        }

        if (Input.GetKey(KeyCode.U) == true && !gameObject.transform.Find("5_BrainSystem").gameObject.activeSelf)
        {
            gameObject.transform.Find("5_BrainSystem").gameObject.SetActive(true);
            gameObject.transform.Find("5_BrainSystem").GetComponent<AudioSource>().Play();
        }

        if (Input.GetKey(KeyCode.M) == true && !gameObject.transform.Find("6_GPS").gameObject.activeSelf
            && PlayerPrefs.GetInt("GPS", 0) > 0)
        {
            gameObject.transform.Find("6_GPS").gameObject.SetActive(true);
            gameObject.transform.Find("6_GPS").GetComponent<AudioSource>().Play();
        }

        /*
        // 인식이 느린느낌
        //var key = Input.inputString;

        //switch (key)
        //{
        //    case "ㅑ":
        //    case "I":
        //    case "i":
        //        if (!gameObject.transform.Find("3_Inventory").gameObject.activeSelf)
        //            gameObject.transform.Find("3_Inventory").gameObject.SetActive(true);
        //        break;

        //    case "ㅗ":
        //    case "H":
        //    case "h":
        //        if (!gameObject.transform.Find("4_Hint").gameObject.activeSelf)
        //            gameObject.transform.Find("4_Hint").gameObject.SetActive(true);
        //        break;

        //    case "ㅕ":
        //    case "U":
        //    case "u":
        //        if (!gameObject.transform.Find("6_BrainSystem").gameObject.activeSelf)
        //            gameObject.transform.Find("6_BrainSystem").gameObject.SetActive(true);
        //        break;

        //    case "ㅡ":
        //    case "M":
        //    case "m":
        //        if (!gameObject.transform.Find("7_GPS").gameObject.activeSelf)
        //            gameObject.transform.Find("7_GPS").gameObject.SetActive(true);
        //        break;
        //}
        */


    }

    bool ChkChildActive()
    {
        if (gameObject.transform.childCount > 0)
        {
            for (int i = 2; i < gameObject.transform.childCount-1; i++)
            {
                if (gameObject.transform.GetChild(i).gameObject.activeSelf)
                {
                    UIView = gameObject.transform.GetChild(i).gameObject;
                    return true;
                }
            }
        }

        return false;
    }

    public void TitleLoad()
    {      
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

}
