using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour {

    public GameObject First;
    public GameObject Second;
    public GameObject Third;
    public GameObject Forth;
    public GameObject Contlorer;
    KeyPad_Puz first_;
    KeyPad_Puz second_;
    KeyPad_Puz third_;
    KeyPad_Puz forth_;

    EventManager EM;

    public bool Activated = false;
    public bool Answered = false;

    public string answer;
    public string qu;
    void Start ()
    {
        first_ = First.GetComponent<KeyPad_Puz>();
        second_ = Second.GetComponent<KeyPad_Puz>();
        third_ = Third.GetComponent<KeyPad_Puz>();
        forth_ = Forth.GetComponent<KeyPad_Puz>();

        EM = FindObjectOfType<EventManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Activated)
            return;
        else
        {
            Contlorer.SetActive(true);

            if (Answered)
            {
                Contlorer.SetActive(false);
                Activated = false;
                Answered = false;
                EM.Doing_Event = false;

                return;
            }
        } 
    }

    public void commit()
    {
        qu = first_.number.ToString() + second_.number.ToString() + third_.number.ToString() + forth_.number.ToString();

        if (qu == answer)
        {
            Answered = true;
            Debug.Log("정답");
            return;
        }
        else
        {
            Debug.Log("때앵");
            return;
        }
    }
    public void Exit_()
    {
        Contlorer.SetActive(false);
        Activated = false;
        EM.Doing_Event = false;
        return;
    }
}
