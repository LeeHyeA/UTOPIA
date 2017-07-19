using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Puzzle : MonoBehaviour {


    public bool turning = false;
    public bool direction = false;
    public bool Activated = false;

    public bool Answerd = false;

    int index = 0;

    public GameObject Selected_Piece;
    public GameObject Circle_Puzzle_Control;

    public GameObject[] CPT = new GameObject[3];

    EventManager EM;

    // Use this for initialization
    void Start ()
    {
        Circle_Puzzle_Control.SetActive(true);
        Selected_Piece = GameObject.Find("Circle_Tile1");
        Circle_Puzzle_Control = GameObject.Find("Circle_Puzzle_Control");
        for (int i = 0; i < 3; i++)
        {
            CPT[i] = GameObject.Find("Circle_Tile"+(i+1).ToString());
        }
        Circle_Puzzle_Control.SetActive(false);

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!Activated || Answerd || EM.Doing_Event) 
            return;
        Turn(direction);
        Check();    
    }

    void Turn(bool direction)
    {
       if (!turning||Answerd)
            return;

       if(direction)
       {
           if(index<45)
           {
               Selected_Piece.transform.Rotate(0, 0, 1);
               index++;
               return;
           }
           else
           {
               index = 0;
               turning = false;
               Selected_Piece.GetComponent<Circle_Puzzle_Tile>().tile_stats = (Selected_Piece.GetComponent<Circle_Puzzle_Tile>().tile_stats - 1) % 8;

                return;
           }

       }
       else
       {
           if (index < 45)
           {
               Selected_Piece.transform.Rotate(0, 0, -1);
               index++;
               return;
           }
           else
           {
               index = 0;
               turning = false;
               Selected_Piece.GetComponent<Circle_Puzzle_Tile>().tile_stats = (Selected_Piece.GetComponent<Circle_Puzzle_Tile>().tile_stats + 1) % 8;

                return;
           }
       }
   }


    public void Turn_Left()
    {
        if (turning)
            return;
        direction = false;
        turning = true;
        return;
    }
    public void Turn_Right()
    {
        if (turning)
            return;
        direction = true;
        turning = true;
        return;
    }
    public void On_Off()
    {
        Activated = !Activated;
        Circle_Puzzle_Control.SetActive(Activated);
        EM.Doing_Event = Activated;
        return;
    }
    void Check()
    {
        if (Answerd)
            return;
        for(int i = 0;i<3;i++)
        {
            if (CPT[i].GetComponent<Circle_Puzzle_Tile>().tile_stats != 0)
                return;
        }

        Answerd = true;
    }
}