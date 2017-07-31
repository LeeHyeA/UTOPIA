using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : MonoBehaviour {

    Transform Round1;
    Transform Round2;
    Transform Round3;

    // Use this for initialization
    void Start () {
        Round1 = transform.Find("1Round");
        Round2 = transform.Find("2Round");
        Round3 = transform.Find("3Round");
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

    public void MedicalCertificate()
    {
        GameObject Piece1 = Round2.Find("Medical").Find("Piece1").gameObject;
        GameObject Piece2 = Round2.Find("Medical").Find("Piece2").gameObject;
        GameObject Piece3 = Round2.Find("Medical").Find("Piece3").gameObject;
        GameObject Piece4 = Round2.Find("Medical").Find("Piece4").gameObject;
        GameObject Piece5 = Round2.Find("Medical").Find("Piece5").gameObject;

        if(Piece1.activeSelf && Piece2.activeSelf && Piece3.activeSelf && Piece4.activeSelf && Piece5.activeSelf)
        {
            Round2.gameObject.SetActive(false);
            Round3.gameObject.SetActive(true);
        }
    }
}
