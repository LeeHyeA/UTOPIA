using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    public SoundManager SM;
    InputField field;
    int stage = -1;
    public GameObject Main;
    public GameObject Stage1;
	public GameObject Stage2;
    public GameObject Stage3;
	public Item item;
    public GameObject UIobj;

    // Use this for initialization
    void Start()
    {
        SoundManager SM = FindObjectOfType<SoundManager>();

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
                SM.ChangeBGM_Fun("Stage1/Bgm/Bgm(1-1)");
                break;

			case "A002":
				stage = 2;
                SM.ChangeBGM_Fun("Stage1/Bgm/Bgm(1-2)");
                break;
		
			case "A003":
				stage = 3;
                SM.ChangeBGM_Fun("Stage1/Bgm/Bgm(1-3)");
                break;
		

            case "5132":
                stage = 99;
                break;

            // ************************************** 치트키

            case "1-1":
                stage = 40;
                SM.ChangeBGM_Fun("Stage1/Bgm/Bgm(1-1)");
                break;

            case "1-2":
                stage = 41;
                SM.ChangeBGM_Fun("Stage1/Bgm/Bgm(1-2)");

                break;

            case "1-3":
                stage = 42;
                SM.ChangeBGM_Fun("Stage1/Bgm/Bgm(1-3)");
                break;

            case "2-0":
                stage = 43;
                SM.ChangeBGM_Fun("Stage2/Main");
                break;

            case "3-1":
                stage = 44;
                SM.ChangeBGM_Fun("Stage3/1Round/3-1 BGM");
                break;

            case "3-2":
                stage = 45;
                SM.ChangeBGM_Fun("Stage3/2Round/3-2 BGM");
                break;

            case "3-3":
                stage = 46;
                SM.ChangeBGM_Fun("Stage3/3Round/3-3 BGM");
                break;

            // **************************************************************

            default:
                stage = -1;
                break;
        }
    }

    public void StageChange()
    {

        
        Transform computer = Main.transform.Find("Panel").Find("Computer");
        switch (stage)
        {
            case 0:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("3_AccessButton").gameObject.SetActive(true);
                computer.Find("4_AccessButton(Before)").gameObject.SetActive(false);
                
                computer.Find("5_Result").transform.Find("2_AccessApproved").gameObject.SetActive(true);


                break;
			// main -> 1stage
            case 1:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("5_Result").transform.Find("2_AccessApproved").gameObject.SetActive(true);
                Main.SetActive(false);
                Stage1.SetActive(true);
                item.DeleteInventory();
                break;
		
			// main -> 2stage
			case 2:
				this.gameObject.SetActive (false);
				field.text = "";
			
				computer.Find ("5_Result").transform.Find ("2_AccessApproved").gameObject.SetActive (true);
				Main.SetActive (false);
				Stage2.SetActive(true);
                item.DeleteInventory();
                break;

			// main -> 3stage
			case 3:
				this.gameObject.SetActive (false);
				field.text = "";
			
				computer.Find ("5_Result").transform.Find ("2_AccessApproved").gameObject.SetActive (true);
				Main.SetActive (false);
				Stage3.SetActive(true);
                item.DeleteInventory();

                GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_Number = 301;
                GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_ListPlay();
                break;


            // *********************************************** 새로운 치트키

            // 1-1
            case 40:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("5_Result").transform.Find("2_AccessApproved").gameObject.SetActive(true);

                Main.SetActive(false);
                Stage1.SetActive(true);
                Stage2.SetActive(false);
                Stage3.SetActive(false);

                Stage1.transform.Find("Panel(Defalut1-1)").gameObject.SetActive(true);
                Stage1.transform.Find("Panel(Defalut1-2)").gameObject.SetActive(false);
                Stage1.transform.Find("Panel(Defalut1-3)").gameObject.SetActive(false);
                item.DeleteInventory();

                UIobj.SetActive(true);
                break;
            
            // 1-2
            case 41:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("5_Result").transform.Find("2_AccessApproved").gameObject.SetActive(true);

                Main.SetActive(false);
                Stage1.SetActive(true);
                Stage2.SetActive(false);
                Stage3.SetActive(false);

                Stage1.transform.Find("Panel(Defalut1-1)").gameObject.SetActive(false);
                Stage1.transform.Find("Panel(Defalut1-2)").gameObject.SetActive(true);
                Stage1.transform.Find("Panel(Defalut1-3)").gameObject.SetActive(false);
                item.DeleteInventory();

                UIobj.SetActive(true);
                break;

            // 1-3
            case 42:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("5_Result").transform.Find("2_AccessApproved").gameObject.SetActive(true);

                Main.SetActive(false);
                Stage1.SetActive(true);
                Stage2.SetActive(false);
                Stage3.SetActive(false);

                Stage1.transform.Find("Panel(Defalut1-1)").gameObject.SetActive(false);
                Stage1.transform.Find("Panel(Defalut1-2)").gameObject.SetActive(false);
                Stage1.transform.Find("Panel(Defalut1-3)").gameObject.SetActive(true);
                item.DeleteInventory();

                UIobj.SetActive(true);
                break;

            // 2
            case 43:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("5_Result").transform.Find("2_AccessApproved").gameObject.SetActive(true);

                Main.SetActive(false);
                Stage1.SetActive(false);
                Stage2.SetActive(true);
                Stage3.SetActive(false);

                item.DeleteInventory();

                UIobj.SetActive(true);
                break;

            // 3-1
            case 44:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("5_Result").transform.Find("2_AccessApproved").gameObject.SetActive(true);

                Main.SetActive(false);
                Stage1.SetActive(false);
                Stage2.SetActive(false);
                Stage3.SetActive(true);

                Stage3.transform.Find("1Round").gameObject.SetActive(true);
                Stage3.transform.Find("2Round").gameObject.SetActive(false);
                Stage3.transform.Find("3Round").gameObject.SetActive(false);
                item.DeleteInventory();

                UIobj.SetActive(true);
                break;

            // 3-2
            case 45:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("5_Result").transform.Find("2_AccessApproved").gameObject.SetActive(true);

                Main.SetActive(false);
                Stage1.SetActive(false);
                Stage2.SetActive(false);
                Stage3.SetActive(true);

                Stage3.transform.Find("1Round").gameObject.SetActive(false);
                Stage3.transform.Find("2Round").gameObject.SetActive(true);
                Stage3.transform.Find("3Round").gameObject.SetActive(false);
                item.DeleteInventory();

                UIobj.SetActive(true);
                break;

            // 3-3
            case 46:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("5_Result").transform.Find("2_AccessApproved").gameObject.SetActive(true);

                Main.SetActive(false);
                Stage1.SetActive(false);
                Stage2.SetActive(false);
                Stage3.SetActive(true);

                Stage3.transform.Find("1Round").gameObject.SetActive(false);
                Stage3.transform.Find("2Round").gameObject.SetActive(false);
                Stage3.transform.Find("3Round").gameObject.SetActive(true);
                item.DeleteInventory();

                UIobj.SetActive(true);
                break;

            // **************************************************************

            case 99:
                // 창끄기
				Transform BG = Stage3.transform.Find ("3Round").Find ("BG");
				BG.Find ("Lock").gameObject.SetActive (false);
				BG.Find ("ClickObject").Find ("Drawer(lock)").gameObject.SetActive (false);
				GameObject.Find ("Event_Manager").GetComponent<EventManager> ().EventnumberSet (324);
				item.GetNumber (12);
				item.LoadJson ("3Stage");
				item.GetNumber (13);
				item.LoadJson ("3Stage");

                GameObject.Find("SoundManager").GetComponent<SoundManager>().SE_Number = 324;
                GameObject.Find("SoundManager").GetComponent<SoundManager>().SE_ListPlay();
                break;

            default:
                this.gameObject.SetActive(false);
                field.text = "";

                computer.Find("5_Result").transform.Find("3_WrongPassword").gameObject.SetActive(true);
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
