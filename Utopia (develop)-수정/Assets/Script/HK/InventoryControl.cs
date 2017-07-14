using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using LitJson;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour {

    public Text Name_Text;                  // 아이템 이름
    public Text Place_Text;                 // 아이템 획득 장소
    public Text Item_Text;                  // 아이템 설명
    public Image Item_Image;                // 이미지
    public Image Panel_Image;

    public string NameString;
    public string PlaceString;
    public string TextString;
    public string ImageString;

    public GameObject SetChat;

    public bool isActive = false;           // true이면 획득, flase이면 사용

    public JsonData ConvertedData;          //Json의 객체로, 캐릭터의 이름, 대사, 이미지의 상태 정보

    public int currentIndex;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            SetChat.gameObject.SetActive(true);

            Name_Text.text = ConvertedData["Item"][currentIndex]["Item_Name"].ToString();
            Item_Text.text = ConvertedData["Item"][currentIndex]["Item_Text"].ToString();
            ImageString = ConvertedData["Item"][currentIndex]["Item_Image"].ToString();

            Item_Image.sprite = Resources.Load<Sprite>(ImageString);
            Item_Image.color = new Color(Item_Image.color.r, Item_Image.color.g, Item_Image.color.b, 255);
            Panel_Image.color = new Color(Item_Image.color.r, Item_Image.color.g, Item_Image.color.b, 255);

            SetChat.gameObject.SetActive(true);  
        }
        else
        {
            SetChat.gameObject.SetActive(false);

            Name_Text.text = "";
            Item_Text.text = "";
            currentIndex = 0;
        }

    }

    public void LodaJSON(JsonData ConvertedData_of_Object, bool DestroyActivated)                                  //객체와 상호작용할때마다 호출되는 함수 (해당 객체의 JSON을 로드함)
    {
        currentIndex = 0;

        isActive = true;

        ConvertedData = ConvertedData_of_Object;

        Debug.Log(currentIndex);
    }
}
