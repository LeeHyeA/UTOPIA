﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Puzzle : MonoBehaviour {

    AudioManager AM;
    AudioClip AC;
    public bool turning = false;
    public bool direction = false;
    public bool Activated = false;

    public bool Answerd = false;

    public GameObject Selected_Piece;

    public GameObject Circle_Puzzle_Control;

    public GameObject Left_Button;
    public GameObject Right_Button;
    public GameObject Rope;

    public GameObject[] CPT = new GameObject[6];
    
    EventManager EM;

    // Use this for initialization
    void Start ()
    {
        Circle_Puzzle_Control.SetActive(true);
        Selected_Piece = GameObject.Find("Circle_Tile1");
        Circle_Puzzle_Control = GameObject.Find("Circle_Puzzle_Control");
        for (int i = 0; i < 6; i++)
        {
            CPT[i] = GameObject.Find("Circle_Tile (" + (i+1).ToString()+")");
        }
        Circle_Puzzle_Control.SetActive(false);
        AC = Resources.Load<AudioClip>("Sound/GetRope");
        EM = FindObjectOfType<EventManager>();
        AM = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update ()
    {
        if (!Activated || Answerd) 
            return;
        Check();    
    }

    public void Leftbutton()
    {
       // if(!turning)
            StartCoroutine("RotLeft");
        return;
    }
    public void Rightbtton()
    {
        //if(!turning)
            StartCoroutine("RotRight");
        return;
    }

    IEnumerator RotLeft()
    {
        AM.PlaySound(AC);

        GameObject TurningObj = Selected_Piece;

        Debug.Log("코루틴시작");

        for (int i = 0; i < 15; i++) 
        {
            TurningObj.transform.Rotate(0, 0, 3);
            Debug.Log("중");
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("코루틴끝");
        //     turning = false;
        TurningObj.GetComponent<Circle_Puzzle_Tile>().tile_stats = (Selected_Piece.GetComponent<Circle_Puzzle_Tile>().tile_stats - 1) % 8;
    }
    IEnumerator RotRight()
    {
        AM.PlaySound(AC);

        GameObject TurningObj = Selected_Piece;

        Debug.Log("코루틴시작");

        for (int i = 0; i < 15; i++)
        {
            Selected_Piece.transform.Rotate(0, 0, -3);
            Debug.Log("중");
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("코루틴끝");
        //        turning = false;
        TurningObj.GetComponent<Circle_Puzzle_Tile>().tile_stats = (Selected_Piece.GetComponent<Circle_Puzzle_Tile>().tile_stats + 1) % 8;
    }

    public void Turn_ON()
    {
        if (EM.Doing_Event)
            return;
        Activated = true;
        Circle_Puzzle_Control.SetActive(Activated);
        EM.Doing_Event = true;
        return;
    }
    public void Turn_OFF()
    {
        Activated = false;
        Circle_Puzzle_Control.SetActive(Activated);
        EM.Doing_Event = false;
        return;
    }
    void Check()
    {
        if (Answerd)
            return;
        for(int i = 0;i<6;i++)
        {
            if (CPT[i].GetComponent<Circle_Puzzle_Tile>().tile_stats != 0)
                return;
        }

        Answerd = true;
        
        Destroy(Left_Button);
        Destroy(Right_Button);
        EM.Event_Number = 200;
        return;
    }
}