using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamCatcher : MonoBehaviour {
    public GameObject DreamCatcherCore;
    public GameObject Defalut;
    public GameObject Upgrade1_1;
    public GameObject Upgrade1_2;
    public GameObject Upgrade2;
    public GameObject Final;
    public GameObject ExitButton;
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
        if (DreamCatcherState == 0)
        {
            Defalut.SetActive(true);
            Upgrade1_1.SetActive(false);
            Upgrade1_2.SetActive(false);
            Upgrade2.SetActive(false);
            Final.SetActive(false);
            ExitButton.SetActive(true);
            return;
        }
        else if (DreamCatcherState == 1)
        {
            Defalut.SetActive(false);
            Upgrade1_1.SetActive(true);
            Upgrade1_2.SetActive(false);
            Upgrade2.SetActive(false);
            Final.SetActive(false);
            ExitButton.SetActive(true);
            return;
        }
        else if (DreamCatcherState == 2)
        {
            Defalut.SetActive(false);
            Upgrade1_1.SetActive(false);
            Upgrade1_2.SetActive(true);
            Upgrade2.SetActive(false);
            Final.SetActive(false);
            ExitButton.SetActive(true);
            return;
        }
        else if (DreamCatcherState == 3)
        {
            Defalut.SetActive(false);
            Upgrade1_1.SetActive(false);
            Upgrade1_2.SetActive(false);
            Upgrade2.SetActive(true);
            Final.SetActive(false);
            ExitButton.SetActive(true);
            return;
        }
        else if (DreamCatcherState == 4)
        {
            Defalut.SetActive(true);
            Upgrade1_1.SetActive(false);
            Upgrade1_2.SetActive(false);
            Upgrade2.SetActive(false);
            Final.SetActive(true);
            ExitButton.SetActive(true);
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
