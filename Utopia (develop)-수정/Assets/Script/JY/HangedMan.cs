using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HangedMan : MonoBehaviour {

    // Use this for initialization

    public bool is_Turning=false;
    public bool Activated = false;
    public GameObject HangedMan_Control;
    public GameObject Answerd_obj;
    EventManager EM;
    public GameObject Exit_Button;
    public int stat=0;

    public bool Answerd=false;

	void Start ()
    {
        EM = FindObjectOfType<EventManager>();

    }

    // Update is called once per frame
    void Update ()
    {
        if (stat==0||Answerd)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
            GetComponent<BoxCollider2D>().enabled = true;

        if (Activated)
            Exit_Button.SetActive(true);
        else
            Exit_Button.SetActive(false);

    }

    public void Turning()
    {
        if (Answerd)
            return;
        if(!is_Turning)
            StartCoroutine("Rot");
        return;
    }
    IEnumerator Rot()
    {
        Debug.Log("코루틴시작");

        for (int i = 0; i < 45; i++)
        {
            HangedMan_Control.GetComponent<Transform>().Rotate(0, 0, 4);
            Debug.Log("중");
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("코루틴끝");
        stat = (stat + 1) % 2;
    }
    public void Turn_ON()
    {
        if (EM.Doing_Event)
            return;
        Activated = true;
        HangedMan_Control.SetActive(Activated);
        EM.Doing_Event = true;
        return;
    }
    public void Turn_OFF()
    {
        Activated = false;
        HangedMan_Control.SetActive(Activated);
        EM.Doing_Event = false;
        return;
    }

    public void Answer()
    {
        Debug.Log("밧줄콱");
        HangedMan_Control.GetComponent<Image>().sprite = Resources.Load<Sprite>("2_Stage/Hanged_Man_with_Rope");
        Answerd_obj.SetActive(true);
        Answerd_obj.GetComponent<Fade>().StartFade();
        Answerd = true;
    }
}
