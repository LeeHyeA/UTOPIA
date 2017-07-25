using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using LitJson;
using UnityEngine.UI;

public class ControlDialogue : MonoBehaviour
{


    // private string script_text;
    //   private string character_name;
    //  private string Imagename;
    //  private Sprite currentStandImage;

    public Text Name_Text;                  //이름
    public Text Dialogue_Text;              //대사
    public Image Stand_Image;                //이미지
    public Image Panel_Image;

    public string namestring;               
    public string scriptstring;
    public string imagestring;

    public string TextForAnmiate;           //텍스트애니메이션을 위한 문자열
    public int cntForAnimate;

    public bool isScriptEnd;                //현재의 대사가 끝났는지의 여부

    public GameObject SetChat;
        
    public int End_of_Line;                 //대사의 끝

    public bool isActive;                   //대화의 실행 여부 / true이면 실행, flase이면 종료

    public JsonData ConvertedData;          //Json의 객체로, 캐릭터의 이름, 대사, 이미지의 상태 정보

    public int currentIndex;
    public GameObject Empty;

    EventManager EM;
    //ActiveDialogue AD;


    // Use this for initialization
  

    void Start()
    {
        EM = FindObjectOfType<EventManager>();
        //AD = FindObjectOfType<ActiveDialogue>();
        cntForAnimate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            SetChat.gameObject.SetActive(true);

            if (currentIndex > End_of_Line)
            {
                currentIndex = 0;
                isActive = false;
                Debug.Log("끝");

                //if(!AD.NotNum)
                //    EM.Event_Number++;

                EM.Doing_Event = false;
                Empty.SetActive(false);

                //AD.NotNum = false;
                return;
            }
            else
            {
                Dialogue_Text.text = TextForAnmiate;
                
                scriptstring = ConvertedData["dialogues"][currentIndex]["script_Text"].ToString();
                Name_Text.text = ConvertedData["dialogues"][currentIndex]["character_name"].ToString();
                imagestring = ConvertedData["dialogues"][currentIndex]["standImage_Name"].ToString();

                Stand_Image.sprite = Resources.Load<Sprite>(imagestring);
                Stand_Image.color = new Color(Stand_Image.color.r, Stand_Image.color.g, Stand_Image.color.b, 255);
                Panel_Image.color = new Color(Panel_Image.  color.r, Panel_Image.color.g, Panel_Image.color.b,Panel_Image.color.a);

            }

            if (TextForAnmiate != scriptstring)
            {
                TextForAnmiate += scriptstring[cntForAnimate];
                cntForAnimate++;
                isScriptEnd = false;

            }
            else
            {
                cntForAnimate = 0;
                isScriptEnd = true;
            }
            if (isScriptEnd == false)                  //대사가 진행중인 상황에서
            {
                if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0))         //r키를 누르면
                {
                    //Debug.Log("짠");
                    TextForAnmiate = scriptstring;          //모든 대사가 한번에 표시
                    isScriptEnd = true;
                }

            }
            else                                         //대사가 끝난 상태에서
            {
                if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0))        //r키를 누르면
                {
                    //Debug.Log("Next");
                    TextForAnmiate = "";
                    currentIndex++;                              //다음대사로
                    isScriptEnd = false;
                }
            }



        }
        else
        {
            SetChat.gameObject.SetActive(false);
            TextForAnmiate = "";
            Dialogue_Text.text = "";
            Name_Text.text = "";
            currentIndex = 0;
            cntForAnimate = 0;

        }

    }

    public void LodaJSON(JsonData ConvertedData_of_Object, bool WaitForClick, bool DestroyActivated)                                  //객체와 상호작용할때마다 호출되는 함수 (해당 객체의 JSON을 로드함)
    {
        currentIndex = 0;

        isActive = true;

        isScriptEnd = false;

        ConvertedData = ConvertedData_of_Object;

        TextForAnmiate = "";
        Dialogue_Text.text = "";

        End_of_Line = ConvertedData["dialogues"].Count - 1;
        Empty.SetActive(true);

        Debug.Log(currentIndex);
    }
    public void LodaJSON(JsonData ConvertedData_of_Object)                                  //객체와 상호작용할때마다 호출되는 함수 (해당 객체의 JSON을 로드함)
    {
        currentIndex = 0;

        isActive = true;

        isScriptEnd = false;

        ConvertedData = ConvertedData_of_Object;

        TextForAnmiate = "";
        Dialogue_Text.text = "";

        End_of_Line = ConvertedData["dialogues"].Count - 1;

        Debug.Log(currentIndex);
    }
}
    