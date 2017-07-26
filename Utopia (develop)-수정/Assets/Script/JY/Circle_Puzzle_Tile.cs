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

    Transform T;
    public int tile_stats;

    Color origin_color;

    public int ID;

	// Use this for initialization
	void Start ()
    {
        T = GetComponent<Transform>();
        CP = FindObjectOfType<Circle_Puzzle>();
        Ima = GetComponent<Image>();
        origin_color = Ima.color;

        T.Rotate(0, 0, -(tile_stats * 45));

    }


    // Update is called once per frame

    private void Update()
    {
        if(CP.Answerd)
        {
            CPT1.Ima.color = origin_color;
            CPT2.Ima.color = origin_color;
        }
    }

    private void OnMouseDown()
    {
        if (CP.turning||CP.Answerd)
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
        if (CP.Answerd)
            return;
        Ima.color = new Color(0, 144, 60);
        Debug.Log("Enter");
        return;
    }
    private void OnMouseExit()
    {
        if(!clicked)
            clear_color();
        if (CP.Answerd)
            return;
        Debug.Log("EXit");
        return;
    }
    public void clear_color()
    {
        if (CP.Answerd)
            return;
        Ima.color = origin_color;
        return;
    }
}
