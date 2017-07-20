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
    public GameObject BirdCage;
    public GameObject Window;

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

                // 200~299 2Stage
                case 200:
                    StartCoroutine("WaitASecond", 2);               //이벤트 대기시키기 / 오른쪽 숫자가 초
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

    IEnumerator WaitASecond(int sec)                //  이벤트 대기시키기
    {
        if (Doing_Event)
            yield break ;
        Debug.Log("코루틴시작");
        for(int i=0;i< sec; i++)
        {
            Debug.Log("코루틴수행중");

            yield return new WaitForSeconds(1f);
        }
        Event_Number++;
        Debug.Log("코루틴끝");

    }

    //이벤트숫자 받아서 변경해주는 함수
    public void EventnumberSet(int num)
    {
        Event_Number = num;
    }

}
