using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalContol : MonoBehaviour {

    //public GameObject TaxidermiedAnimal;
    public GameObject Sheep_Layer;
    public GameObject Goat_Layer;
    public GameObject Hippo_Layer;

    public GameObject Sheep_Before;
    public GameObject Sheep_After;

    public GameObject Hippo_Before;
    public GameObject Hippo_After;

    //얻을수 있는 아이템들
    public GameObject Ingredient_Meat;
    public GameObject Ingredient_Milk;
    public GameObject Ingredient_FullWateringCan;

    //빈우유병을 염소에게 가져다 놓았는지 여부
    public bool PutEmptyMilk = false;

    //칼을 양에게 가져다 놓았는지 여부
    public bool PutKnife = false;
    //최종적으로 얻은 양고기를 얻었는지 여부
    public bool GetMeat = false;

    //빈 물뿌리개를 하마에게 가져다 놓았는지 여부
    public bool PutWateringCan = false;
    //채운 물뿌리게를 얻었는지 여부
    public bool GetWateringCan = false;

    void Start () {
		
	}
    
    void Update()
    {
        //GameObject Sheep_Before = Sheep_Layer.GetComponent<GameObject>().GetComponentInChildren

        //Sheep_Layer.transform.FindChild("Taxidermied_Sheep(Before)");
    }

    public void SheepComplete()
    {
        if (PutKnife)
        {
            //재료(고기) 활성화
            if (GetMeat)
                Ingredient_Meat.SetActive(false);
            else
                Ingredient_Meat.SetActive(true);
        }
    }
    public void GoatComplete()
    {
        if (PutEmptyMilk)
        {
            //우유병을 가져다 놨을 경우 채워진 우유병 보여줌
            //GameObject FullMilk = Goat_Layer.transform.Find("Ingredient(Milk)").gameObject;
            Ingredient_Milk.SetActive(true);
        }
    }
    public void HippoComplete()
    {
        if (GetWateringCan)
            Ingredient_FullWateringCan.SetActive(false);
        else
            Ingredient_FullWateringCan.SetActive(true);
    }

    public void ShowSheep()
    {
        //레이어는 기본적으로 킴
        Sheep_Layer.SetActive(true);
        
        //양고기 얻은 후 양 상태
        if (PutKnife)
        {
            //양이 찔린 후 모습 활성화
            //GameObject Sheep_After = Sheep_Layer.transform.Find("Taxidermied_Sheep(After)").gameObject;
            //Sheep_After.SetActive(true);
            Sheep_Before.SetActive(false);
            Sheep_After.SetActive(true);

            //재료(고기) 활성화
            if (GetMeat)
                Ingredient_Meat.SetActive(false);
            else
                Ingredient_Meat.SetActive(true);
            return;
        }
        //if 양고기 얻기 전 양 상태
        else if (!PutKnife)
        {
            GameObject Sheep_Before = Sheep_Layer.transform.Find("Taxidermied_Sheep(Before)").gameObject;
            Sheep_Before.SetActive(true);
        }
           
    }

    public void ShowGoat()
    {
        //레이어는 기본적으로 킴
        Goat_Layer.SetActive(true);

        GameObject Goat = Goat_Layer.transform.Find("Taxidermied_Goat").gameObject;
        Goat.SetActive(true);
        if(PutEmptyMilk)
        {
            //우유병을 가져다 놨을 경우 채워진 우유병 보여줌
            //GameObject FullMilk = Goat_Layer.transform.Find("Ingredient(Milk)").gameObject;
            Ingredient_Milk.SetActive(true);
        }

        return;
    }

    public void ShowHippo()
    {
        //레이어는 기본적으로 킴
        Hippo_Layer.SetActive(true);

        if(PutWateringCan)
        {
            Hippo_Before.SetActive(false);
            Hippo_After.SetActive(true);

            //재료(채운 물뿌리개) 활성화
            if (GetWateringCan)
                Ingredient_FullWateringCan.SetActive(false);
            else
                Ingredient_FullWateringCan.SetActive(true);
            return;
        }
    }

    public void ExitSheep()
    {
        Sheep_Layer.SetActive(false);
    }

    public void ExitGoat()
    {
        Goat_Layer.SetActive(false);
    }

    public void ExitHippo()
    {
        Hippo_Layer.SetActive(false);
    }

    public void CheckGetFullMilk(bool check)
    {
        PutEmptyMilk = check;
    }

    public void CheckGetMeat(bool check)
    {
        GetMeat = check;
    }

    public void CheckGetWateringCan(bool check)
    {
        GetWateringCan = check;
    }
}
