using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeStage1_1 : MonoBehaviour {

    public GameObject Background;
    public Image Stage1Background;
    //public Image myImage;
	// Use this for initialization
	void Start () {
       // Background = GameObject.Find("Panel(1-1)").GetComponent<Image>().sprite;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeBackground()
    {
        //if(맑은날)
        Stage1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaDay");
        //if(비오는날)
        Stage1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaRainy");
        //if(밤)
        Stage1Background.sprite = Resources.Load<Sprite>("Stage1-1/1_RosaNight");
    }
}
