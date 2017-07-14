using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicPuzzle : MonoBehaviour {

    GameObject[] Tile_Obj = new GameObject[100];
    public Tile[] t = new Tile[100];

    public GameObject LogicPuzControl;
    public bool Activated = false;
	// Use this for initialization
	void Start ()
    {
        LogicPuzControl.SetActive(true);
        for (int i=0;i<100;i++)
        {
            Tile_Obj[i] = GameObject.Find("Tile (" + (i+1).ToString() + ")");
            t[i] = Tile_Obj[i].GetComponent<Tile>();
        }
        LogicPuzControl.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!Activated)
        {
            LogicPuzControl.SetActive(false);
            return;
        }
        LogicPuzControl.SetActive(true);

        if (t[0].is_Cliked && t[1].is_Cliked && t[2].is_Cliked && t[3].is_Cliked)
        {
            Debug.Log("정답");
            Activated = false ;
        }
	}

    public void Clear_Tile()
    {
        for(int i=0;i<100;i++)
        {
            t[i].is_Cliked = false;
        }
        return;
    }
}
