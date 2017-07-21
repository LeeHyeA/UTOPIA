using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureControl : MonoBehaviour {

    public GameObject Table_Layer;
    public GameObject Table_Defalut;
    public GameObject Ocean_Layer;
    public GameObject Bonfire_Layer;

    //GameObject HotStone = Table_Layer.transform.Find("AddHotStone").gameObject;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void ShowTable()
    {
        Table_Layer.SetActive(true);
        GameObject HotStone = Table_Defalut.transform.Find("AddHotStone").gameObject;
        GameObject Carrot = Table_Defalut.transform.Find("AddCarrot").gameObject;
        GameObject Meat = Table_Defalut.transform.Find("AddMeat").gameObject;
        GameObject Potato = Table_Defalut.transform.Find("AddPotato").gameObject;
        GameObject Steam = Table_Defalut.transform.Find("AddSteam").gameObject;
        GameObject MilkBottle = Table_Defalut.transform.Find("AddMilkBottle").gameObject;
    }

    public void ShowOcean()
    {
        Ocean_Layer.SetActive(true);
    }

    public void ShowBonfire()
    {
        Bonfire_Layer.SetActive(true);
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
}
