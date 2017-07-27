using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeStage1_1 : MonoBehaviour
{


    public Image Stage1_1Background;
    public Image Stage1_2Background;
    public Image Stage1_1WindowPanel;
    //public Image FlowerPotState;

    void Start()
    {
        //맨처음 방배경 상태(밤)
        Stage1_1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaNight");
        //맨처음 커튼패널 상태(투명)
        Stage1_1WindowPanel.sprite = Resources.Load<Sprite>("Stage1-1/Window/NothingImage");

        Stage1_2Background.sprite = Resources.Load<Sprite>("Stage1-2/MonggoalDefault");

        //맨처음 화분상태(아무것도 안심음)
        //FlowerPotState.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/FlowerPot");

    }

    void Update()
    {
        //ChangeFlowerPotState();
    }

    /*
    public void ChangeFlowerPotState()
    {
        //당근(토끼)
        bool PotRabbitTemp = GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlantCarrot;
        if(PotRabbitTemp)
        {
            FlowerPotState.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/PotRabbit");
            return;
        }
        //감자(돼지)
        bool PotPigTemp = GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlantPotato;
        if(PotPigTemp)
        {
            FlowerPotState.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/PotPig");
            return;
        }
        //콩(새)
        bool PotBirdTemp = GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlantBean;
        if(PotBirdTemp)
        {
            FlowerPotState.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/PotBird");
            return;
        }
        //강아지풀(강아지)
        bool PotDogTemp = GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlantFoxtail;
        if(PotDogTemp)
        {
            FlowerPotState.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/PotDog");
            return;
        }
        //아무상것도 안심어져있으면 
        FlowerPotState.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/FlowerPot");
    }
    */

    public void ChangeBackground()
    {
        int CurtainStateTemp = GameObject.Find("WindowButton").GetComponent<RoomWindow>().Curtain_State;
        int WindowStateTemp = GameObject.Find("WindowButton").GetComponent<RoomWindow>().Window_State;

        //커튼이 열려있을때 : 2
        if (CurtainStateTemp == 2)
        {
            //if(맑은날) //2
            if (WindowStateTemp == 2)
            {
                Stage1_1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaDay");
                Stage1_1WindowPanel.sprite = Resources.Load<Sprite>("Stage1-1/Window/CurtainOpen");
                //Stage1_2Background.sprite = Resources.Load<Sprite>("Stage1-2/1_MonggoalDay");
            }
            //if(비오는날)//1
            else if (WindowStateTemp == 1)
            {
                Stage1_1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaRainy");
                Stage1_1WindowPanel.sprite = Resources.Load<Sprite>("Stage1-1/Window/CurtainOpenRainy");
                //Stage1_2Background.sprite = Resources.Load<Sprite>("Stage1-2/1_MonggoalRainy");
            }
            /*
            //if(밤) //3
            else if (WindowStateTemp == 3)
            {
                Stage1_1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaNight");
                Stage1_2Background.sprite = Resources.Load<Sprite>("Stage1-2/1_MonggoalRosaNight");
            }
            */
        }
        else if (CurtainStateTemp == 1)
        {
            Stage1_1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaNight");
            Stage1_1WindowPanel.sprite = Resources.Load<Sprite>("Stage1-1/Window/NothingImage");
            //Stage1_2Background.sprite = Resources.Load<Sprite>("Stage1-2/1_MonggoalRosaNight");
        }
    }
}
