using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    TextAsset data;
    JsonData ItemData;
    JsonData SaveData;
    GameObject obj;

    public Data[] saveDate;

    public GameObject ItemClone;

    public int ItemNumber = -1;

    public string ImageString = "";

    public Image ItemImage;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 버튼으로 입력
    public void GetNumber(int number)
    {
        ItemNumber = number;
    }

    // 이건 굳이 이렇게 안하고 특정 판넬이 켜져있으면 switch문으로 해도 될 듯
    public void LoadJson(string ItemStage)
    {
        if (ItemNumber >= 0 && ItemStage != "")
        {
            data = Resources.Load<TextAsset>(ItemStage + "/" + ItemStage);
            ItemData = JsonMapper.ToObject(data.text);

            ImageString = ItemData["Item"][ItemNumber]["Item_Image"].ToString();

            if (transform.Find("1_ObjectSet").transform.childCount >= 0 &&
                transform.Find("2_Grid").transform.childCount <= 10)
            {
                obj = Instantiate(ItemClone, Vector3.zero, Quaternion.identity) as GameObject;
                obj.transform.SetParent(transform.Find("1_ObjectSet").transform);
                obj.transform.localScale = Vector3.one;
                obj.transform.name = ItemNumber.ToString() + "-" + ImageString;
            }
            obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(ItemStage + "/" + ImageString);
            obj.GetComponent<Image>().color = new Color(obj.GetComponent<Image>().color.r, obj.GetComponent<Image>().color.g, obj.GetComponent<Image>().color.b, 255);

            obj.transform.SetParent(transform.Find("2_Grid").transform);
        }
    }

    // 아이템 사용은 그냥 Destroy 해주면 될 것 같음.
    // 계속 사용가능한 Item은 재생성하기.

    public void SaveInventory()
    {
        //int number;
        //string stage;

        //for (int i = 0; i < transform.Find("2_Grid").childCount; i++)
        //{
        //    saveDate[i].Number = transform.Find("2_Grid").GetChild(i).name;
        //}
    }


    public void DeleteInventory()
    {
        if (transform.Find("2_Grid").transform.childCount > 0)
        {
            for (int i = 0; i < transform.Find("2_Grid").transform.childCount; i++)
            {
                transform.Find("2_Grid").transform.GetChild(i).SetParent(transform.Find("1_ObjectSet").transform);
            }
        }
    }
}

public class Data
{
    public int Number;
    public string Stage;

    public Data(int number, string stage)
    {
        this.Number = number;
        this.Stage = stage;
    }
}