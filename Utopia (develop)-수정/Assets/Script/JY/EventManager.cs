using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using LitJson;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public SoundManager SM;
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
	public Transform Stage3;
    Transform Click;
	bool FirstSea = false;


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

    int FirstDay = 1;
    bool FirstRain = false;
    bool FirstNight = false;

    public GameObject MainStage;
    public GameObject Stage_1;
    public GameObject Stage_2;
    public GameObject Stage_3;

    //인벤토리 아이템 삭제용
    public GameObject Grid;

    // Use this for initialization
    void Start ()
    {
        SM = FindObjectOfType<SoundManager>();
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

                // 50번부터 쓸게 ㅜㅜ
                //50-
                case 50:
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/PutFeed");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 52:
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/PutSpiderWeb");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 54:
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/PutSpiderJem");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 56:
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/PutFeather");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 58:
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/PutStarPowder");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                // 90-94 1-1 방안 상태 변경시마다 대사 발생
                case 90:
                    FirstDay += 1;
                    if (FirstDay >= 2)
                    {
                        Text_Data = Resources.Load<TextAsset>("Stage1-1/Dialogue/Day");
                        Json_Data = JsonMapper.ToObject(Text_Data.text);
                        CD.LoadJSON(Json_Data);
                    }
                    break;
                case 92:
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/Dialogue/Night");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 94:
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/Dialogue/Rain");
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
                    StartCoroutine(Fadeing(true, 1.5f, false));
                    //Fade(true, 1.5f);
                    break;
                case 102:
                    Panel1_1_defalut.SetActive(false);
                    Panel1_1.SetActive(true);
                    //BirdCage.SetActive(true);
                    //Window.SetActive(true);
                    StartCoroutine(Fadeing(false, 1.5f, false));
                    break;
                case 103:
                    //1-1BGM재생
                    //SM.ChangeBGM_Fun("Stage1/Bgm/Bgm(1-1)");
                    /*
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_Number = 2;
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_ListPlay();
                    */

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
                    StartCoroutine(Fadeing(true, 1.5f, false));
                    break;
                case 107:
                    Panel1_1.SetActive(false);
                    BirdCage.SetActive(false);
                    Panel1_2_defalut.SetActive(true);
                    Window.SetActive(false);
                    StartCoroutine(Fadeing(false, 1.5f, false));
                    //1-2 BGM재생
                    SM.ChangeBGM_Fun("Stage1/Bgm/Bgm(1-2)");
                    /*
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_Number = 4;
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_ListPlay();
                    */


                    /*
                    //몽골스테이지 첫대사 발생
                    Event_Number = 115;
                    */
                    break;
                //새장에 모이를 두고난 후 창문상태가 변할때 맑은날이면 새가 들어오는 이벤트
                case 109:

                    //새지저귐 효과음 재생
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SE_Number = 11;
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SE_ListPlay();

                    inventory.SetActive(false);
                    GameObject BirdCagePutFeed = BirdCage.transform.Find("BirdCagePutFeed").gameObject;
                    BirdCagePutFeed.SetActive(false);
                    GameObject BirdCageFull = BirdCage.transform.Find("BirdCageFull").gameObject;
                    BirdCageFull.SetActive(true);
                    //대사진행
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/CompleteBirdCage");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    GameObject.Find("WindowButton").GetComponent<RoomWindow>().PutFeedToBirdCage = false;

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
                    GameObject.Find("WindowButton").GetComponent<RoomWindow>().PutSpiderWeb = false;

                    break;

                //몽골스테이지(1-2)
                //몽골 디폴트방에서 로잘린 편지 읽고 넘어가기
                case 113:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/ReadRoJalLetter");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 114:
                    StartCoroutine(Fadeing(true, 1.5f, false));
                    //Fade(true, 1.5f);
                    break;
                case 115:
                    Panel1_2_defalut.SetActive(false);
                    Panel1_2.SetActive(true);
                    StartCoroutine(Fadeing(false, 1.5f, false));
                    break;

                //몽골 되고나서 첫대사(116-117)
                case 116:
                    //1-2BGM재생
                    //GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_Number = 4;
                    //GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_ListPlay();
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/StartMongGoalStage");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                    
                //허르헉을 완성시 대사후 1-3 디폴트방으로 이동 (118-121)
                case 118:
                    inventory.SetActive(false);
                    Destroy(Grid.transform.Find("0-Knife").gameObject); //칼 삭제
                    Destroy(Grid.transform.Find("2-FullWateringCan").gameObject); //물뿌리개 삭제
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/CompleteTable");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 119:
                    StartCoroutine(Fadeing(true, 1.5f, false));
                    break;
                case 120:
                    Panel1_2.SetActive(false);
                    //1-3방 BGM재생
                    SM.ChangeBGM_Fun("Stage1/Bgm/Bgm(1-3)");
                    /*
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_Number = 11;
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_ListPlay();
                    */
                    Panel1_3_defalut.SetActive(true);
                    StartCoroutine(Fadeing(false, 1.5f, false));
                    break;

                case 122:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/Getmeat");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                case 124:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/Getmilk");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                case 126:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/GetWater");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                //(128-134) 씨앗에 물을 줬을시 이벤트대사
                case 128:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/CompleteCarrot");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                case 130:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/CompletePotato");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                case 132:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/CompleteFoxtail");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                case 134:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/CompleteBean");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                //(136-139) 강아지풀 & 콩 을 잘라냈을시 이벤트 대사
                case 136:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/CutFoxtail");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                case 138:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/CutBean");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                //(140-141) 모닥불에 돌을 놨을시 대사
                case 140:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/PutStoneTofire");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                //(142-151) 테이블에 음식 재료들 놓기
                case 142:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/PutHotStone");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 144:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/PutMeat");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 146:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/PutMilkBottle");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 148:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/PutPotato");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 150:
                    Text_Data = Resources.Load<TextAsset>("Stage1-2/EventDialogue/PutCarrot");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;




                //(1-3)
          
                
                /*
                //망치로 금시계에서 금침을 획득했을시 (154-155)
                case 154:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/GetGoldNeedle");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                */

                //맑은날 올빼미를 얻음(154-155)
                case 152:
                    //효과음재생
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SE_Number = 11;
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SE_ListPlay();
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
                
                //나무씨앗이 심어져 있는 상황에서 장미씨앗 심었을 경우(154-155)
                case 154:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/WrongRose");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                //장미가 심어져 있는 상황에서 나무씨앗을 심을경우(156-158)
                case 156:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/WrongTree");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;


                //동화책을 완성했을시
                case 160:
                    StartCoroutine(Fadeing(true, 1.5f, false));
                    break;
                case 161:
                    inventory.SetActive(false);
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/CompleteFairyTale");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    //StartCoroutine(Fadeing(true, 1.5f));
                    break;
                case 162:
                    Stage_1.SetActive(false);
                    Stage_2.SetActive(true);
                    StartCoroutine(Fadeing(false, 1.5f, false));
                    SM.ChangeBGM_Fun("Stage2/Main");    
                    break;

                case 164:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/GoldClockBroke");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 166:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/PutOwlFeed");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 168:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/PutRoseSeed");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 170:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/PutTreeSeed");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 172:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/PutGoldNeedle");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 174:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/PutOwlName");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 176:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/PutTreeName");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 178:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/PutRoseName");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;


                //1-3 디폴트방에서 대사 넘기기
                case 180:
                    Text_Data = Resources.Load<TextAsset>("Stage1-3/EventDialogue/StartFairyTale");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;
                case 181:
                    StartCoroutine(Fadeing(true, 1.5f, false));
                    break;
                case 182:
                    //패널1-3디폴트 비활성화 시킴
                    Panel1_3_defalut.SetActive(false);
                    //1-3 BGM재생
                    //GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_Number = 11;
                    //GameObject.Find("SoundManager").GetComponent<SoundManager>().BGM_ListPlay();
                    //패널1-3 활성화시킴
                    Panel1_3.SetActive(true);
                    StartCoroutine(Fadeing(false, 1.5f, false));
                    break;


                // 200~299 2Stage
                case 200:
                    StartCoroutine("WaitASecond", 1.25);               //이벤트 대기시키기 / 오른쪽 숫자가 초
                    break;
                case 201:                                               //로프획득
                    GameObject.Find("Circle_Puzzle_Control").transform.GetChild(9).gameObject.SetActive(true);
                    GameObject.Find("Circle_Puzzle_Control").transform.GetChild(9).gameObject.GetComponent<Fade>().StartFade();
                    Text_Data = Resources.Load<TextAsset>("2_Stage/Event_Script/Get_Rope");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data,false);
                    break;
                case 202:
                    StartCoroutine(WaitASecond(1.0f));
                    break;
                case 203:
                    StartCoroutine(Fadeing(true, 1.0f, true));
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
                    StartCoroutine(Fadeing(false, 1.0f, false));
                    break;
                case 207:
                    Text_Data = Resources.Load<TextAsset>("2_Stage/Event_Script/Door");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LoadJSON(Json_Data);
                    break;

                case 209:
                    StartCoroutine(Fadeing(true, 1.0f, false));
                    break;
                case 210:
                    Stage_2.SetActive(false);
                    Stage_3.SetActive(true);
                    StartCoroutine(Fadeing(false, 1.0f, false));
                    break;

                // 300~399 3Stage
                case 300:
					if (!FirstSea) 
					{
						Text_Data = Resources.Load<TextAsset>("3Stage/EventDialogue/1Round/FirstSea");
						Json_Data = JsonMapper.ToObject(Text_Data.text);
						CD.LoadJSON(Json_Data);
			
						FirstSea = true;
					}
					break;

				case 302:
					Text_Data = Resources.Load<TextAsset>("3Stage/EventDialogue/1Round/Flower");
					Json_Data = JsonMapper.ToObject(Text_Data.text);
					CD.LoadJSON(Json_Data);
					break;
				
				case 304:
					StartCoroutine(Fadeing(false, 1.5f, false));
					Stage3.Find ("1Round").gameObject.SetActive (false);
					break;

				case 305:
					Stage3.Find ("2Round").gameObject.SetActive (true);
					StartCoroutine (Fadeing (false, 1.5f, false));
					break;

				// *************************************************************************************



				case 310:
					inventory.gameObject.SetActive (false);
					Text_Data = Resources.Load<TextAsset>("3Stage/EventDialogue/2Round/FinishRound");
					Json_Data = JsonMapper.ToObject(Text_Data.text);
					CD.LoadJSON(Json_Data);
					break;

				case 311:	
					StartCoroutine(Fadeing(true, 1.5f, false));
					Stage3.Find ("2Round").gameObject.SetActive (false);
					break;

				case 312:
					Stage3.Find ("3Round").gameObject.SetActive (true);
					StartCoroutine (Fadeing (false, 1.5f, false));
					break;

				case 320:
					Text_Data = Resources.Load<TextAsset>("3Stage/EventDialogue/3Round/GetFeather");
					Json_Data = JsonMapper.ToObject(Text_Data.text);
					CD.LoadJSON(Json_Data);
					break;

				case 322:
					Text_Data = Resources.Load<TextAsset>("3Stage/EventDialogue/3Round/SleepJaguar");
					Json_Data = JsonMapper.ToObject(Text_Data.text);
					CD.LoadJSON(Json_Data);
                    break;

				case 324:
					Text_Data = Resources.Load<TextAsset>("3Stage/EventDialogue/3Round/OpenLock");
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

    IEnumerator Fadeing(bool Showing, float duration, bool isWhite)
    {

        Debug.Log("코루틴 진입");

        if (!isInTransition)
        {
            isInTransition = true;
            transition = (Showing) ? 0 : 1;
            while (isInTransition)
            {
                fadeImage_.SetActive(true);
                transition += (Showing) ? 0.01f : -0.01f;
                if(isWhite)
                    fadeImage.color = Color.Lerp(new Color(255, 255, 255, 0), Color.white, transition);
                else
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
                yield return new WaitForSeconds(0.01f* Time.deltaTime);
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
