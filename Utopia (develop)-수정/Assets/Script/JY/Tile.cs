using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tile : MonoBehaviour {

    public bool is_Cliked = false;

    Image Tile_Image;

	// Use this for initialization
	void Start ()
    {
        Tile_Image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (is_Cliked)
        {
            Tile_Image.color = new Color(0, 0, 0);
            return;
        }
        Tile_Image.color = new Color(255, 255, 255);
        return;
	}

    public void Clik()
    {
        is_Cliked = !is_Cliked;
    }
}
