using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureControl : MonoBehaviour {

    public GameObject Table_Layer;
    public GameObject Table_Defalut;
    public GameObject Ocean_Layer;
    public GameObject Bonfire_Layer;
    public GameObject HotStone;
    //GameObject HotStone = Table_Layer.transform.Find("AddHotStone").gameObject;

    //Bonfire//
    //돌을 모닥불에 가져다 놓았는지 여부
    public bool PutStone = false;
    //달군돌을 모닥불에서 얻었는지 여부
    public bool GetHotStone = false;

    //Table//
    public bool PutHotStone = false;
    public bool PutCarrot = false;
    public bool PutMeat = false;
    public bool PutPotato = false;
    public bool PutSteam = false;
    public bool PutMilkBottle = false;


    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void CheckCompleteTable()
    {
        if(PutHotStone && PutCarrot && PutMeat && PutPotato && PutMilkBottle)
        {
            GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 118;
        }
    }

    public void ShowTable()
    {
        Table_Layer.SetActive(true);
        if (PutHotStone)
        {
            GameObject AddHotStone = Table_Defalut.transform.Find("AddHotStone").gameObject;
            AddHotStone.SetActive(true);
            //돌을 넣었을때 김도 같이 발생
            GameObject AddSteam = Table_Defalut.transform.Find("AddSteam").gameObject;
            AddSteam.SetActive(true);
        }
        if (PutCarrot)
        {
            GameObject AddCarrot = Table_Defalut.transform.Find("AddCarrot").gameObject;
            AddCarrot.SetActive(true);
        }
        if (PutMeat)
        {
            GameObject AddMeat = Table_Defalut.transform.Find("AddMeat").gameObject;
            AddMeat.SetActive(true);

        }
        if (PutPotato)
        {
            GameObject AddPotato = Table_Defalut.transform.Find("AddPotato").gameObject;
            AddPotato.SetActive(true);
        }
        if (PutMilkBottle)
        {
            GameObject AddMilkBottle = Table_Defalut.transform.Find("AddMilkBottle").gameObject;
            AddMilkBottle.SetActive(true);
        }
    }

    public void ShowOcean()
    {
        Ocean_Layer.SetActive(true);
    }

    public void ShowBonfire()
    {
        Bonfire_Layer.SetActive(true);

        if (PutStone)
        {
            if (GetHotStone)
                HotStone.SetActive(false);
            else
                HotStone.SetActive(true);
        }
    }

    public void ExitTable()
    {
        Table_Layer.SetActive(false);
    }

    public void ExitOcean()
    {
        Ocean_Layer.SetActive(false);
    }

    public void ExitBonfire()
    {
        Bonfire_Layer.SetActive(false);
    }



    public void CheckGetHotStone(bool check)
    {
        GetHotStone = check;
    }
}
