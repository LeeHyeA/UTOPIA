﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using LitJson;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Image fadeImage;
    public GameObject fadeImage_;
    private bool isInTransition;
    private float transition;
    private bool isShowing;
    private float duration;

    public ControlDialogue CD;
    private TextAsset Text_Data;
    private JsonData Json_Data;

    public int Event_Number=0;
    public int Event_Number_1=1;

    public bool Doing_Event=false;

    //SB꺼
    public GameObject Panel1_1_defalut;
    public GameObject Panel1_1;
    public GameObject Panel1_2;
    public GameObject BirdCage;
    public GameObject Window;
    public GameObject inventory;
    public bool MakeDreamCatcher = false;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
        Fadechk();
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
                    
                // 100~199 1Stage
                //100~102 1에서 아버지편지읽고 1-1로 넘어가는 이벤트
                case 100:
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/ReadFathersLetter");                     //예시
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LodaJSON(Json_Data);
                    break;
                case 101:
                    Fade(true, 1.5f);
                    break;
                case 102:
                    Panel1_1_defalut.SetActive(false);
                    Panel1_1.SetActive(true);
                    BirdCage.SetActive(true);
                    Window.SetActive(true);
                    Fade(false, 1.5f);
                    break;
                //104~106 1-1에서 드림캐쳐를 완성하고 난후 x버튼으로 나오면 1-2로 넘어가는 이벤트
                case 104:
                    inventory.SetActive(false);
                    Text_Data = Resources.Load<TextAsset>("Stage1-1/EventDialogue/CompleteDreamCatcher");                     //예시
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LodaJSON(Json_Data);
                    break;
                case 105:
                    Fade(true, 1.5f);
                    break;
                case 106:
                    Panel1_1.SetActive(false);
                    BirdCage.SetActive(false);
                    Panel1_2.SetActive(true);
                    Window.SetActive(false);
                    Fade(false, 1.5f);
                    break;

                // 200~299 2Stage
                case 200:
                    StartCoroutine("WaitASecond", 1.25);               //이벤트 대기시키기 / 오른쪽 숫자가 초
                    break;
                case 201:
                    Text_Data = Resources.Load<TextAsset>("2_Stage/Event_Script/Get_Rope");
                    Json_Data = JsonMapper.ToObject(Text_Data.text);
                    CD.LodaJSON(Json_Data);
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

    //이벤트숫자 받아서 변경해주는 함수
    public void EventnumberSet(int num)
    {
        //드림캐처를 완성했을시 자동으로 완성이벤트로 이동
        if (num == 104)
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
