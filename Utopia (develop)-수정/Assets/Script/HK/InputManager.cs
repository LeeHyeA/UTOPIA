﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;


public class InputManager : MonoBehaviour
{
    private bool draggingItem = false;          // 드래그되었는지 유무
    private GameObject draggedObject;           // 드래그되고있는 객체의 참조를 보관,유지
    private Vector2 touchOffset;                // 잡고난 후 플레이어의 터치위치
    public Transform UICanvas;
    public Transform MainStage;
    public GameObject BridCage;
    public GameObject AcquirableItem;
    public GameObject DreamCatcher;
    //   public AudioSource audioSource;

    GameObject HeadGear;
    GameObject Inventory;
    //Transform Grid;

    void Start()
    {
        HeadGear = MainStage.Find("HeadGear").gameObject;
        Inventory = UICanvas.Find("2_Inventory").gameObject;
    }

    void Update()
    {
        // 입력이 있다면, 이동
        if (HasInput)
        {
            DragOrPickUp();
        }

        // 입력이 없다면 객체 삭제
        else
        {
            if (draggingItem)
            {
                DropItem();
                RayCollision();
            }
        }

        
    }


    // 감지된 마우스의 현재 입력 위치를 반환
    Vector2 CurrentTouchPosition
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }


    // 항목을 드래그하는 경우 입력과 함께 사용
    // 드래그가 되지 않으면 터치된 오브젝트를 선택
    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;

        // 객체가 이미 선택되어 있다면 해당 개체는 입력 위치로 이동
        if (draggingItem)
        {
            draggedObject.transform.position = inputPosition + touchOffset;
        }

        // 객체가 선택되지 않은 경우, Raycast를 사용하여 객체를 draggedObject 변수에 저장하고,
        // draggingItem 변수를 true로 설정하여 객체를 선택하는지 여부를 확인
        else
        {
            // Raycast를 이용해 마우스 아래 객체 충돌 감지
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            Transform CheckTag = Physics2D.Raycast(inputPosition, inputPosition, 0.5f).transform;

            if (touches.Length > 0)
            {
                var hit = touches[0];
                //audioSource = hit.transform.GetComponent<AudioSource>();


                if (hit.transform != null && CheckTag.tag == "Item")
                {
                    hit.transform.SetParent(Inventory.transform);
                    ///hit.transform.GetComponent<AudioSource>().Play();
                    draggingItem = true;
                    draggedObject = hit.transform.gameObject;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;          // 처음위치에 상대적으로 움직임
                    draggedObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);     // 드래그 중일때 오브젝트 확대
                }
            }
        }
    }

    // 플레이어가 현재 마우스를 누를 때 true를 반환
    private bool HasInput
    {
        get
        {
            // 마우스 버튼이 눌려 있거나 적어도 하나의 터치가 화면에 있다면 true를 반환
            return Input.GetMouseButton(0);
        }
    }



    // 가져온 항목을 해제
    void DropItem()
    {
        draggingItem = false;
        draggedObject.transform.localScale = new Vector3(1, 1, 1);         // 드래그가 끝났으니 원래대로 스케일 변경
    }

    // 스테이지마다 구분 필요할 듯 (if가 너무 많아짐)
    void RayCollision()
    {

        RaycastHit2D[] touches = Physics2D.RaycastAll(CurrentTouchPosition, CurrentTouchPosition, 0.5f);

        if (touches.Length > 1)
        {
            var obj = touches[0];
            var hit = touches[1];

            // Example
            //if (obj.transform.name == "" && hit.transform.name == "")
            //{
            //    Destroy(obj.transform.gameObject);
            //}

            // Main
            if (obj.transform.name == "2-HeadGear" && hit.transform.name == "HeadGearCollision")
            {
                HeadGear.SetActive(true);
                Destroy(obj.transform.gameObject);
            }

            if (obj.transform.name == "4-SmallCable1" && hit.transform.name == "2_SmallCode")
            {
                HeadGear.transform.Find("4_SmallCable").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject); 
            }

            if (obj.transform.name == "5-BigCable2" && hit.transform.name == "3_BigCode")
            {
                HeadGear.transform.Find("5_BigCable").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }

            if (obj.transform.name == "6-FinishHeadGear" && hit.transform.name == "HeadGearCollision")
            {                
                MainStage.Find("Computer").gameObject.SetActive(true);
                Transform Com = MainStage.Find("Computer");
                Com.Find("9_CodeInput").gameObject.SetActive(true);
                Com.Find("5_AccessButton(NoHG)").gameObject.SetActive(false);
                Com.Find("4_AccessButton(Before)").gameObject.SetActive(true);

                if (Inventory.gameObject.activeSelf)
                    Inventory.gameObject.SetActive(false);

                Destroy(obj.transform.gameObject);
            }



            // 1 Stage(1-1)
            //모이를 빈새장으로
            if (obj.transform.name == "4-1_1BirdFeed" && hit.transform.name == "BirdCageEmptyCol")
            {
                BridCage.transform.Find("BirdCageEmpty").gameObject.SetActive(false);
                BridCage.transform.Find("BirdCagePutFeed").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }
            
            //모이가 들어있는 새장을 맑은날창문으로
            if (obj.transform.name == "5-1_1BirdCagePutFeed" && hit.transform.name == "2_CleanWindow")
            {
                BridCage.transform.Find("BirdCageFull").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }
            //거미줄을 비오는날 창문으로
            if(obj.transform.name == "2-1_1SpiderWeb" && hit.transform.name == "1_RainWindow")
            {
                Debug.Log("거미줄 비오는날 창문에 접촉");
                AcquirableItem.transform.Find("SpiderJem").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }
            //DreamCatcher(SpiderJem)
            if (obj.transform.name == "7-1_1SpiderJem" && hit.transform.name == "DreamCatcherCol")
            {
                int tempNum = GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState;
                //기본(0)상태에서 거미줄보석 붙일때
                if (tempNum == 0)
                {
                    Debug.Log("거미줄+보석완성을 드림캐쳐 기본 상태에 붙임");
                    //상태를 기본+거미줄보석(2)로 바꿈
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState = 2;
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().ShowDreamCatcher();
                    Destroy(obj.transform.gameObject);
                }
                //기본+깃털상태(1)에서 거미줄보석 붙일때
                else if (tempNum == 1)
                {
                    Debug.Log("거미줄+보석완성을 드림캐쳐 기본+깃털 상태에 붙임");
                    //상태를 기본+깃털+거미줄보석(3)로 바꿈
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState = 3;
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().ShowDreamCatcher();
                    Destroy(obj.transform.gameObject);
                }
            }
            //DreamCatcher(Feather)
            if (obj.transform.name == "6-1_1Feather" && hit.transform.name == "DreamCatcherCol")
            {
                int tempNum2 = GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState;
                //기본(0)상태에서 깃털 붙일때
                if (tempNum2 == 0)
                {
                    Debug.Log("깃털을 드림캐쳐 기본 상태에 붙임");
                    //상태를 기본+깃털(1)로 바꿈
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState = 1;
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().ShowDreamCatcher();
                    Destroy(obj.transform.gameObject);
                }
                //기본+거미줄보석(2)상태에서 깃털 붙일때
                else if(tempNum2 == 2)
                {
                    Debug.Log("깃털을 드림캐쳐 기본+거미줄 상태에 붙임");
                    //상태를 기본+깃털+거미줄보석(3)로 바꿈
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState = 3;
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().ShowDreamCatcher();
                    Destroy(obj.transform.gameObject);
                }
            }
            //DreamCatcher(StarPowder)
            if(obj.transform.name == "3-1_1StarPowder" && hit.transform.name == "DreamCatcherCol")
            {
                int tempNum3 = GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState;
                //기본+깃털+거미줄보석(3) 상태 일때만 접촉후 변하게함
                if (tempNum3 == 3)
                {
                    Debug.Log("별가루를 드림캐쳐 기본+깃털+거미줄 상태에 붙임");
                    //상태를 드림캐쳐 최종형태(4)로 바꿈
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState = 4;
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().ShowDreamCatcher();
                    //Event_Manager의 드림캐처 얻은 후 이벤트 발생시키는 변수를 true로
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().MakeDreamCatcher = true;
                    Destroy(obj.transform.gameObject);
                }
            }

        }

        else if (touches.Length == 1)
            touches[0].transform.SetParent(Inventory.transform.Find("2_Grid"));

    }

}
