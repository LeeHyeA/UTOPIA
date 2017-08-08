using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamCatcher : MonoBehaviour {
    public GameObject DreamCatcherCore;
    public GameObject Defalut;
    public GameObject Upgrade1_1;
    public GameObject Upgrade1_2;
    public GameObject Upgrade2;
    public GameObject Final;
    public GameObject ExitButton;

    public Image DreamCatcherEnter;

    //public bool IsZoomIn=false;

    //드림캐쳐 단계별 상태
    public int DreamCatcherState = 0;
    //0:기본상태
    //1:기본+깃털
    //2:기본+거미줄보석
    //3:기본+깃털+거미줄보석
    //4:기본+깃털+거미줄보석+별가루

	// Use this for initialization
	void Start () {
		
	}
	
    public void ShowDreamCatcher()
    {
        DreamCatcherCore.SetActive(true);
        //기본
        if (DreamCatcherState == 0)
        {
            Defalut.SetActive(true);
            Upgrade1_1.SetActive(false);
            Upgrade1_2.SetActive(false);
            Upgrade2.SetActive(false);
            Final.SetActive(false);
            ExitButton.SetActive(true);
            DreamCatcherEnter.sprite = Resources.Load<Sprite>("Stage1-1/EnterDreamCatcher/DreamCapture01");
            return;
        }
        //기본+깃털
        else if (DreamCatcherState == 1)
        {
            Defalut.SetActive(false);
            Upgrade1_1.SetActive(true);
            Upgrade1_2.SetActive(false);
            Upgrade2.SetActive(false);
            Final.SetActive(false);
            ExitButton.SetActive(true);
            DreamCatcherEnter.sprite = Resources.Load<Sprite>("Stage1-1/EnterDreamCatcher/DreamCapture02");
            return;
        }
        //기본+거미줄
        else if (DreamCatcherState == 2)
        {
            Defalut.SetActive(false);
            Upgrade1_1.SetActive(false);
            Upgrade1_2.SetActive(true);
            Upgrade2.SetActive(false);
            Final.SetActive(false);
            ExitButton.SetActive(true);
            DreamCatcherEnter.sprite = Resources.Load<Sprite>("Stage1-1/EnterDreamCatcher/DreamCapture03");
            return;
        }
        //기본+깃털+거미줄
        else if (DreamCatcherState == 3)
        {
            Defalut.SetActive(false);
            Upgrade1_1.SetActive(false);
            Upgrade1_2.SetActive(false);
            Upgrade2.SetActive(true);
            Final.SetActive(false);
            ExitButton.SetActive(true);
            DreamCatcherEnter.sprite = Resources.Load<Sprite>("Stage1-1/EnterDreamCatcher/DreamCapture04");
            return;
        }
        //기본+깃털+거미줄+별가루
        else if (DreamCatcherState == 4)
        {
            Defalut.SetActive(true);
            Upgrade1_1.SetActive(false);
            Upgrade1_2.SetActive(false);
            Upgrade2.SetActive(false);
            Final.SetActive(true);
            ExitButton.SetActive(true);
            DreamCatcherEnter.sprite = Resources.Load<Sprite>("Stage1-1/EnterDreamCatcher/DreamCapture05");
            return;
        }

    }

    public void ExitDreamCatcher()
    {
        DreamCatcherCore.SetActive(false);
    }


	// Update is called once per frame
	void Update () {
	}
}
