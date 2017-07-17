using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle_Puzzle_Tile : MonoBehaviour {

    Circle_Puzzle CP;

    public Circle_Puzzle_Tile CPT1;
    public Circle_Puzzle_Tile CPT2;

    public Image Ima;

    public bool clicked = false;

    Color origin_color;

    public int ID;

	// Use this for initialization
	void Start ()
    {
        CP = FindObjectOfType<Circle_Puzzle>();
        Ima = GetComponent<Image>();
        origin_color = Ima.color;
	}


    // Update is called once per frame

    private void Update()
    {
    }

    private void OnMouseDown()
    {
        if (CP.turning)
            return;
        CP.Selected_Piece = GameObject.Find("Circle_Tile" + ID.ToString());
        Ima.color = new Color(0, 144, 60);
        clicked = true;
        CPT1.clicked = false;
        CPT1.clear_color();
        CPT2.clicked = false;
        CPT2.clear_color();
        Debug.Log(ID);
    }
    private void OnMouseEnter()
    {
        Ima.color = new Color(0, 144, 60);
        Debug.Log("Enter");
        return;
    }
    private void OnMouseExit()
    {
        if(!clicked)
            clear_color();
        Debug.Log("EXit");
        return;
    }
    public void clear_color()
    {
        Ima.color = origin_color;
        return;
    }
}
