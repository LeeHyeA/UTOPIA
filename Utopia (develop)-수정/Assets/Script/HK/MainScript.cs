using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{

    public GameObject Inventory;
    Item item;
    public EventManager Event;
    

    // Use this for initialization
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("StartMain", 0).ToString());
        ////PlayerPrefs.DeleteAll();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        item = Inventory.GetComponent<Item>();

        //if (PlayerPrefs.GetInt("StartMain", 0) == 1)
        //{
        //    this.gameObject.transform.Find("Panel(Start)").gameObject.SetActive(false);
        //    this.gameObject.transform.Find("Panel").gameObject.SetActive(true);
        //    Event.EventnumberSet(5);

        //    PlayerPrefs.SetInt("StartMain", 2);

        //}
    }

    public void PrologueStart()
    {
        //PlayerPrefs.SetInt("StartMain", 1);
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Prologue");
    }

    public void HeadGear()
    {
        Transform HeadGear = transform.Find("Panel").Find("HeadGear").transform;
        if (HeadGear.Find("4_SmallCable").gameObject.activeSelf
            && HeadGear.Find("5_BigCable").gameObject.activeSelf
            && !HeadGear.gameObject.activeSelf)
        {
            item.GetNumber(6);
            item.LoadJson("Main");
            
        }

        else
        {
            item.GetNumber(2);
            item.LoadJson("Main");
        }
    }

}
