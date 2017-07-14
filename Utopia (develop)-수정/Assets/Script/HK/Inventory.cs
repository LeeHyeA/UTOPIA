using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //GameObject ObjectSet;
    //public GameObject Inven;

    Transform ObjectSet = null;
    Transform Grid = null;
    

    Vector3 IndexPosition;

    void Awake()
    {
        ObjectSet = gameObject.transform.Find("1_ObjectSet").transform;
        Grid = gameObject.transform.Find("2_Grid").transform;
    }

    void Start()
    {
        PlayerPrefs.DeleteAll();


       

        ObjectSet.gameObject.SetActive(false);

        if (ObjectSet.childCount > 0)
        {
            for (int i = 0; i < ObjectSet.transform.childCount; i++)
            {
                ObjectSet.GetChild(i).gameObject.SetActive(true);
            }
        }

        gameObject.SetActive(false);
        gameObject.transform.Find("0_InventoryBG").gameObject.SetActive(true);
        Grid.gameObject.SetActive(true);
        gameObject.transform.Find("3_EscButton").gameObject.SetActive(true);
    }

    void Update()
    {

    }

    // 오브젝트 소유 상태 함수
    // -1 : 사용, 0 : 미소유, 1보다 크면 : 소유
    // 오브젝트를 얻게되면 오브젝트의 부모를 Grid로 변경
    public void GateCard(int i)
    {
        if (PlayerPrefs.GetInt("GateCard", 0) < 1)
        {
            PlayerPrefs.SetInt("GateCard", i);
        }
        ObjectSet.Find("0_GateCard").gameObject.transform.SetParent(Grid);
    }

    public void Memo(int i)
    {
        if (PlayerPrefs.GetInt("Memo", 0) < 1)
        {
            PlayerPrefs.SetInt("Memo", i);
            //ObjectSet.Find("1_Panda").gameObject.transform.SetParent(Grid);
        }
    }

    public void GPS(int i)
    {
        if (PlayerPrefs.GetInt("GPS", 0) < 1)
        {
            PlayerPrefs.SetInt("GPS", i);
        }
    }

    public void Pamphelt(int i)
    {
        if (PlayerPrefs.GetInt("Pamphlet", 0) < 1)
        {
            PlayerPrefs.SetInt("Pamphlet", i);
        }
    }

    public void Bottle(int i)
    {
        if (PlayerPrefs.GetInt("Bottle", 0) < 1)
        {
            PlayerPrefs.SetInt("Bottle", i);
        }
        ObjectSet.Find("1_Bottle").gameObject.transform.SetParent(Grid);
    }

    public void SaveObject()
    {
        Debug.Log(PlayerPrefs.GetInt("Monkey", 0).ToString());
        Debug.Log(PlayerPrefs.GetInt("Panda", 0).ToString());
        Debug.Log(PlayerPrefs.GetInt("Rabbit", 0).ToString());
        Debug.Log(PlayerPrefs.GetInt("Bottle", 0).ToString());

        if (PlayerPrefs.GetInt("Monkey", 0) > 0 
            && ObjectSet.Find("0_Monkey").gameObject.transform.parent != Grid)
        {
            ObjectSet.Find("0_Monkey").gameObject.transform.SetParent(Grid);
        }

        if (PlayerPrefs.GetInt("Panda", 0) > 0 
            && ObjectSet.Find("1_Panda").gameObject.transform.parent != Grid)
        {
            ObjectSet.Find("1_Panda").gameObject.transform.SetParent(Grid);
        }

        if (PlayerPrefs.GetInt("Rabbit", 0) > 0
            && ObjectSet.Find("2_Rabbit").gameObject.transform.parent != Grid)
        {
            ObjectSet.Find("2_Rabbit").gameObject.transform.SetParent(Grid);
        }

        if (PlayerPrefs.GetInt("Bottle", 0) > 0
            && ObjectSet.Find("3_Bottle").gameObject.transform.parent != Grid)
        {
            ObjectSet.Find("3_Bottle").gameObject.transform.SetParent(Grid);
        }
    }

}
