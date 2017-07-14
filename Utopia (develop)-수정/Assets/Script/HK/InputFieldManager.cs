using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{

    InputField field;
    int stage = 0;
    public GameObject Stage1;

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
        stage = 0;

        switch (text)
        {
            case "003":
                stage = 1;
                //Debug.Log("성공");
                //Chk_code = true;
                break;
            default:
                break;
        }
    }

    public void StageChange()
    {
        switch (stage)
        {
            case 1:
                this.gameObject.SetActive(false);
                Stage1.SetActive(true);
                break;
            default:
                break;
        }
    }
}
