using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using LitJson;

public class InventoryJson : MonoBehaviour {

    TextAsset data;                         //Json파일을 문자열로 읽어들임
    public string FileName;                 //실행시킬 대화 이벤트 파일의 이름

    public bool DestroyActivated;           //1번 실행하고 오브젝트를 지울것인지의 여부
    public bool isUpade;                    //업데이트 되었는지

    InventoryControl control;                //대화창 제어

    JsonData ConvertedData;                 //data로 읽어들인 텍스트를 객체로 변환하여 저장

    // Use this for initialization
    void Start()
    {
        control = FindObjectOfType<InventoryControl>();
        
        data = Resources.Load<TextAsset>(FileName);
        ConvertedData = JsonMapper.ToObject(data.text);     //Json 객체로 변환

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Use_Item()
    {
        
        if (control.isActive == false)                            
        {
            control.LodaJSON(ConvertedData, DestroyActivated);
            if (DestroyActivated)
                Destroy(gameObject);
        }
        else
            return;
        
    }

}
