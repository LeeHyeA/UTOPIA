using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tile : MonoBehaviour {
    AudioManager AM;
    public bool is_Cliked = false;
    public bool Xmarkerd = false;

    Image Tile_Image;
    Sprite origin;
    Sprite Xmark;
    LogicPuzzle LP;

	// Use this for initialization
	void Start ()
    {
        AM = FindObjectOfType<AudioManager>();
        Tile_Image = GetComponent<Image>();
        LP = FindObjectOfType<LogicPuzzle>();
        Xmark = Resources.Load<Sprite>("2_Stage/Xmark");
        origin = Tile_Image.sprite;
	}
	
	// Update is called once per frame
	void Update () {
        if (is_Cliked&&!Xmarkerd)
        {
            Tile_Image.color = new Color(0, 0, 0);
            return;
        }
        Tile_Image.color = new Color(255, 255, 255);
        return;
	}

    public void Clik()
    {
        if (LP.Answerd || Xmarkerd)
            return;
        else
            is_Cliked = !is_Cliked;
        return;
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (is_Cliked || LP.Answerd)
                return;
            Xmarkerd = !Xmarkerd;
            if (Xmarkerd)
            {
                Tile_Image.sprite = Xmark;
            }
            else
                Tile_Image.sprite = origin;
        }
    }
    public void clear()
    {
        is_Cliked = false;
        Xmarkerd = false;
        Tile_Image.sprite = origin;
    }
}