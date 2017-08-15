using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RoomWindow2 : MonoBehaviour {

    //public Image WindowCurtainImage;

    public Image Hammer;
    public Image Pot;
    public Image O_Empty;
    public Image O_Feed;
    public Image O_Full;
    public Image Clock;

    // Use this for initialization
    void Start() {
        // WindowCurtainImage.sprite = Resources.Load<Sprite>("Stage1-3/Window/CurtainOpen");
    }
    
    //1:Open(day) -1:Close(night)
    public int IsCurtainOpen = 1;

    public bool PutFeedToOwlCage = false;

    // Update is called once per frame
    void Update() {
        ChangeColor1_3();
    }

    void ChangeColor1_3()
    {

        if (IsCurtainOpen == -1)
        {
            Hammer.color = new Color32(99, 99, 99, 255);
            Pot.color = new Color32(99, 99, 99, 255);
            O_Empty.color = new Color32(99, 99, 99, 255);
            O_Feed.color = new Color32(99, 99, 99, 255);
            O_Full.color = new Color32(99, 99, 99, 255);
            Clock.color = new Color32(99, 99, 99, 255);
            // WindowCurtainImage.sprite = Resources.Load<Sprite>("Stage1-3/Window/CurtainClose(Night)");
        }
        else if (IsCurtainOpen == 1)
        {
            Hammer.color = new Color32(255, 255, 255, 255);
            Pot.color = new Color32(255, 255, 255, 255);
            O_Empty.color = new Color32(255, 255, 255, 255);
            O_Feed.color = new Color32(255, 255, 255, 255);
            O_Full.color = new Color32(255, 255, 255, 255);
            Clock.color = new Color32(255, 255, 255, 255);
            //WindowCurtainImage.sprite = Resources.Load<Sprite>("Stage1-3/Window/CurtainOpen");
        }
    }

    public void ChangeCurtainState()
    {
        IsCurtainOpen *= -1;
    }

    public void ChangeCurtain()
    {

        if (IsCurtainOpen==1)
        {
            // WindowCurtainImage.sprite = Resources.Load<Sprite>("Stage1-3/Window/CurtainClose(Night)");
        }
        else if (IsCurtainOpen==-1)
        {
            //WindowCurtainImage.sprite = Resources.Load<Sprite>("Stage1-3/Window/CurtainOpen");
        }
    }

    public void SetPutFeedToOwlCage()
    {
        PutFeedToOwlCage = true;
    }

    public void CheckPutFeedToOwlCage()
    {
        //커튼이 열릴때
        if (IsCurtainOpen==1)
        {
            //새장이 놓여있으면
            if (PutFeedToOwlCage)
            {
                //154번 이벤트 발생
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 152;
                PutFeedToOwlCage = false;
            }
        }


    }
}
