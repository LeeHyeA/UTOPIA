using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Puzzle : MonoBehaviour {

    AudioManager AM;
    public AudioClip ClearSound;
    public AudioClip SlideSound;
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

        AM.PlaySound(SlideSound);
        GameObject TurningObj = Selected_Piece;
        TurningObj.GetComponent<Circle_Puzzle_Tile>().tile_stats = (Selected_Piece.GetComponent<Circle_Puzzle_Tile>().tile_stats - 1) % 8;

        Debug.Log("코루틴시작");

        for (int i = 0; i < 15; i++) 
        {
            TurningObj.transform.Rotate(0, 0, 3);
            Debug.Log("중");
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("코루틴끝");
        //     turning = false;
    }
    IEnumerator RotRight()
    {

        AM.PlaySound(SlideSound);

        GameObject TurningObj = Selected_Piece;
        TurningObj.GetComponent<Circle_Puzzle_Tile>().tile_stats = (Selected_Piece.GetComponent<Circle_Puzzle_Tile>().tile_stats + 1) % 8;

        Debug.Log("코루틴시작");

        for (int i = 0; i < 15; i++)
        {
            Selected_Piece.transform.Rotate(0, 0, -3);
            Debug.Log("중");
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("코루틴끝");
        //        turning = false;
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

        AM.PlaySound(ClearSound);
        Answerd = true;
        
        Destroy(Left_Button);
        Destroy(Right_Button);
        EM.Event_Number = 200;
        return;
    }

    public void cheat()
    {
        for (int i = 0; i < 6; i++)
        {
            CPT[i].GetComponent<Circle_Puzzle_Tile>().tile_stats = 0;
        }

    }
}