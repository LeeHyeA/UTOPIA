using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWindow : MonoBehaviour
{
    public GameObject RainWindow;
    public GameObject CleanWindow;
    public GameObject DarkWindow;
    public GameObject CurtainClose;
    public GameObject StarPowder;
    public GameObject SpiderWeb;
    //커튼 상태 : 1.닫혀있음, 2.열려있음
    public int Curtain_State = 1;

    //새장이 놓였음을 확인하는 변수
    bool PutBirdcage = false;

    //드림캐쳐가 놓였음을 확인하는 변수
    bool PutDreamCatcher = false;

    //창문 상태 : 1.비오는날, 2.맑은날, 3.커튼을 걷음(밤)
    public int Window_State = 1;

    //별가루를 얻음:1, 아직못얻음:2
    public int GetStarPowder = 2;

    //모이를 채운 새장을 놓음:1, 안놓은상태:2
    //public int PutBirdcage = 2;

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
            StarPowder.SetActive(false);
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
        //거미줄 얻음
        if (IsGetSpiderWeb == 1)
            SpiderWeb.SetActive(false);
        else
            SpiderWeb.SetActive(true);
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

    public void GetSpiderWeb()
    {
        IsGetSpiderWeb = 1;
    }


    void WindowSetActive()
    {

        switch (Window_State)
        {
            //비오는날
            case 1:
                RainWindow.SetActive(true);
                CleanWindow.SetActive(false);
                DarkWindow.SetActive(false);
                break;
            //맑은날
            case 2:
                RainWindow.SetActive(false);
                CleanWindow.SetActive(true);
                DarkWindow.SetActive(false);
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
                //StarPowder.SetActive(true);
                break;
            //커튼 열림
            case 2:
                CurtainClose.SetActive(false);
                //StarPowder.SetActive(false);
                break;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //CheckGetSpiderWeb();
        WindowSetActive();
        CheckStarPowderGet();
        CheckGetSpiderWeb();
    }
}
