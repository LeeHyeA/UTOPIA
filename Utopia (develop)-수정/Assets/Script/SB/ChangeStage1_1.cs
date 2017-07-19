using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeStage1_1 : MonoBehaviour {
    
    public Image Stage1Background;

    void Start ()
    {
        //맨처음 방배경 상태(맑은날)
        Stage1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaDay");
    }
	
	void Update ()
    {
		
	}

    public void ChangeBackground()
    {
        int CurtainStateTemp = GameObject.Find("WindowButton").GetComponent<RoomWindow>().Curtain_State;
        int WindowStateTemp = GameObject.Find("WindowButton").GetComponent<RoomWindow>().Window_State;

        //커튼이 열려있을때 : 2
        if (CurtainStateTemp == 2)
        {
            //if(맑은날) //2
            if (WindowStateTemp == 2)
                Stage1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaDay");
            //if(비오는날)//1
            else if (WindowStateTemp == 1)
                Stage1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaRainy");
            //if(밤) //3
            else if (WindowStateTemp == 3)
                Stage1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaNight");
        }
    }
}
