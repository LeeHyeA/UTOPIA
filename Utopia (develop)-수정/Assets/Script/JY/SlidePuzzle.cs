using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzle : MonoBehaviour {
    
    int width = 191;
    int height = 206;

    public SlidePuzzleTile[,] Tiles = new SlidePuzzleTile[4,3];
    SlidePuzzleTile blank_Tile;

	// Use this for initialization
	void Start ()
    {

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Tiles[i, j] = gameObject.transform.GetChild(0).GetChild(0).GetChild((i * 3) + j).gameObject.GetComponent<SlidePuzzleTile>();
                Tiles[i, j].Hor = i;
                Tiles[i, j].Ver = j;
            }
        }
        blank_Tile = Tiles[3, 2];
        blank_Tile.is_blank = true;

        /*for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Debug.Log(Tiles[i, j]);
            }
        }*/

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void CheckDirection(SlidePuzzleTile SPT)
    {
        if (SPT.Ver == blank_Tile.Ver && SPT.Hor == blank_Tile.Hor)
            return;

        Debug.Log(SPT.Ver);
        Debug.Log(SPT.Hor);
        if (blank_Tile.Ver == SPT.Ver)
        {
            if (blank_Tile.Hor - SPT.Hor == 1)
            {
                SPT.triggerMoving(3);
            }
            else if (SPT.Hor - blank_Tile.Hor == 1)
            {
                SPT.triggerMoving(1);
            }
            else
                return;
        }

        if(blank_Tile.Hor==SPT.Hor)
        {
            if (blank_Tile.Ver - SPT.Ver == 1)
            {
                SPT.triggerMoving(2);
            }
            else if (SPT.Hor - blank_Tile.Hor == 1)
            {
                SPT.triggerMoving(0);
            }
            else
                return;
        }
        return;
    }
}
