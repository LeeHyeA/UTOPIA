using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : MonoBehaviour {

    Transform Round1;
    //Transform Round2;
    //Transform Round3;

    // Use this for initialization
    void Start () {
        Round1 = transform.Find("1Round");
        //Round2 = transform.Find("2Round");
        //Round3 = transform.Find("3Round");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Rain()
    {
        if(PlayerPrefs.GetString("Seed", "false") == "true")
        {
            Transform Garden = Round1.Find("Change").Find("Garden");
            Garden.Find("Grass").gameObject.SetActive(false);
            Garden.Find("Flower").gameObject.SetActive(true);
            
        }

        else
        {
            Transform Garden = Round1.Find("Change").Find("Garden");
            Garden.Find("Grass").gameObject.SetActive(true);
            Garden.Find("Flower").gameObject.SetActive(false);
        }
    }
}
