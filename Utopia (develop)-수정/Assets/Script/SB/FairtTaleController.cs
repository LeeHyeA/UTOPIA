using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FairtTaleController : MonoBehaviour {

    public GameObject OwlName;
    public GameObject TreeName;
    public GameObject RoseName;

    public GameObject OwlCol;
    public GameObject TreeCol;
    public GameObject RoseCol;

    public GameObject RoseSeed;
    public Image Page;

    public int PageNum = 1;

    public bool GetRoseSeed = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckPage();
    }

    public void GetRoseName()
    {
        GetRoseSeed = true;
    }

    public void CheckPage()
    {
        if(PageNum == 2 &&!RoseName.activeSelf && !GetRoseSeed)
        {
            RoseSeed.SetActive(true);
        }
        else
        {
            RoseSeed.SetActive(false);
        }

        if (PageNum == 1)
        {
            Page.sprite = Resources.Load<Sprite>("Stage1-3/FairyTale/01");
        }
        else if (PageNum == 2)
        {
            if (!RoseName.activeSelf)
            {
                Page.sprite = Resources.Load<Sprite>("Stage1-3/FairyTale/02(NotRose)");
                //RoseCol.SetActive(true);
                
            }
            else if (RoseName.activeSelf)
            {
                Page.sprite = Resources.Load<Sprite>("Stage1-3/FairyTale/02");
            }
        }
        else if (PageNum == 3)
        {
            if (!OwlName.activeSelf)
            {
                //OwlCol.SetActive(true);
                Page.sprite = Resources.Load<Sprite>("Stage1-3/FairyTale/03(NotOwl)");
            }
            else if (OwlName.activeSelf)
            {
                Page.sprite = Resources.Load<Sprite>("Stage1-3/FairyTale/03");
            }
        }
        else if (PageNum == 4)
        {
            if (!TreeName.activeSelf)
            {
                //TreeCol.SetActive(true);
                Page.sprite = Resources.Load<Sprite>("Stage1-3/FairyTale/04(NotTree)");
            }
            else if (TreeName.activeSelf)
            {
                Page.sprite = Resources.Load<Sprite>("Stage1-3/FairyTale/04");
            }
        }
        else if (PageNum == 5)
        {
            Page.sprite = Resources.Load<Sprite>("Stage1-3/FairyTale/05");
        }
    }

    public void PageUp()
    {
        if (PageNum < 5)
            PageNum += 1;
    }
    public void PageDown()
    {
        if (PageNum > 1)
            PageNum -= 1;
    }

    public void CheckCompleteFairtTale()
    {
        //모든 이름표 채웠을시
       if(OwlName.activeSelf && TreeName.activeSelf && RoseName.activeSelf)
        {
            Debug.Log("동화책 완성");
            GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 160;
        }
    }
}
