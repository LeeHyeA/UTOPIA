using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource SE;
    public AudioSource BGM;
    public int SE_Number = 0;
    public int BGM_Number = 1;
    bool isChanging = false;
    // Use this for initialization
    void Start () {
        BGM_ListPlay();
        BGM.loop = true;
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
            //거미줄 창문에 붙일때
            case 3:
                AudioClip LdresserOpen = Resources.Load("Sound/Stage1/SE/UseItem2") as AudioClip;
                SE.PlayOneShot(LdresserOpen);
                break;
            //씨앗심었을시 & 씨앗 얻었을시
            case 4:
                AudioClip PlantSeed = Resources.Load("Sound/Stage1/SE/PlantSeed") as AudioClip;
                SE.PlayOneShot(PlantSeed);
                break;
            //물뿌리개사용 and 하마한테서 물채워질시
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
            //일반적인 아이템 얻는 소리
            case 9:
                AudioClip GetItem = Resources.Load("Sound/Stage1/SE/GetItem") as AudioClip;
                SE.PlayOneShot(GetItem);
                break;
            //커튼 여닫는 소리
            case 10:
                AudioClip OpenCurtain = Resources.Load("Sound/Stage1/SE/OpenCurtain") as AudioClip;
                SE.PlayOneShot(OpenCurtain);
                break;
            //새지저귐 효과음
            case 11:
                AudioClip BirdCage = Resources.Load("Sound/Stage1/SE/BirdCage") as AudioClip;
                SE.PlayOneShot(BirdCage);
                break;
            //아이템 사용시 (샤샥) -like 칼소리
            case 12:
                AudioClip UseItem = Resources.Load("Sound/Stage1/SE/UseItem") as AudioClip;
                SE.PlayOneShot(UseItem);
                break;
            //물뿌리개 얻었을시
            case 13:
                AudioClip GetWateringcan = Resources.Load("Sound/Stage1/SE/GetWateringcan") as AudioClip;
                SE.PlayOneShot(GetWateringcan);
                break;
            //양머리 칼로 자를시
            case 14:
                AudioClip MeatSlap = Resources.Load("Sound/Stage1/SE/MeatSlap") as AudioClip;
                SE.PlayOneShot(MeatSlap);
                break;
            //아이템 놓았을시 (테이블에다가) & 돌을 모닥불에 놓기 & 새장에 모이,먹이놓기 & 이름표 동화책에 놓기
            case 15:
                AudioClip PutItem = Resources.Load("Sound/Stage1/SE/PutItem") as AudioClip;
                SE.PlayOneShot(PutItem);
                break;
            //금시계침 사용 및 얻음
            case 16:
                AudioClip UseGoldNeedle = Resources.Load("Sound/Stage1/SE/UseGoldNeedle") as AudioClip;
                SE.PlayOneShot(UseGoldNeedle);
                break;
            //망치사용
            case 17:
                AudioClip UseHammer = Resources.Load("Sound/Stage1/SE/UseHammer") as AudioClip;
                SE.PlayOneShot(UseHammer);
                break;


            // *************************************************************** 3Stage

            // 꽃이 필때
            case 300:
                AudioClip Flower = Resources.Load("Sound/Stage3/1Round/FinishFlower") as AudioClip;
                SE.PlayOneShot(Flower);
                break;

            // 재규어
            case 320:
                AudioClip Jaguar = Resources.Load("Sound/Stage3/3Round/Jaguar") as AudioClip;
                SE.PlayOneShot(Jaguar);
                break;

            // 좌물쇠 잠금 소리
            case 321:
                AudioClip Rock = Resources.Load("Sound/Stage3/3Round/Rock") as AudioClip;
                SE.PlayOneShot(Rock);
                break;

            // 오르골 소리
            case 322:
                AudioClip Orgel = Resources.Load("Sound/Stage3/3Round/Orgel") as AudioClip;
                SE.PlayOneShot(Orgel);
                break;

            // 문 여는 소리
            case 323:
                AudioClip Door = Resources.Load("Sound/Stage3/3Round/open-door") as AudioClip;
                SE.PlayOneShot(Door);
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
            /*
            //(1-1Defalut브금)
            case 1:
                ChangeBGM_Fun("Stage1/Bgm/Bgm(1-1Defalut)");
                break;
            */
            
            //(1-1Stage브금)
            case 2:
                ChangeBGM_Fun("Stage1/Bgm/Bgm(1-1)");
                break;
            /*
            //(1-2Defalut브금)
            case 3:
                ChangeBGM_Fun("Stage1/Bgm/Bgm(1-2Defalut)");
                break;
            */
            //(1-2Stage브금)
            case 4:
                ChangeBGM_Fun("Stage1/Bgm/Bgm(1-2)");
                break;

                
        //test2(모닥불사진브금)
            case 5:
                ChangeBGM_Fun("Stage1/Bgm/Picture(BonFire)");
                break;
            //test3(바다사진브금)
            case 6:
                ChangeBGM_Fun("Stage1/Bgm/Picture(Sea)");
                break;
            //test4(테이블사진브금)
            case 7:
                ChangeBGM_Fun("Stage1/Bgm/Picture(Table)");
                break;

             /*
             //(1-3Defalut브금)
             case 10:
                ChangeBGM_Fun("Stage1/Bgm/Bgm(1-3Defalut)");
                 break;
             */

             //(1-3Stage브금)
             case 11:
                ChangeBGM_Fun("Stage1/Bgm/Bgm(1-3)");
                 break;

            // 3-1 BGM
            case 301:
                ChangeBGM_Fun("Stage3/1Round/3-1 BGM");
                break;

            // 3-2 BGM
            case 302:
                ChangeBGM_Fun("Stage3/2Round/3-2 BGM");
                break;

            // 3-3 BGM
            case 303:
                ChangeBGM_Fun("Stage3/3Round/3-3 BGM");
                break;

        }
    }
   
    public void ChangeBGM_Fun(string NextBGM)
    {
        if (isChanging)
            StopAllCoroutines();
        StartCoroutine(ChangeBGM(NextBGM));
    }
   IEnumerator ChangeBGM(string NextBGM)
    {
        isChanging = true;
        while (BGM.volume>0)
        {
            BGM.volume = BGM.volume - 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        BGM.Stop();

        AudioClip Nextclip = Resources.Load("Sound/" + NextBGM) as AudioClip;

        BGM.clip = Nextclip;
        BGM.Play();

        while (BGM.volume < 1)
        {
            BGM.volume = BGM.volume + 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
