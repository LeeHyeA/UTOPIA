﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicPuzzle : MonoBehaviour
{

    GameObject[] Tile_Obj = new GameObject[100];
    public Tile[] t = new Tile[100];

    EventManager EM;

    public GameObject LogicPuzControl;
    public bool Activated = false;
    public bool Answerd = false;

    // Use this for initialization
    void Start()
    {
        EM = FindObjectOfType<EventManager>();
        LogicPuzControl.SetActive(true);
        for (int i = 0; i < 100; i++)
        {
            Tile_Obj[i] = GameObject.Find("Tile (" + (i + 1).ToString() + ")");
            t[i] = Tile_Obj[i].GetComponent<Tile>();
        }
        LogicPuzControl.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!Activated||Answerd||EM.Doing_Event)
        {
            return;
        }


        if (t[2].is_Cliked && t[3].is_Cliked && t[4].is_Cliked && t[5].is_Cliked && t[6].is_Cliked && t[7].is_Cliked 
            && t[11].is_Cliked && t[12].is_Cliked && t[13].is_Cliked && t[14].is_Cliked && t[15].is_Cliked && t[16].is_Cliked && t[17].is_Cliked && t[18].is_Cliked
            && t[21].is_Cliked&& t[24].is_Cliked && t[25].is_Cliked && t[26].is_Cliked && t[27].is_Cliked && t[28].is_Cliked && t[29].is_Cliked
            && t[30].is_Cliked && t[31].is_Cliked && t[32].is_Cliked && t[33].is_Cliked && t[34].is_Cliked && t[38].is_Cliked 
            && t[40].is_Cliked && t[42].is_Cliked && t[45].is_Cliked && t[46].is_Cliked && t[47].is_Cliked && t[48].is_Cliked && t[49].is_Cliked
            && t[50].is_Cliked && t[51].is_Cliked && t[52].is_Cliked && t[53].is_Cliked && t[54].is_Cliked && t[59].is_Cliked 
            && t[60].is_Cliked && t[61].is_Cliked && t[64].is_Cliked && t[66].is_Cliked && t[67].is_Cliked && t[68].is_Cliked
            && t[72].is_Cliked && t[79].is_Cliked && t[80].is_Cliked && t[81].is_Cliked && t[82].is_Cliked && t[86].is_Cliked
            && t[93].is_Cliked && t[96].is_Cliked)
        {
            if(t[0].is_Cliked || t[1].is_Cliked || t[8].is_Cliked || t[9].is_Cliked
                || t[10].is_Cliked || t[19].is_Cliked
                || t[20].is_Cliked || t[22].is_Cliked || t[23].is_Cliked
                || t[35].is_Cliked || t[36].is_Cliked || t[37].is_Cliked || t[39].is_Cliked
                || t[41].is_Cliked || t[43].is_Cliked || t[44].is_Cliked
                || t[55].is_Cliked || t[56].is_Cliked || t[57].is_Cliked || t[58].is_Cliked
                || t[62].is_Cliked || t[63].is_Cliked || t[65].is_Cliked || t[69].is_Cliked
                || t[70].is_Cliked || t[71].is_Cliked || t[73].is_Cliked || t[74].is_Cliked || t[75].is_Cliked || t[76].is_Cliked || t[77].is_Cliked || t[78].is_Cliked
                || t[83].is_Cliked || t[84].is_Cliked || t[85].is_Cliked || t[87].is_Cliked || t[88].is_Cliked || t[89].is_Cliked
                || t[90].is_Cliked || t[91].is_Cliked || t[92].is_Cliked || t[94].is_Cliked || t[95].is_Cliked || t[97].is_Cliked || t[98].is_Cliked || t[99].is_Cliked)
            {
                return;
            }
            Debug.Log("정답");
            Answerd = true;

            return;
        }
    }

    public void On_Off()
    {
        Activated = !Activated;
        LogicPuzControl.SetActive(Activated);
        return;
    }
    public void Clear_Tile()
    {
        if (!Answerd)
        {
            for (int i = 0; i < 100; i++)
            {
                t[i].is_Cliked = false;
            }
        }
        return;
    }
}
