using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Puzzle_Tile : MonoBehaviour {

    Transform Tf;
    bool turning = false;
    public int ID;
    public int Index=0;
    public bool direction;
	// Use this for initialization
	void Start ()
    {
        Tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Turn(direction);
	}
    public void Turn(bool direction)
    {
        if (turning)
        {
            if (!direction)
            {
                if (Index < 45)
                {
                    Tf.Rotate(0, 0, 1);
                    Index++;
                    return;
                }
                else
                {
                    Index = 0;
                    turning = false;
                    return;
                }
            }
            else
            {
                if (Index < 45)
                {
                    Tf.Rotate(0, 0, -1);
                    Index++;
                    return;
                }
                else
                {
                    Index = 0;
                    turning = false;
                    return;
                }
            }
        }
        return;

    }
    public void Turn_Left()
    {
        direction = false;
        turning = true;
        return;
    }
    public void Turn_Right()
    {
        direction = true;
        turning = true;
        return;
    }
    private void OnMouseDown()
    {
        Debug.Log(ID);
    }
}
