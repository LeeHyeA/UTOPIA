using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalContol : MonoBehaviour {

    //public GameObject TaxidermiedAnimal;
    public GameObject Sheep_Layer;
    public GameObject Goat_Layer;
    public GameObject Hippo_Layer;

    //public bool ShowSheep = false;
    //public bool ShowGoat = false;
    //public bool ShowHippo = false;

    //public bool ExitSheep = false;
    //public bool ExitGoat = false;
    //public bool ExitHippo = false;
    
    void Start () {
		
	}
    
    void Update()
    {
        //GameObject Sheep_Before = Sheep_Layer.GetComponent<GameObject>().GetComponentInChildren

        //Sheep_Layer.transform.FindChild("Taxidermied_Sheep(Before)");
    }

    public void ShowSheep()
    {
        //레이어는 기본적으로 킴
        Sheep_Layer.SetActive(true);

        //if 양고기 얻기 전 양 상태
        GameObject Sheep_Before = Sheep_Layer.transform.Find("Taxidermied_Sheep(Before)").gameObject;
        Sheep_Before.SetActive(true);
        return;

        //if 양고기 얻은 후 양 상태
    }

    public void ShowGoat()
    {
        Goat_Layer.SetActive(true);

        GameObject Goat = Goat_Layer.transform.Find("Taxidermied_Goat").gameObject;
        Goat.SetActive(true);
        return;
    }

    public void ShowHippo()
    {
        Hippo_Layer.SetActive(true);

        //if 물뿌리기 얻기 전 하마상태
        GameObject Hippo_Before = Hippo_Layer.transform.Find("Taxidermied_Hippopotamus(Before)").gameObject;
        Hippo_Before.SetActive(true);
        return;

        //if 물뿌리기 얻은 후 하마 상태
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

    /*
    public void ShowAnimal()
    {
        if (ShowSheep)
        {
            //레이어는 기본적으로 킴
            Sheep_Layer.SetActive(true);

            //양고기 얻기 전 양 상태
            GameObject Sheep_Before = Sheep_Layer.transform.Find("Taxidermied_Sheep(Before)").gameObject;
            Sheep_Before.SetActive(true);
            return;
        }
        else if(ShowGoat)
        {
            Goat_Layer.SetActive(true);

            return;
        }
        else if(ShowHippo)
        {
            Hippo_Layer.SetActive(true);

            //물뿌리기 얻기 전 하마상태
            GameObject Hippo_Before = Hippo_Layer.transform.Find("Taxidermied_Hippopotamus(Before)").gameObject;
            Hippo_Before.SetActive(true);
            return;
        }
    }
    */

    /*
    void ExitAnimal()
    {
        if(ExitSheep)
        {
            Sheep_Layer.SetActive(false);
            return;
        }
        else if(ExitGoat)
        {
            Goat_Layer.SetActive(false);
            return;
        }
        else if(ExitHippo)
        {
            return;
        }
    }
    */
}
