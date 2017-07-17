using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicPuzzle : MonoBehaviour
{

    GameObject[] Tile_Obj = new GameObject[100];
    public Tile[] t = new Tile[100];

    public GameObject LogicPuzControl;
    public bool Activated = false;
    // Use this for initialization
    void Start()
    {
        LogicPuzControl.SetActive(true);
        for (int i = 0; i < 100; i++)
        {
            Tile_Obj[i] = GameObject.Find("Tile (" + (i + 1).ToString() + ")");
            t[i] = Tile_Obj[i].GetComponent<Tile>();
        }
        LogicPuzControl.SetActive(false);

        t[12].is_Cliked = true;
        t[13].is_Cliked = true;
        t[14].is_Cliked = true;
        t[15].is_Cliked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Activated)
        {
            LogicPuzControl.SetActive(false);
            return;
        }
        LogicPuzControl.SetActive(true);

        if (t[2].is_Cliked && t[3].is_Cliked && t[4].is_Cliked && t[5].is_Cliked && t[6].is_Cliked && t[7].is_Cliked && t[11].is_Cliked && t[12].is_Cliked && t[13].is_Cliked && t[14].is_Cliked && t[15].is_Cliked && t[16].is_Cliked && t[17].is_Cliked && t[18].is_Cliked
            && t[18].is_Cliked)
        {
            Debug.Log("정답");
            Activated = false;
        }
    }

    public void Clear_Tile()
    {
        for (int i = 0; i < 100; i++)
        {
            t[i].is_Cliked = false;
        }
        return;
    }
}
