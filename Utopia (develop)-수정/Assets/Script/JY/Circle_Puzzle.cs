using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Puzzle : MonoBehaviour {


    public bool turning = false;
    public bool direction = false;
    public bool Activated = false;

    int index = 0;

    public GameObject Selected_Piece;
    public GameObject Circle_Puzzle_Control;

    // Use this for initialization
    void Start ()
    {
        Circle_Puzzle_Control.SetActive(true);
        Selected_Piece = GameObject.Find("Circle_Tile1");
        Circle_Puzzle_Control = GameObject.Find("Circle_Puzzle_Control");
        Circle_Puzzle_Control.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!Activated)
            return;
        Turn(direction);
    }

    void Turn(bool direction)
    {
       if (!turning)
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
        return;
    }
}
