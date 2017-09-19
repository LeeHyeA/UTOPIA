using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour {


    public Image HintItemImage;
    public GameObject ButtonScrollList; //아이템 목록창
    public GameObject TextScrollArea;   //아이템 내용창

    public ScrollRect SR;

    [HideInInspector]
    public RectTransform CurrentTextContent;

    public Text CurrentItemNumberText;

    public Text SimpleNameText;

    public Text Brazil;
    public Text Mongoal;
    public Text test;

   // bool IsItemUnlock = false;

    public struct HighlightText
    {
        public string HT_name;
        public string HT_filename;
        public bool IsUnlock;
        public HighlightText(string HT_name,string HT_filename,bool IsUnlock)
        {
            this.HT_name = HT_name;
            this.HT_filename = HT_filename;
            this.IsUnlock = IsUnlock;
        }
    }
    const int HightlightText_SIZE = 3;
    //강조 아이템 텍스트 구조체 배열 선언
    public HighlightText[] HT = new HighlightText[HightlightText_SIZE]
    {
        new HighlightText("??????","Unknown",false),
        new HighlightText("아버지의 편지(브라질)","FathersLetter",true),
        new HighlightText("로잘린의 편지(몽골)","RoJalsLetter",true)
    };


    [HideInInspector]
    public int SelectTextNumber = 0;


    //언락될 아이템 넘버
    public int ToUnlockTextNumber = 0;



	void Start ()
    {
        CurrentTextContent = Brazil.rectTransform;
        Brazil.gameObject.SetActive(true);
        SR.content = CurrentTextContent;
    }
	
	void Update ()
    {
        UpdateSR();
        ChangeText(); // 아이템 내용창 내용 업데이트
    }



    //ScrollRect 업데이트 함수
    void UpdateSR()
    {
        SR.content = CurrentTextContent;

        //아이템 목록 볼때 왼쪽밑 아이템 이름 텍스트창 업데이트
        if (!HT[SelectTextNumber].IsUnlock)
            SimpleNameText.text = "??????";
        else if (HT[SelectTextNumber].IsUnlock)
        {
            if (SelectTextNumber != 0)
                SimpleNameText.text = HT[SelectTextNumber].HT_name;
            else
                SimpleNameText.text = " ";
        }


        //현재 아이템 넘버링 텍스트 업데이트
            CurrentItemNumberText.text = "Item No." + SelectTextNumber;


        //아이템 아이콘 이미지 업데이트
        HintItemImage.sprite = Resources.Load<Sprite>("HintItem/"+HT[SelectTextNumber].HT_filename);
        
    }

    public void ChangeText()
    {
        //그전 텍스트 오브젝트를 false
        CurrentTextContent.gameObject.SetActive(false);
        switch (SelectTextNumber)
        {
            case 1:
                CurrentTextContent = Brazil.rectTransform;
                CurrentTextContent.gameObject.SetActive(true);
                break;
            case 2:
                CurrentTextContent = Mongoal.rectTransform;
                CurrentTextContent.gameObject.SetActive(true);
                break;
            case 3:
                CurrentTextContent = test.rectTransform;
                CurrentTextContent.gameObject.SetActive(true);
                break;
        }
        
    }

    //현재 선택되있는 아이템 넘버링 세팅
    public void SelectTextNumberSet(int num)
    {
        SelectTextNumber = num;
    }

    //아이템 내용창 띄우기
    public void EnterItemContentText()
    {
        //Text SelectHighlightText = CurrentTextContent

        //만약 인덱스 번호가 x이고 Unlock이 되었을때
        switch (SelectTextNumber)
        {
            //아버지편지(브라질)
            case 1:
                //아이템이 Unlock이 되었다면
                if (HT[SelectTextNumber].IsUnlock)
                {
                    TextScrollArea.SetActive(true);
                    ButtonScrollList.SetActive(false);
                }
                break;
            //로잘린편지(몽골)
            case 2:
                if (HT[SelectTextNumber].IsUnlock)
                {
                    TextScrollArea.SetActive(true);
                    ButtonScrollList.SetActive(false);
                }
                break;

        }
        

        //x번째 아이템창 버튼을 Highlight상태로 해준다 (Event trigger로 구현했는데 수정필요)
        //추가로 Highlight 컬러 설정도 해주기(추가예정)

        //하이라이트 상태일때 Enter키를 누르면 바로 그아이템 설명 텍스트 창으로 이동가능(추가예정)

        //
    }

    public void ExitItemContentText()
    {
        ButtonScrollList.SetActive(true);
        TextScrollArea.SetActive(false);
    }


    //언락넘버 설정
    public void ToUnlockTextNumberSet(int num)
    {
        ToUnlockTextNumber = num;
    }
    //아이템 언락시 실행함수
    public void ItemUnlock()
    {
        switch(ToUnlockTextNumber)
        {
            case 1:
                //Lock Text를 setactive(false) 시키고
                //ItemName Text를 Setactive(true) 시킨다
                break;
        }
    }
}
