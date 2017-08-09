using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzleTile : MonoBehaviour {

    Transform Tf;
    public int Hor;    //가로
    public int Ver;    //세로

    public bool is_blank = false;

	// Use this for initialization
	void Start ()
    {
        Tf = GetComponent<Transform>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
