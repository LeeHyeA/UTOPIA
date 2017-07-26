using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangesRiver : MonoBehaviour {

    public GameObject Red;
    public GameObject Blue;
    public GameObject Yellow;
    bool is_Red = false;
    bool is_Blue = false;
    bool is_Yellow = false;
    bool Answerd = false;

    public GameObject Door;

    EventManager EM;
	// Use this for initialization
	void Start () {
        EM = FindObjectOfType<EventManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (is_Red && is_Blue && is_Yellow && !Answerd)
        {
            EM.Event_Number = 202;
            Answerd = true;
        }
	}

    public void On_Red()
    {
        Red.SetActive(true);
        is_Red = true;
        return;
    }
    public void On_Blue()
    {
        Blue.SetActive(true);
        is_Blue = true;
        return;
    }
    public void On_Yellow()
    {
        Yellow.SetActive(true);
        is_Yellow = true;
        return;
    }

    public void Activate_Door()
    {
        Door.SetActive(true);
        return;
    }
}
