using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangedMan : MonoBehaviour {

    // Use this for initialization
    public GameObject A;
    public bool is_Turning=false;
    public bool Activated = false;
    public GameObject HangedMan_Control;
    EventManager EM;
    public int stat=0;

	void Start ()
    {
        EM = FindObjectOfType<EventManager>();
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    public void Turning()
    {
        if(!is_Turning)
            StartCoroutine("Rot");
        return;
    }
    IEnumerator Rot()
    {
        Debug.Log("코루틴시작");

        for (int i = 0; i < 45; i++)
        {
            A.GetComponent<Transform>().Rotate(0, 0, 4);
            Debug.Log("중");
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("코루틴끝");
        stat = (stat + 1) % 8;
    }
    public void On_Off()
    {
        Activated = !Activated;
        HangedMan_Control.SetActive(Activated);
        EM.Doing_Event = Activated;
        return;
    }
}
