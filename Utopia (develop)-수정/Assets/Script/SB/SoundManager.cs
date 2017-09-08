using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource SE;
    public AudioSource BGM;
    public int SE_Number = 0;
    public int BGM_Number = 1;
    // Use this for initialization
    void Start () {
        BGM_ListPlay();

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


    public void SE_NumberSet(int num)
    {
        SE_Number = num;
    }

    public void SE_ListPlay()
    {
        SE = GetComponent<AudioSource>();
        switch (SE_Number)
        {
            //염소젖 얻었을시
            case 1:
                AudioClip GoatMilk = Resources.Load("Sound/Stage1/SE/GoatMilk") as AudioClip;
                SE.PlayOneShot(GoatMilk);
                break;
            //우측서랍 열었을시
            case 2:
                AudioClip RdresserOpen = Resources.Load("Sound/Stage1/SE/OpenDrawer2") as AudioClip;
                SE.PlayOneShot(RdresserOpen);
                break;
            //좌측서랍 열었을시
            case 3:
                AudioClip LdresserOpen = Resources.Load("Sound/Stage1/SE/OpenDrawer") as AudioClip;
                SE.PlayOneShot(LdresserOpen);
                break;
            //씨앗심었을시
            case 4:
                AudioClip PlantSeed = Resources.Load("Sound/Stage1/SE/PlantSeed") as AudioClip;
                SE.PlayOneShot(PlantSeed);
                break;
            //물뿌리개사용
            case 5:
                AudioClip Wateringcan = Resources.Load("Sound/Stage1/SE/Wateringcan") as AudioClip;
                SE.PlayOneShot(Wateringcan);
                break;
            //우유병 얻었을시
            case 6:
                AudioClip BottleGet = Resources.Load("Sound/Stage1/SE/BottleGet") as AudioClip;
                SE.PlayOneShot(BottleGet);
                break;
            //종이류 아이템 읽었을시
            case 7:
                AudioClip PaperRead = Resources.Load("Sound/Stage1/SE/PaperRead") as AudioClip;
                SE.PlayOneShot(PaperRead);
                break;
            //평범한 오브젝트(아무런 의미없는) 클릭시
            case 8:
                AudioClip ObjectClick = Resources.Load("Sound/Stage1/SE/ObjectClick") as AudioClip;
                SE.PlayOneShot(ObjectClick);
                break;
        }
    }

    public void BGM_NumberSet(int num)
    {
        BGM_Number = num;
    }

    public void BGM_ListPlay()
    {
        BGM = GetComponent<AudioSource>();
        switch (BGM_Number)
        {

            //(1-1Defalut브금)
            case 1:
                AudioClip Stage1Defalut = Resources.Load("Sound/Stage1/Bgm/Bgm(1-1Defalut)") as AudioClip;
                BGM.clip = Stage1Defalut;
                BGM.Play();
                BGM.loop = true;
                break;
            //(1-1Stage브금)
            case 2:
                AudioClip Stage1_1 = Resources.Load("Sound/Stage1/Bgm/Bgm(1-1)") as AudioClip;
                BGM.clip = Stage1_1;
                BGM.Play();
                BGM.loop = true;
                break;
            //(1-2Defalut브금)
            case 3:
                AudioClip Stage2Defalut = Resources.Load("Sound/Stage1/Bgm/Bgm(1-2Defalut)") as AudioClip;
                BGM.clip = Stage2Defalut;
                BGM.Play();
                BGM.loop = true;
                break;
            //(1-2Stage브금)
            case 4:
                AudioClip Stage1_2 = Resources.Load("Sound/Stage1/Bgm/Bgm(1-2)") as AudioClip;
                BGM.clip = Stage1_2;
                BGM.Play();
                BGM.loop = true;
                break;


            /*
        //test2(모닥불사진브금)
        case 5:
            AudioClip BonFire = Resources.Load("Sound/Stage1/Bgm/Picture(BonFire)") as AudioClip;
            BGM.clip = BonFire;
            BGM.Play();
            BGM.loop = true;
            break;
        //test3(바다사진브금)
        case 6:
            AudioClip Sea = Resources.Load("Sound/Stage1/Bgm/Picture(Sea)") as AudioClip;
            BGM.clip = Sea;
            BGM.Play();
            BGM.loop = true;
            break;
        //test4(테이블사진브금)
        case 7:
            AudioClip Table = Resources.Load("Sound/Stage1/Bgm/Picture(Table)") as AudioClip;
            BGM.clip = Table;
            BGM.Play();
            BGM.loop = true;
            break;
            */



            //(1-3Defalut브금)
            case 10:
                AudioClip Stage3Defalut = Resources.Load("Sound/Stage1/Bgm/Bgm(1-3Defalut)") as AudioClip;
                BGM.clip = Stage3Defalut;
                BGM.Play();
                BGM.loop = true;
                break;

            //(1-3Stage브금)
            case 11:
                AudioClip Stage1_3 = Resources.Load("Sound/Stage1/Bgm/Bgm(1-3)") as AudioClip;
                BGM.clip = Stage1_3;
                BGM.Play();
                BGM.loop = true;
                break;



        }
    }
    
   
}
