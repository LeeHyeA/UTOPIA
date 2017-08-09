﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzle : MonoBehaviour {

    int width = 191;
    int height = 206;

    public SlidePuzzleTile[,] Tiles = new SlidePuzzleTile[4,3];

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

        Tiles[3, 2].is_blank = true;
        
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
}
