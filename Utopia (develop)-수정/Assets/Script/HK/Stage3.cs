using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : MonoBehaviour {

    Transform Round1;
    Transform Round2;
    Transform Round3;
	public EventManager Event;

    // Use this for initialization
    void Start () {
        Round1 = transform.Find("1Round");
        Round2 = transform.Find("2Round");
        Round3 = transform.Find("3Round");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TrueRain()
	{
	}

	public void FalseRain()
	{
	}

    public void FlowerRain()
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
			Event.EventnumberSet (302);

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
			Round2.Find ("Black").gameObject.SetActive (true);
			Event.EventnumberSet (310);
        }
    }

	public void Orgel()
	{
		Transform orgel = Round3.Find ("3Round").Find ("Orgel");
		if(orgel.Find("Finish").gameObject.activeSelf && orgel.Find("Cover").gameObject.activeSelf)
		{
			// 음악 들리고
			// 재규어 잠듦
			// 아이템 얻는 거 이벤트 매니져로 변경하기
			Round3.Find("Jaguar").gameObject.SetActive(false);
			Transform click = Round3.Find ("BG").Find ("ClickObject").transform;

			click.Find ("OrgelButton").gameObject.SetActive (false);
			click.Find ("OrgelGet").gameObject.SetActive (true);
		}
	}

	public void carrierChk()
	{
		GameObject Dreamcatcher = Round3.Find("Carrier").Find("Dreamcatcher").gameObject;
		GameObject Rose = Round3.Find("Carrier").Find("Rose").gameObject;
		GameObject Book = Round3.Find("Carrier").Find("Book").gameObject;
		GameObject Orgel = Round3.Find("Carrier").Find("Orgel").gameObject;
		GameObject Picture = Round3.Find("Carrier").Find("Picture").gameObject;

		if (Dreamcatcher.activeSelf && Rose.activeSelf && Book.activeSelf && Orgel.activeSelf && Picture.activeSelf) 
		{
			Transform click = Round3.Find ("BG").Find ("ClickObject").transform;

			click.Find ("CarrierButton").gameObject.SetActive (false);
			click.Find ("CarrierGet").gameObject.SetActive (true);
		}
	}

}
