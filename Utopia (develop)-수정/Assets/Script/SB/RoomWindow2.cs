using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RoomWindow2 : MonoBehaviour {

    public Image WindowCurtainImage;
    // Use this for initialization
    void Start() {
        // WindowCurtainImage.sprite = Resources.Load<Sprite>("Stage1-3/Window/CurtainOpen");
    }
    
    //1:Open -1:Close
    public int IsCurtainOpen = 1;

    public bool PutFeedToOwlCage = false;

    // Update is called once per frame
    void Update() {

    }

    public void ChangeCurtainState()
    {
        IsCurtainOpen *= -1;
    }

    public void ChangeCurtain()
    {

        if (IsCurtainOpen==1)
        {
            WindowCurtainImage.sprite = Resources.Load<Sprite>("Stage1-3/Window/CurtainClose(Night)");
        }
        else if (IsCurtainOpen==-1)
        {
            WindowCurtainImage.sprite = Resources.Load<Sprite>("Stage1-3/Window/CurtainOpen");
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
                GameObject.Find("Event_Manager").GetComponent<EventManager>().Event_Number = 154;
                PutFeedToOwlCage = false;
            }
        }


    }
}
