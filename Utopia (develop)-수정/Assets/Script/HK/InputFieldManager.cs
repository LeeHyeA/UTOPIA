using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{

    InputField field;
    int stage = -1;
    public GameObject Main;
    public GameObject Stage1;
    public GameObject Stage3;

    // Use this for initialization
    void Start()
    {

        GameObject inputObj = GameObject.Find("0_InputField");

        field = inputObj.GetComponent<InputField>();

        

        field.onValidateInput += delegate (string text, int charIndex, char addedChar)
        { 
            return changeUpperCase(addedChar);
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        // 이건 스위치문으로 패스워드를 가려내면 될듯!
        /*
        if (field.text == "003")
        {
            Debug.Log("성공");
        }
        */
        textCode(field.text);
    }

    char changeUpperCase(char _cha)
    {
        char tmpChar = _cha;

        string tmpString = tmpChar.ToString();

        tmpString = tmpString.ToUpper();

        tmpChar = System.Convert.ToChar(tmpString);

        return tmpChar;
    }

    void textCode(string text)
    {
        switch (text)
        {
            case "003":
                stage = 0;
                break;

            case "A001":
                if(PlayerPrefs.GetString("HeadGear", "false") == "true")
                    stage = 1;
                break;

            case "523":
                stage = 99;
                break;

            default:
                stage = -1;
                break;
        }
    }

    public void StageChange()
    {
        Transform computer = Main.transform.Find("Computer");
        switch (stage)
        {
            case 0:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("3_AccessButton").gameObject.SetActive(true);
                computer.Find("4_AccessButton(Before)").gameObject.SetActive(false);
                
                computer.Find("7_Result").transform.Find("2_AccessApproved").gameObject.SetActive(true);


                break;
            case 1:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("7_Result").transform.Find("2_AccessApproved").gameObject.SetActive(true);
                Stage1.SetActive(true);
                break;

            case 99:
                // 창끄기
				Transform BG = Stage3.transform.Find("3Round").Find("BG");
                BG.Find("Lock").gameObject.SetActive(false);
				BG.Find("ClickObject").Find("Drawer(lock)").gameObject.SetActive(false);
				BG.Find("ClickObject").Find("Drawer(open)").gameObject.SetActive(true);
                Debug.Log("물뿌리개 획득");
                break;

            default:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("7_Result").transform.Find("3_WrongPassword").gameObject.SetActive(true);
                break;
        }
    }

    public void SetStr()
    {
        GameObject inputObj = GameObject.Find("0_InputField");

        field = inputObj.GetComponent<InputField>();

        field.text = "";
    }
}
