using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairtTaleController : MonoBehaviour {

    public GameObject OwlName;
    public GameObject TreeName;
    public GameObject RoseName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckCompleteFairtTale()
    {
        //모든 이름표 채웠을시
       if(OwlName.activeSelf && TreeName.activeSelf && RoseName.activeSelf)
        {
            Debug.Log("동화책 완성");
            GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 160;
        }
    }
}
