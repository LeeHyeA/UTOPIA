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

    public int currentIndex=0;
    public GameObject Empty;

    EventManager EM;

    bool is_event_plus = false;

    public string[] BackLog = new string[50];

    // Use this for initialization
  

    void Start()
    {
        EM = FindObjectOfType<EventManager>();
        cntForAnimate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
                        /*if (TextForAnmiate != scriptstring)
            {
                TextForAnmiate += scriptstring[cntForAnimate];
                cntForAnimate++;
                isScriptEnd = false;
            }
            else
            {
                cntForAnimate = 0;
                isScriptEnd = true;
            }*/
            if (isScriptEnd == false)                  //대사가 진행중인 상황에서
            {
                if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0))         //r키를 누르면
                {
                    StopTextAnime();
                }

            }
            else                                         //대사가 끝난 상태에서
            {
                if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0))        //r키를 누르면
                {
                    //Debug.Log("Next");
                    ChangeSettings();
                }
            }

        }
        else
            return;

    }

    public void LoadJSON(JsonData ConvertedData_of_Object, bool WaitForClick)   //객체와 상호작용할때마다 호출되는 함수 (해당 객체의 JSON을 로드함) **단순상호작용**
    {
        currentIndex = 0;

        isActive = true;

        isScriptEnd = false;

        ConvertedData = ConvertedData_of_Object;

        TextForAnmiate = "";
        Dialogue_Text.text = "";

        End_of_Line = ConvertedData["dialogues"].Count;
        Empty.SetActive(true);

        is_event_plus = false;

        ChangeSettings();
        SetChat.gameObject.SetActive(true);

    }
    public void LoadJSON(JsonData ConvertedData_of_Object)         //객체와 상호작용할때마다 호출되는 함수 (해당 객체의 JSON을 로드함)  **이벤트넘버올릴때**
    {
        currentIndex = 0;

        isActive = true;

        isScriptEnd = false;

        ConvertedData = ConvertedData_of_Object;

        TextForAnmiate = "";
        Dialogue_Text.text = "";

        End_of_Line = ConvertedData["dialogues"].Count;
        Empty.SetActive(true);

        is_event_plus = true;

        ChangeSettings();

        SetChat.gameObject.SetActive(true);

    }

    void ChangeSettings()
    {
        if (currentIndex == End_of_Line)
        {
            currentIndex = 0;
            isActive = false;

            EM.Doing_Event = false;
            Empty.SetActive(false);
            if (is_event_plus)
                EM.Event_Number++;
            SetChat.gameObject.SetActive(false);
            TextForAnmiate = "";
            Dialogue_Text.text = "";
            Name_Text.text = "";
            currentIndex = 0;
            cntForAnimate = 0;

            return;
        }
        scriptstring = ConvertedData["dialogues"][currentIndex]["script_Text"].ToString();
        Name_Text.text = ConvertedData["dialogues"][currentIndex]["character_name"].ToString();
        imagestring = ConvertedData["dialogues"][currentIndex]["standImage_Name"].ToString();

        Stand_Image.sprite = Resources.Load<Sprite>("StandImage/" + imagestring);

        isScriptEnd = false;

        StartCoroutine(TextAnimation(1f));
        currentIndex++;                              //다음대사로

    }
    void StopTextAnime()
    {
        StopAllCoroutines();
        Dialogue_Text.text = scriptstring;          //모든 대사가 한번에 표시
        isScriptEnd = true;
        cntForAnimate = 0;
    }
    IEnumerator TextAnimation(float stringspeed)
    {
        Debug.Log("진입");
        if (!isScriptEnd)
        {
            Dialogue_Text.text = "";
            while (Dialogue_Text.text != scriptstring)
            {
                Dialogue_Text.text += scriptstring[cntForAnimate];
                cntForAnimate++;
                Debug.Log("진행");

                yield return new WaitForSeconds(stringspeed * Time.deltaTime);
            }
            cntForAnimate = 0;
            isScriptEnd = true;

            Debug.Log("끝");

            yield break;
        }
        else
        {
            Debug.Log("도중뻥");

            yield break;
        }
    }
}
    