using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using LitJson;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Image fadeImage;
    public GameObject fadeImage_;
    private bool isInTransition = false;
    private float transition;
    private bool isShowing;
    private float duration;

    public ControlDialogue CD;
    private TextAsset Text_Data;
    private JsonData Json_Data;

    public int Event_Number=0;
    public int Event_Number_1=1;

    public bool Doing_Event=false;

    // 현경
    public Transform Main;
    Transform Click;

    //SB꺼
    public GameObject Panel1_1_defalut;
    public GameObject Panel1_1;
    public GameObject Panel1_2_defalut;
    public GameObject Panel1_2;
    public GameObject BirdCage;
    public GameObject Window;
    public GameObject inventory;
    public GameObject SpiderJem;
    public bool MakeDreamCatcher = false;
    public GameObject Owl_Cage;
    public GameObject Panel1_3_defalut;
    public GameObject Panel1_3;




    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
   //     Fadechk();
        EventList();
    }

    void Fadechk()
    {
        if (!isInTransition)
            return;

        fadeImage_.SetActive(true);
        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);

        if (transition > 1 || transition < 0)
        {
            isInTransition = false;
            Event_Number++;
            Doing_Event = false;
            if (!isShowing)
                fadeImage_.SetActive(false);
        }
        Debug.Log("페이드중");
    }

    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }

    public void EventList()                                         //스테이지에 있을 이벤트리스트
    {
        if (Event_Number_1 == Event_Number)
        {
            return;
        }
        else
        {
            switch (Event_Number)
            {
                // 0~100 Main
                case 0:
                    //StartCoroutine(Fadeing(true, 1.5f));
                    //Text_Data = Resources.Load<TextAsset>("Main/EventDialogue/Start");                     
                    //Json_Data = JsonMapper.ToObject(Text_Data.text);
                    //CD.LoadJSON(Json_Data);
                    break;
                case 2:
                    Text_Data = Resources.Load<TextAsset>("Main/EventDialogue/StartDoor");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                case 3:
                    Main.Find("Panel(Start)").Find("Mirror").gameObject.SetActive(false);
                    Main.Find("Panel(Start)").Find("PrologueButton").gameObject.SetActive(true);
                    break;

                // ****************************************************************************

                case 5:
                    Fade(true, 1.0f);
                    break;
                case 6:
                    Fade(false, 1.5f);
                    break;
                case 7:
                    Fade(true, 1.5f);
                    break;
                case 8:
                    Fade(false, 2.0f);
                    break;
                case 9:
                    Text_Data = Resources.Load<TextAsset>("Main/EventDialogue/Main");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                case 11:
                    Click = Main.Find("Panel").Find("ClickObject");

                    Click.Find("2_Gun(After)").gameObject.SetActive(true);
                    Click.Find("5_BrainSystem(After)").gameObject.SetActive(true);

                    Click.Find("2_Gun(Before)").gameObject.SetActive(false);
                    Click.Find("5_BrainSystem(Before)").gameObject.SetActive(false);

                    Text_Data = Resources.Load<TextAsset>("Main/EventDialogue/Dead");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                // 100~199 1Stage

                //100~102 1에서 아버지편지읽고 1-1로 넘어가는 이벤트
                case 100:
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/ReadFathersLetter");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 101:
                    StartCoroutine(Fadeing(true, 1.5f));
                    //Fade(true, 1.5f);
                    break;
                case 102:
                    Panel1_1_defalut.SetActive(false);
                    Panel1_1.SetActive(true);
                    //BirdCage.SetActive(true);
                    //Window.SetActive(true);
                    StartCoroutine(Fadeing(false, 1.5f));
                    break;
                case 103:
                    //1-1 시작시 혼잣말
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/StartBrazilStage");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                //105~107 1-1에서 드림캐쳐를 완성하고 난후 x버튼으로 나오면 1-2로 넘어가는 이벤트
                case 105:
                    inventory.SetActive(false);
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/CompleteDreamCatcher");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 106:
                    StartCoroutine(Fadeing(true, 1.5f));
                    break;
                case 107:
                    Panel1_1.SetActive(false);
                    BirdCage.SetActive(false);
                    Panel1_2_defalut.SetActive(true);
                    Window.SetActive(false);
                    StartCoroutine(Fadeing(false, 1.5f));
                    //몽골스테이지 첫대사 발생
                    Event_Number = 115;
                    break;
                //새장에 모이를 두고난 후 창문상태가 변할때 맑은날이면 새가 들어오는 이벤트
                case 109:
                    inventory.SetActive(false);
                    GameObject BirdCagePutFeed = BirdCage.transform.Find("BirdCagePutFeed").gameObject;
                    BirdCagePutFeed.SetActive(false);
                    GameObject BirdCageFull = BirdCage.transform.Find("BirdCageFull").gameObject;
                    BirdCageFull.SetActive(true);
                    //대사진행
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/CompleteBirdCage");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                //거미줄로 빗물보석 얻기 이벤트    
                case 111:
                    inventory.SetActive(false);
                    Window.transform.Find("2_CleanWindow").Find("PutSpiderWeb").gameObject.SetActive(false);
                    SpiderJem.SetActive(true);
                    GameObject.Find("WindowButton").GetComponent<RoomWindow>().IsSpiderJemEvent = true;
                    /*
                    int CurtainStateTempNum = GameObject.Find("WindowButton").GetComponent<RoomWindow>().Curtain_State;
                    if(CurtainStateTempNum == 2)
                        SpiderJem.SetActive(true);
                    */
                    //대사진행
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/CompleteSpiderJem");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                //몽골스테이지(1-2)
                //몽골 디폴트방에서 로잘린 편지 읽고 넘어가기
                case 113:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/ReadRoJalLetter");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 114:
                    StartCoroutine(Fadeing(true, 1.5f));
                    //Fade(true, 1.5f);
                    break;
                case 115:
                    Panel1_2_defalut.SetActive(false);
                    Panel1_2.SetActive(true);
                    StartCoroutine(Fadeing(false, 1.5f));
                    break;

                //몽골 되고나서 첫대사(116-117)
                case 116:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/StartMongGoalStage");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                    
                //허르헉을 완성시 대사후 1-3 디폴트방으로 이동 (118-121)
                case 118:
                    inventory.SetActive(false);
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/CompleteTable");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 119:
                    StartCoroutine(Fadeing(true, 1.5f));
                    break;
                case 120:
                    Panel1_2.SetActive(false);
                    Panel1_3_defalut.SetActive(true);
                    StartCoroutine(Fadeing(false, 1.5f));
                    break;
                    

                //(1-3)
                //디폴트방에서 대사 넘기기
                case 150:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/StartFairyTale");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 151:
                    StartCoroutine(Fadeing(true, 1.5f));
                    break;
                case 152:
                    //패널1-3디폴트 비활성화 시킴
                    Panel1_3_defalut.SetActive(false);
                    //패널1-3 활성화시킴
                    Panel1_3.SetActive(true);
                    StartCoroutine(Fadeing(false, 1.5f));
                    break;

                
                /*
                //망치로 금시계에서 금침을 획득했을시 (154-155)
                case 154:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/GetGoldNeedle");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                */

                //맑은날 부엉이를 얻음(154-155)
                case 154:
                    inventory.SetActive(false);
                    GameObject OwlCageFeed = Owl_Cage.transform.Find("OwlCageFeed").gameObject;
                    OwlCageFeed.SetActive(false);
                    GameObject OwlCageFull = Owl_Cage.transform.Find("OwlCageFull").gameObject;
                    OwlCageFull.SetActive(true);
                    //대사진행
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/OwlEnterCage");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                //동화책을 완성했을시
                case 160:
                    StartCoroutine(Fadeing(true, 1.5f));
                    break;
                case 161:
                    inventory.SetActive(false);
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/CompleteFairyTale");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    //StartCoroutine(Fadeing(true, 1.5f));
                    break;
                case 162:
                    StartCoroutine(Fadeing(false, 1.5f));
                    break;


                // 200~299 2Stage
                case 200:
                    StartCoroutine("WaitASecond", 1.25);               //이벤트 대기시키기 / 오른쪽 숫자가 초
                    break;
                case 201:                                               //로프획득
                    GameObject.Find("Circle_Puzzle_Control").transform.GetChild(9).gameObject.SetActive(true);
                    Text_Data = Resources.Load<TextAsset>("2_Stage/Event_Script/Get_Rope");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data,false);
                    break;
                case 202:
                    StartCoroutine(WaitASecond(1.0f));
                    break;
                case 203:
                    StartCoroutine(Fadeing(true, 1.0f));
                    Debug.Log("문이똭!");
                    break;
                case 204:
                    StartCoroutine("WaitASecond", 1.0);
                    GameObject.Find("Ganges_river").GetComponent<GangesRiver>().Activate_Door();
                    break;
                case 205:
                    Text_Data = Resources.Load<TextAsset>("2_Stage/Event_Script/Artrium_Script");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 206:
                    StartCoroutine(Fadeing(false, 1.0f));
                    break;
                case 207:
                    Text_Data = Resources.Load<TextAsset>("2_Stage/Event_Script/Door");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;      
                default:
                    break;
            }
            Event_Number_1 = Event_Number;
        }
    }

    IEnumerator WaitASecond(float sec)                //  이벤트 대기시키기
    {
        
        Debug.Log("코루틴시작");

        yield return new WaitForSeconds(sec);

 
        Event_Number++;
        Debug.Log("코루틴끝");

    }

    IEnumerator Fadeing(bool Showing, float duration)
    {
        Debug.Log("코루틴 진입");

        if (!isInTransition)
        {
            isInTransition = true;
            transition = (Showing) ? 0 : 1;
            while (isInTransition)
            {
                fadeImage_.SetActive(true);
                transition += (Showing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
                fadeImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);

                if (transition > 1 || transition < 0)
                {
                    isInTransition = false;
                    Event_Number++;
                    Doing_Event = false;
                    if (!Showing)
                        fadeImage_.SetActive(false);
                    Debug.Log("페이드끄읕");
                    yield break;
                }
                yield return new WaitForSeconds(0.01f);
                Debug.Log("페이드중");
            }

        }
        Debug.Log("코루틴끝");
        yield break;

    }
    //이벤트숫자 받아서 변경해주는 함수
    public void EventnumberSet(int num)
    {
        //드림캐처를 완성했을시 자동으로 완성이벤트로 이동
        if (num == 105)
        {
            if (MakeDreamCatcher == true)
            {
                Event_Number = num;
                return;
            }
            else if (MakeDreamCatcher == false)
                return;
        }

        Event_Number = num;
    }


}
