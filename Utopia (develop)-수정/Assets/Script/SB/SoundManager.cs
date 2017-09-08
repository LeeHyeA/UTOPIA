using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource SE;

    public int BgmNum;
    // Use this for initialization
    void Start () {
        //if 효과음일때
        //SE = GetComponent<AudioSource>();
        // AudioClip GoatMilk = (AudioClip)Resources.Load("Sound/Stage1/SE/GoatMilk");
        //AudioClip GoatMilk = Resources.Load("Sound/Stage1/SE/GoatMilk")as AudioClip;
        //SE.PlayOneShot(GoatMilk);
    }

    // Update is called once per frame
    void Update () {
       // SE_List();  update로하면 계속재생해서 소리가 버벅이면서 끊김 한번만 실행해야됨
    }

    public int SE_Number = 0;

    
    public void SE_List()
    {
        SE = GetComponent<AudioSource>();
        AudioClip GoatMilk = Resources.Load("Sound/Stage1/SE/GoatMilk") as AudioClip;
        switch (SE_Number)
        {
            //염소젖얻었을시
            case 1:
                SE.PlayOneShot(GoatMilk);
                break;
        }
    }
    
   
}
