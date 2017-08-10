using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomWindow : MonoBehaviour
{
    public GameObject RainWindow;
    public GameObject CleanWindow;
    public GameObject DarkWindow;
    public GameObject CurtainClose;
    public GameObject StarPowder;
    public GameObject SpiderWeb;
    public GameObject SpiderJem;

    public Image DreamEnter;
    public Image BirdCageEmptyImage;
    public Image BirdCagePutFeed;
    public Image BirdCageFull;
    public Image SpiderImage;
    //EventManager 객체
    EventManager EventNum;

    //방안상태가 한번 변했음을 확인해주는 변수
    public bool ChangeRoomState = false;

    //커튼 상태 : 1.닫혀있음, 2.열려있음
    public int Curtain_State = 2;

    //새장이 놓였음을 확인하는 변수
    bool PutBirdcage = false;

    //새장에 모이를 놓았음을 확인하는 변수
    public bool PutFeedToBirdCage = false;

    //새장에 새가 들어오는 이벤트 발생 변수
    bool ActiveComeBirdEvent = false;

    //드림캐쳐가 놓였음을 확인하는 변수
    bool PutDreamCatcher = false;

    //창문 상태 : 1.비오는날, 2.맑은날, 3.커튼을 걷음(밤)
    public int Window_State = 2;

    //별가루를 얻음:1, 아직못얻음:2
    public int GetStarPowder = 2;

    //모이를 채운 새장을 놓음:1, 안놓은상태:2
    //public int PutBirdcage = 2;

    //맑은날 창문에 거미줄이 놓였음을 확인하는 변수
    public bool PutSpiderWeb = false;


    public void SetPutSpiderWeb()
    {
        PutSpiderWeb = true;
    }

    public void CheckPutSpiderWeb()
    {
        //비오는 날이면서 커튼이 열릴때
        if (Window_State == 1 && Curtain_State == 2)
        {
            //거미줄이 놓여있으면
            if (PutSpiderWeb)
            {
                //111번 이벤트 발생
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 111;
                //PutSpiderWeb = false;
            }
        }
    }

    public void SetPutFeedToBirdCage()
    {
        PutFeedToBirdCage = true;
    }

    public void CheckPutFeedToBirdCage()
    {
        //맑은날이면서 커튼이 열릴때
        if (Window_State == 2 && Curtain_State == 2)
        {
            //새장이 놓여있으면
            if (PutFeedToBirdCage)
            {
                //109번 이벤트 발생
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 109;
                //EventNum.EventnumberSet(108);
                //EventNum.Event_Number = 108;
                //PutFeedToBirdCage = false;
            }
        }
    }

    //거미줄을 얻음:1, 아직못얻음:2
    public int IsGetSpiderWeb = 2;

    public void Window_State_Change()
    {
        if (Curtain_State == 1)
        {
            if (Window_State >= 2)
            {
                Window_State = 1;
                Curtain_State = 2;

            }
            else
            {
                Window_State++;
                Curtain_State = 2;
            }
        }
        else if (Curtain_State == 2)
        {
            Curtain_State = 1;
        }
    }
    //깃털 얻기 이벤트
    //조건 : 맑은날, 새모이를 채운 새장을 놓음
    void BirdFeatherEvent()
    {
        if (Curtain_State == 2)
        {
            if (Window_State == 2 && PutBirdcage)
            {
                Debug.Log("새가날라오는 이벤트 발생");
            }
        }
    }

    //빗물보석 얻기 이벤트
    //조건 : 비오는날, 드림캐쳐(뼈대+거미줄상태)를 놓음
    void WaterJemEvent()
    {
        if (Curtain_State == 2)
        {
            if (Window_State == 1 && PutDreamCatcher)
            {
                Debug.Log("빗물보석 이벤트 발생");
            }
        }
    }

    void CheckStarPowderGet()
    {
        //별가루 얻음
        if (GetStarPowder == 1)
        {
            return;
            //StarPowder.SetActive(false);
        }
        //별가루 못 얻음
        else if (GetStarPowder == 2)
        {
            //커튼이 닫혀있을때 활성화
            if (Curtain_State == 1)
            {
                StarPowder.SetActive(true);
                /*
                if (Curtain_State == 1)
                    StarPowder.SetActive(true);
                else if (Curtain_State == 2)
                    StarPowder.SetActive(false);
                */
            }
            else
                StarPowder.SetActive(false);
        }
    }
    public void GetStarpowder()
    {
        GetStarPowder = 1;
    }

    /*
    bool CheckPutBirdcage()
    {
        if()
    }
    */

    void CheckGetSpiderWeb()
    {

        /*
        //거미줄 얻음
        if (IsGetSpiderWeb == 1)
            SpiderWeb.SetActive(false);
        else
            SpiderWeb.SetActive(true);
        */
        //거미줄 못 얻음
        // else if (IsGetSpiderWeb == 2)
        //     SpiderWeb.SetActive(true);
        //거미줄 못얻음
        /*
        else if (IsGetSpiderWeb == 2)
        {
            if (Curtain_State == 2)
                SpiderWeb.SetActive(true);
            else if (Curtain_State == 1)
                SpiderWeb.SetActive(false);
        }
        */
    }

    public bool IsSpiderJemEvent = false;

    public bool IsSpiderJemGet = false;

    public void setIsSpiderJemGet(bool set)
    {
        IsSpiderJemGet = set;
    }
    void CheckGetSpiderJem()
    {
        //
        if (IsSpiderJemGet)
        {
            return;
        }

        if (IsSpiderJemEvent)
        {
            if (Curtain_State == 1)
                SpiderJem.SetActive(false);
            else
                SpiderJem.SetActive(true);
        }
        /*
        //커튼이 닫혀있을때
        if (Curtain_State == 1)
        {
            //빗물보석을 얻음
            if (IsGetSpiderJem)
                SpiderJem.SetActive(false);
            else
                SpiderJem.SetActive(true);
        }
        */
    }

    public void GetSpiderWeb()
    {
        IsGetSpiderWeb = 1;
    }


    public void WindowSetActive()
    {

        switch (Window_State)
        {
            //비오는날
            case 1:
                RainWindow.SetActive(true);
                CleanWindow.SetActive(false);
                DarkWindow.SetActive(false);
                DreamEnter.color = new Color32(148, 148, 148, 255);
                BirdCageEmptyImage.color = new Color32(148, 148, 148, 255);
                SpiderImage.color = new Color32(148, 148, 148, 255);
                BirdCagePutFeed.color = new Color32(148, 148, 148, 255);
                BirdCageFull.color = new Color32(148, 148, 148, 255);
                if (!PutSpiderWeb)
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 94;
                break;
            //맑은날
            case 2:
                RainWindow.SetActive(false);
                CleanWindow.SetActive(true);
                DarkWindow.SetActive(false);
                DreamEnter.color = new Color32(255, 255, 255, 255);
                BirdCageEmptyImage.color = new Color32(255, 255, 255, 255);
                SpiderImage.color = new Color32(255, 255, 255, 255);
                BirdCagePutFeed.color = new Color32(255, 255, 255, 255);
                BirdCageFull.color = new Color32(255, 255, 255, 255);
                if (!PutFeedToBirdCage)
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 90;
                //CheckPutFeedToBirdCage();
                break;
            //밤
            /*
            case 3:
                RainWindow.SetActive(false);
                CleanWindow.SetActive(false);
                DarkWindow.SetActive(true);
                //SpiderWeb.SetActive(true);
                CheckGetSpiderWeb();
                break;
            */
            default:
                break;
        }

        switch (Curtain_State)
        {
            //커튼 닫힘
            case 1:
                CurtainClose.SetActive(true);
                RainWindow.SetActive(false);
                CleanWindow.SetActive(false);
                DreamEnter.color = new Color32(99, 99, 99, 255);
                BirdCageEmptyImage.color = new Color32(99, 99, 99, 255);
                SpiderImage.color = new Color32(99, 99, 99, 255);
                BirdCagePutFeed.color = new Color32(99, 99, 99, 255);
                BirdCageFull.color = new Color32(99, 99, 99, 255);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 92;
                //StarPowder.SetActive(true);
                break;
            //커튼 열림
            case 2:
                CurtainClose.SetActive(false);
                //StarPowder.SetActive(false);
                break;
        }
        /*
        if(Window_State == 2 && Curtain_State ==1)
        {

        }
        else if(Window_State == 2 && Curtain_State ==2)
        {

        }
        */

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // WindowSetActive();
        CheckStarPowderGet();
        CheckGetSpiderWeb();
        CheckGetSpiderJem();
    }
}
