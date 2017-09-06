using UnityEngine;
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
    public Transform Stage3;
	public EventManager Event;
    Item item;

    //1-1
    public GameObject BridCage;
    public GameObject AcquirableItem;
    public GameObject CleanWindowOBJ;
    //public GameObject DreamCatcher;

    //1-2
    //쓸모없는 곳과 아이템이 충돌했을때
    //public bool nothing = true;
    public GameObject FlowerPotPlantState;
    //배경 화분 이미지
    public Image FlowerEnter;

    //1-3
    public GameObject GoldClock;
    public GameObject GoldNeedle;
    public GameObject OwlCage;
    public GameObject FirstPotColbox;
    public GameObject PotState;
    public GameObject FairyTale;

    public HangedMan HM;
    public GangesRiver GR;
    //   public AudioSource audioSource;

    GameObject HeadGear;
    GameObject Inventory;
    GameObject Hint;
    //Transform Grid;

    

    bool FlowerRing = false;
    bool Shell = false;
	bool RoseSeed = false;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        HeadGear = MainStage.Find("HeadGear").gameObject;
        Inventory = UICanvas.Find("2_Inventory").gameObject;
        Hint = UICanvas.Find("3_Hint").gameObject;


        //Transform Click = MainStage.Find("ClickObject").transform;
        //Click.Find("7_Moniter").gameObject.SetActive(false);

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

        if(Input.GetMouseButton(1))
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(CurrentTouchPosition, CurrentTouchPosition, 0.5f);

            if (touches.Length > 0)
            {
                var obj = touches[0];

                if (obj.transform.name == "0-Letter")
                {
                    Hint.SetActive(true);
                    PlayerPrefs.SetInt("Hint", 1);
                }

                if (obj.transform.name == "3-Menual")
                {
                    Hint.SetActive(true);
                    PlayerPrefs.SetInt("Hint", 2);
                }
            }
        }

        item = Inventory.GetComponent<Item>();
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
        //드래그 끝날때 인벤토리로 돌아옴
        draggedObject.transform.SetParent(Inventory.transform.Find("2_Grid"));
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

            // 예외처리
            if (obj.transform.tag == "Item" && hit.transform.tag == "Item")
            {
                obj.transform.SetParent(Inventory.transform.Find("2_Grid"));
            }

            if (obj.transform.tag == "Item" && hit.transform.tag == "Grid")
            {
                obj.transform.SetParent(Inventory.transform.Find("2_Grid"));
            }

            if (obj.transform.tag == "Item" && hit.transform.tag == "Collision")
            {
                obj.transform.SetParent(Inventory.transform.Find("2_Grid"));
            }

            if(obj.transform.tag == "Item" && hit.transform.tag == "Untagged")
            {
                obj.transform.SetParent(Inventory.transform.Find("2_Grid"));
            }

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
                //Transform Click = MainStage.Find("ClickObject").transform;
                //Click.Find("7_Moniter").gameObject.SetActive(true);
                MainStage.Find("Computer").gameObject.SetActive(true);

                if (Inventory.gameObject.activeSelf)
                    Inventory.gameObject.SetActive(false);

                Destroy(obj.transform.gameObject);

                PlayerPrefs.SetString("HeadGear", "true");
            }



            // 1 Stage(1-1)
            //모이를 빈새장으로
            if (obj.transform.name == "4-1_1BirdFeed" && hit.transform.name == "BirdCageEmptyCol")
            {
                BridCage.transform.Find("BirdCageEmpty").gameObject.SetActive(false);
                BridCage.transform.Find("BirdCagePutFeed").gameObject.SetActive(true);
                GameObject.Find("WindowButton").GetComponent<RoomWindow>().SetPutFeedToBirdCage();
                Destroy(obj.transform.gameObject);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 50;
            }

            //일단 보류
            /*
            //모이가 들어있는 새장을 맑은날창문으로
            if (obj.transform.name == "5-1_1BirdCagePutFeed" && hit.transform.name == "2_CleanWindow")
            {
                BridCage.transform.Find("BirdCageFull").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }
            */

            //얻은 거미줄을 맑은날 창문으로
            if (obj.transform.name == "2-1_1SpiderWeb" && hit.transform.name == "2_CleanWindow")
            {
                CleanWindowOBJ.transform.Find("PutSpiderWeb").gameObject.SetActive(true);
                GameObject.Find("WindowButton").GetComponent<RoomWindow>().SetPutSpiderWeb();
                Destroy(obj.transform.gameObject);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 52;
            }

            //일단 보류
            /*
            //거미줄을 비오는날 창문으로
            if(obj.transform.name == "2-1_1SpiderWeb" && hit.transform.name == "1_RainWindow")
            {
                Debug.Log("거미줄 비오는날 창문에 접촉");
                AcquirableItem.transform.Find("SpiderJem").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }
            */
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
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 54;
                }
                //기본+깃털상태(1)에서 거미줄보석 붙일때
                else if (tempNum == 1)
                {
                    Debug.Log("거미줄+보석완성을 드림캐쳐 기본+깃털 상태에 붙임");
                    //상태를 기본+깃털+거미줄보석(3)로 바꿈
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState = 3;
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().ShowDreamCatcher();
                    Destroy(obj.transform.gameObject);
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 54;
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
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 56;
                }
                //기본+거미줄보석(2)상태에서 깃털 붙일때
                else if (tempNum2 == 2)
                {
                    Debug.Log("깃털을 드림캐쳐 기본+거미줄 상태에 붙임");
                    //상태를 기본+깃털+거미줄보석(3)로 바꿈
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState = 3;
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().ShowDreamCatcher();
                    Destroy(obj.transform.gameObject);
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 56;
                }
            }
            //DreamCatcher(StarPowder)
            if (obj.transform.name == "3-1_1StarPowder" && hit.transform.name == "DreamCatcherCol")
            {
                int tempNum3 = GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState;
                int CuttonTempNum = GameObject.Find("WindowButton").GetComponent<RoomWindow>().Curtain_State;
                //기본+깃털+거미줄보석(3) 상태 일때만 접촉후 변하게함
                //09.06 추가로 밤상태일때 별가루가 적용됨
                if (tempNum3 == 3 && CuttonTempNum ==1)
                {
                    Debug.Log("별가루를 드림캐쳐 기본+깃털+거미줄 상태에 붙임");
                    //상태를 드림캐쳐 최종형태(4)로 바꿈
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().DreamCatcherState = 4;
                    GameObject.Find("DreamCatcherManager").GetComponent<DreamCatcher>().ShowDreamCatcher();
                    //Event_Manager의 드림캐처 얻은 후 이벤트 발생시키는 변수를 true로
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().MakeDreamCatcher = true;
                    Destroy(obj.transform.gameObject);
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 58;
                }
            }

            // 1Stage (1-2)

            //--음식재료 얻기--//

            //빈우유병을 염소에 놓아 채우기
            if (obj.transform.name == "3-Ingredient(EmptyMilk)" && hit.transform.name == "goat")
            {
                Debug.Log("빈우유병 채우기 완료");

                //AnimalControl의 빈우유병을 놓았음을 알려주는 변수를 참으로
                GameObject.Find("AnimalContoller").GetComponent<AnimalContol>().PutEmptyMilk = true;
                //그후 다시 갱신해서 보여줌
                GameObject.Find("AnimalContoller").GetComponent<AnimalContol>().GoatComplete();
                //빈우유병 삭제
                Destroy(obj.transform.gameObject);

                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 124;
                //효과음재생
                GameObject.Find("SoundManager").GetComponent<SoundManager>().SE_Number = 1;
                GameObject.Find("SoundManager").GetComponent<SoundManager>().SE_List();
            }

            //칼을 양에 놓아 고기얻기
            if (obj.transform.name == "0-Knife" && hit.transform.name == "sheepCol")
            {
                Debug.Log("칼로 고기얻기 완료");

                //양 충돌박스 삭제
                Destroy(hit.transform.gameObject);
                

                //AnimalControl의 칼을 놓았음을 알려주는 변수를 참으로
                GameObject.Find("AnimalContoller").GetComponent<AnimalContol>().PutKnife = true;
                //그후 다시 갱신해서 보여줌
                GameObject.Find("AnimalContoller").GetComponent<AnimalContol>().SheepComplete();
                obj.transform.SetParent(Inventory.transform.Find("2_Grid"));
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 122;

            }
            //빈 물뿌리개를 하마에 놓아 물채우기
            if (obj.transform.name == "1-EmptyWateringCan" && hit.transform.name == "hippo")
            {
                Debug.Log("하마에 빈물뿌리개 놓기 완료");

                //AnimalControl의 물뿌리개를 놓았음을 알려주는 변수를 참으로
                GameObject.Find("AnimalContoller").GetComponent<AnimalContol>().PutWateringCan = true;
                //그후 다시 갱신해서 보여줌
                GameObject.Find("AnimalContoller").GetComponent<AnimalContol>().HippoComplete();
                //빈물뿌리개 삭제
                Destroy(obj.transform.gameObject);

                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 126;
            }
            //돌을 모닥불에 옮겨 달군돌 얻기
            if (obj.transform.name == "8-Ingredient(Stone)" && hit.transform.name == "Picture3(bonfire)")
            {
                Debug.Log("달군돌 얻기 완료");

                GameObject.Find("PolaroidController").GetComponent<PictureControl>().PutStone = true;
                GameObject.Find("PolaroidController").GetComponent<PictureControl>().ShowBonfire();
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 140;
                Destroy(obj.transform.gameObject);
            }

            //--테이블에서 음식 만들기--//
            //달군돌을 테이블에 놓기
            if (obj.transform.name == "9-Ingredient(HotStone)" && hit.transform.name == "TableDefalut")
            {
                Debug.Log("달군돌 놓기 완료");

                GameObject.Find("PolaroidController").GetComponent<PictureControl>().PutHotStone = true;
                GameObject.Find("PolaroidController").GetComponent<PictureControl>().ShowTable();
                Destroy(obj.transform.gameObject);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 142;
            }
            //고기를 테이블에 놓기
            if (obj.transform.name == "7-Ingredient(Meat)" && hit.transform.name == "TableDefalut")
            {
                Debug.Log("고기 놓기 완료");

                GameObject.Find("PolaroidController").GetComponent<PictureControl>().PutMeat = true;
                GameObject.Find("PolaroidController").GetComponent<PictureControl>().ShowTable();
                Destroy(obj.transform.gameObject);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 144;
            }
            //우유를 테이블에 놓기
            if (obj.transform.name == "4-Ingredient(Milk)" && hit.transform.name == "TableDefalut")
            {
                Debug.Log("우유 놓기 완료");

                GameObject.Find("PolaroidController").GetComponent<PictureControl>().PutMilkBottle = true;
                GameObject.Find("PolaroidController").GetComponent<PictureControl>().ShowTable();
                Destroy(obj.transform.gameObject);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 146;
            }
            //감자를 테이블에 놓기
            if (obj.transform.name == "6-Ingredient(Potato)" && hit.transform.name == "TableDefalut")
            {
                Debug.Log("감자 놓기 완료");

                GameObject.Find("PolaroidController").GetComponent<PictureControl>().PutPotato = true;
                GameObject.Find("PolaroidController").GetComponent<PictureControl>().ShowTable();
                Destroy(obj.transform.gameObject);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 148;
            }

            //당근을 테이블에 놓기
            if (obj.transform.name == "5-Ingredient(Carrot)" && hit.transform.name == "TableDefalut")
            {
                Debug.Log("당근 놓기 완료");

                GameObject.Find("PolaroidController").GetComponent<PictureControl>().PutCarrot = true;
                GameObject.Find("PolaroidController").GetComponent<PictureControl>().ShowTable();
                Destroy(obj.transform.gameObject);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 150;
            }

            //채운 물뿌리개로 화분에 물뿌리기
            if (obj.transform.name == "2-FullWateringCan" && hit.transform.name == "Flowerpot")
            {
                Debug.Log("물뿌리기 완료");
                bool TempCarrotState = GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlantCarrot;
                bool TempFoxTailState = GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlantFoxtail;
                bool TempPotatoState = GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlantPotato;
                bool TempBeanState = GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlantBean;
                //if 당근이 심어져있을때, if강아지풀, if감자
                if (TempCarrotState)
                {
                    FlowerPotPlantState.transform.Find("Carrot").gameObject.SetActive(true);
                    obj.transform.SetParent(Inventory.transform.Find("2_Grid"));
                    FlowerEnter.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/PotRabbit01");
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 128;
                }
                if (TempPotatoState)
                {
                    FlowerPotPlantState.transform.Find("Potato").gameObject.SetActive(true);
                    obj.transform.SetParent(Inventory.transform.Find("2_Grid"));
                    FlowerEnter.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/PotPig01");
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 130;
                }
                if (TempFoxTailState)
                {
                    FlowerPotPlantState.transform.Find("Foxtail").gameObject.SetActive(true);
                    obj.transform.SetParent(Inventory.transform.Find("2_Grid"));
                    FlowerEnter.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/PotDog01");
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 132;
                }
                if (TempBeanState)
                {
                    FlowerPotPlantState.transform.Find("Bean").gameObject.SetActive(true);
                    obj.transform.SetParent(Inventory.transform.Find("2_Grid"));
                    FlowerEnter.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/PotBird01");
                    GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 134;
                }
            }
            //잘못심은 작물 칼로 자르기 (강아지풀,콩)
            if (obj.transform.name == "0-Knife" && hit.transform.name == "Foxtail")
            {
                FlowerPotPlantState.transform.Find("Foxtail").gameObject.SetActive(false);
                GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlanted = false;
                GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlantFoxtail = false;
                obj.transform.SetParent(Inventory.transform.Find("2_Grid"));
                FlowerEnter.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/Pot01");
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 136;
            }
            if (obj.transform.name == "0-Knife" && hit.transform.name == "Bean")
            {
                FlowerPotPlantState.transform.Find("Bean").gameObject.SetActive(false);
                GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlanted = false;
                GameObject.Find("FlowerpotController").GetComponent<FlowerpotControl>().IsPlantBean = false;
                obj.transform.SetParent(Inventory.transform.Find("2_Grid"));
                FlowerEnter.sprite = Resources.Load<Sprite>("Stage1-2/Flowerpot/Pot01");
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 138;
            }


            // 1Stage (1-3)

            //망치를 금시계에 놓기
            if(obj.transform.name == "1-Hammer" && hit.transform.name == "GoldClock")
            {
                GoldNeedle.gameObject.SetActive(true);
                //Destroy(hit.transform.gameObject);
                Destroy(obj.transform.gameObject);
                GoldClock.SetActive(false);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 164;
                // obj.transform.SetParent(Inventory.transform.Find("2_Grid")); //제자리로!
            }

            //육포를 새장에 놓기
            if(obj.transform.name == "0-OwlFeed" &&hit.transform.name == "OwlCageEmpty")
            {
                OwlCage.transform.Find("OwlCageEmpty").gameObject.SetActive(false);
                OwlCage.transform.Find("OwlCageFeed").gameObject.SetActive(true);
                GameObject.Find("WindowButton1-3").GetComponent<RoomWindow2>().SetPutFeedToOwlCage();
                Destroy(obj.transform.gameObject);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 166;
            }

            //장미씨앗을 화분에 놓기
            if(obj.transform.name == "4-RoseSeed" && hit.transform.name == "PotCol")
            {
                Debug.Log("장미씨앗 심기완료");
                //장미활성화
                PotState.transform.Find("Rose").gameObject.SetActive(true);
                FirstPotColbox.gameObject.SetActive(false); //심어져있는상태일때 다른씨앗 심기 방지
                Destroy(obj.transform.gameObject);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 168;
            }

            //화분에 나무 심기
            if(obj.transform.name == "3-TreeSeed" && hit.transform.name == "PotCol")
            {
                Debug.Log("나무심기 완료");
                PotState.transform.Find("Tree(before)").gameObject.SetActive(true);
                FirstPotColbox.gameObject.SetActive(false); //심어져있는상태일때 다른씨앗 심기 방지
                Destroy(obj.transform.gameObject);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 170;
            }
            //심어진 나무에 금침 놓기
            if(obj.transform.name == "2-GoldNeedle" && hit.transform.name =="Tree(before)")
            {
                Debug.Log("심은 나무에 금침놓기");
                PotState.transform.Find("Tree(before)").gameObject.SetActive(false);
                PotState.transform.Find("Tree(after)").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 172;
            }
            //(화분예외처리)
            //심어진 나무에 장미씨앗을 놨을경우
            if (obj.transform.name == "4-RoseSeed" && hit.transform.name == "Tree(before)")
            {
                //잘못심었다는 내용의 대사이벤트
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 154;
            }
            if (obj.transform.name == "4-RoseSeed" && hit.transform.name == "Tree(after)")
            {
                //잘못심었다는 내용의 대사이벤트
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 154;
            }
            //심어진 장미에 나무씨앗을 놨을경우
            if (obj.transform.name == "3-TreeSeed" && hit.transform.name == "Rose")
            {
                //잘못심었다는 내용의 대사이벤트
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 156;
            }

            //동화책에 이름표 놓기
            //올빼미
            if (obj.transform.name == "5-OwlName" && hit.transform.name == "OwlNameCol")
            {
                FairyTale.transform.Find("AddOwlName").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
                FairyTale.transform.Find("OwlNameCol").gameObject.SetActive(false);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 174;
                //Destroy(hit.transform.gameObject);
            }
            //나무
            if (obj.transform.name == "7-TreeName" && hit.transform.name == "TreeNameCol")
            {
                FairyTale.transform.Find("AddTreeName").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
                FairyTale.transform.Find("TreeNameCol").gameObject.SetActive(false);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 176;
                //Destroy(hit.transform.gameObject);
            }
            //장미
            if (obj.transform.name == "6-RoseName" && hit.transform.name == "RoseNameCol")
            {
                FairyTale.transform.Find("AddRoseName").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
                FairyTale.transform.Find("RoseNameCol").gameObject.SetActive(false);
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 178;
                //Destroy(hit.transform.gameObject);
            }
            

            //2스테이지

            if (obj.transform.name == "2-Rope" && hit.transform.name == "Hanged_Man")
            {
                Debug.Log("밧줄맨");
                HM.Answer();
                Destroy(obj.transform.gameObject);
            }
            if (obj.transform.name == "0-Red_Color" && hit.transform.name == "Ganges_river")
            {
                GR.On_Red();
                Destroy(obj.transform.gameObject);

            }
            if (obj.transform.name == "1-Blue_Color" && hit.transform.name == "Ganges_river" && GR.getRed())
            {
                GR.On_Blue();
                Destroy(obj.transform.gameObject);

            }
            if (obj.transform.name == "3-Yellow_Color" && hit.transform.name == "Ganges_river" && GR.getRed() && GR.getBlue())
            {
                GR.On_Yellow();
                Destroy(obj.transform.gameObject);
            }

            // 3Stage
            // ***************************************************************************** 1Round

            if (obj.transform.name == "3-FishFeed" && hit.transform.name == "SeaCollision")
            {
                item.GetNumber(4);
                item.LoadJson("3Stage");
                Destroy(obj.transform.gameObject);
            }

            if (obj.transform.name == "2-Camera" && hit.transform.name == "SunCollision")
            {
                item.GetNumber(5);
                item.LoadJson("3Stage");
                Destroy(obj.transform.gameObject);
            }

            if (obj.transform.name == "5-Sunset" && hit.transform.name == "Picture")
            {
                Transform Round1 = Stage3.Find("1Round");
                Round1.Find("Image").gameObject.SetActive(true);
                Round1.Find("Change").Find("Garden").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }

            if (obj.transform.name == "1-Seed" && hit.transform.name == "Grass")
            {
                PlayerPrefs.SetString("Seed", "true");
                Destroy(obj.transform.gameObject);
            }

            if (obj.transform.name == "0-Ring" && hit.transform.name == "Flower")
            {
                Transform Garden = Stage3.Find("1Round").Find("Change").Find("Garden");
                Garden.Find("Flower").gameObject.SetActive(false);

                item.GetNumber(6);
                item.LoadJson("3Stage");
                Destroy(obj.transform.gameObject);
            }

            if (obj.transform.name == "6-FlowerRing" && hit.transform.name == "Statuette")
            {
                FlowerRing = true;
				Stage3.Find ("1Round").Find ("FlowerRing").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
                Check();
            }

            if (obj.transform.name == "4-Shell" && hit.transform.name == "Statuette")
            {
                Shell = true;
				Stage3.Find ("1Round").Find ("Shell").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
                Check();
            }

            // ***************************************************************************** 2Round

            if (obj.transform.name == "7-MedicalCertificate1" && hit.transform.name == "Basic")
            {
                Stage3.Find("2Round").Find("Medical").Find("Piece1").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }

            if (obj.transform.name == "8-MedicalCertificate2" && hit.transform.name == "Basic")
            {
                Stage3.Find("2Round").Find("Medical").Find("Piece2").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }

            if (obj.transform.name == "9-MedicalCertificate3" && hit.transform.name == "Basic")
            {
                Stage3.Find("2Round").Find("Medical").Find("Piece3").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }

            if (obj.transform.name == "10-MedicalCertificate4" && hit.transform.name == "Basic")
            {
                Stage3.Find("2Round").Find("Medical").Find("Piece4").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }

            if (obj.transform.name == "11-MedicalCertificate5" && hit.transform.name == "Basic")
            {
                Stage3.Find("2Round").Find("Medical").Find("Piece5").gameObject.SetActive(true);
                Destroy(obj.transform.gameObject);
            }
				
			// ******************************************************************************** 3Round

			if (obj.transform.name == "13-Feed" && hit.transform.name == "BirdC")
			{
				item.GetNumber(14);
				item.LoadJson("3Stage");

				Destroy(obj.transform.gameObject);
				Destroy(hit.transform.gameObject);

				Stage3.Find("3Round").Find("BG").Find("TextObject").Find("Bird").gameObject.SetActive(false);
				Event.EventnumberSet (320);
			}

			if (obj.transform.name == "14-Feather" && hit.transform.name == "DreamcatcherC")
			{
				Stage3.Find("3Round").Find("BG").Find("TextObject").Find("NonDreamcatcher").gameObject.SetActive(false);
				Stage3.Find("3Round").Find("BG").Find("ClickObject").Find("Dreamcatcher").gameObject.SetActive(true);
				Destroy(obj.transform.gameObject);
				Destroy(hit.transform.gameObject);
			}

			if (obj.transform.name == "12-WateringCan" && hit.transform.parent.name == "SeaC")
			{
				item.GetNumber(15);
				item.LoadJson("3Stage");

				Destroy(obj.transform.gameObject);
			}

			if (obj.transform.name == "15-FullWateringCan" && hit.transform.name == "RoseC")
			{
				Stage3.Find("3Round").Find("BG").Find("TextObject").Find("NonRose").gameObject.SetActive(false);
				Stage3.Find("3Round").Find("BG").Find("ClickObject").Find("Rose").gameObject.SetActive(true);
				Destroy(hit.transform.gameObject);
			}

			if (obj.transform.name == "17-RoseSeed" && hit.transform.name == "OrgelC")
			{
				Transform orgel = Stage3.Find ("3Round").Find ("Orgel");
				if (orgel.gameObject.activeSelf && !orgel.Find ("Cover").gameObject.activeSelf) 
				{
					RoseSeed = true;
					Destroy (obj.transform.gameObject);
				}
			}

			if (obj.transform.name == "15-FullWateringCan" && hit.transform.name == "OrgelC")
			{
				Transform orgel = Stage3.Find ("3Round").Find ("Orgel");
				if (RoseSeed) 
				{
					if (orgel.gameObject.activeSelf && !orgel.Find ("Cover").gameObject.activeSelf) 
					{
						Destroy (obj.transform.gameObject);
						orgel.Find ("Nomal").gameObject.SetActive (false);
						orgel.Find ("Finish").gameObject.SetActive (true);
					}
				}
			}

			if (obj.transform.name == "16-Dreamcatcher" && hit.transform.name == "CarrierNomal")
			{
				Stage3.Find("3Round").Find("Carrier").Find("Dreamcatcher").gameObject.SetActive(true);
				Destroy(obj.transform.gameObject);
			}

			if (obj.transform.name == "18-Rose" && hit.transform.name == "CarrierNomal")
			{
				Stage3.Find("3Round").Find("Carrier").Find("Rose").gameObject.SetActive(true);
				Destroy(obj.transform.gameObject);
			}

			if (obj.transform.name == "19-Orgel" && hit.transform.name == "CarrierNomal")
			{
				Stage3.Find("3Round").Find("Carrier").Find("Orgel").gameObject.SetActive(true);
				Destroy(obj.transform.gameObject);
			}

			if (obj.transform.name == "20-Book" && hit.transform.name == "CarrierNomal")
			{
				Stage3.Find("3Round").Find("Carrier").Find("Book").gameObject.SetActive(true);
				Destroy(obj.transform.gameObject);
			}

			if (obj.transform.name == "21-Picture" && hit.transform.name == "CarrierNomal")
			{
				Stage3.Find("3Round").Find("Carrier").Find("Picture").gameObject.SetActive(true);
				Destroy(obj.transform.gameObject);
			}

			else if (touches.Length == 1)
				touches[0].transform.SetParent(Inventory.transform.Find("2_Grid"));

        }
    }

    void Check()
    {
        if (FlowerRing == true && Shell == true)
        {
            Stage3.Find("1Round").gameObject.SetActive(false);
			Event.EventnumberSet (304);
            Stage3.Find("2Round").gameObject.SetActive(true);
            Inventory.gameObject.SetActive(false);
        }
    }
}
