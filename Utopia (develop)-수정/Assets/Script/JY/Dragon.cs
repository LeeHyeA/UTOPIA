using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : PuzzleManager {

    public GameObject Trigger;
    public GameObject Answerd_obj;
    public bool Activated=false;

    public Vector2 First_pos;

    public Vector2 MousePos;

    public Vector2 Origin_pos;

    public bool Answerd=false;

    public EventManager EM;
	// Use this for initialization
	void Start ()
    {
        Origin_pos = gameObject.transform.position;
        gameObject.transform.position = new Vector2((gameObject.transform.position.x - 5)/10, gameObject.transform.position.y);
        EM = FindObjectOfType<EventManager>();
    }

    // Update is called once per frame
    void Update () {
	}

    private void OnMouseDown()
    {
        First_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDrag()
    {
        if (Answerd)
            return;
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 After_Mouse_pos;
        Debug.Log(gameObject.transform.position.x - Origin_pos.x);
        if (First_pos.x < MousePos.x)
        {
            if (gameObject.transform.position.x - Origin_pos.x > 0.5)
                return;
            After_Mouse_pos = MousePos - First_pos;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + After_Mouse_pos.x, gameObject.transform.position.y);
        }
        if (First_pos.x > MousePos.x) 
        {
            if (gameObject.transform.position.x - Origin_pos.x < -(0.5))
                return;

            After_Mouse_pos = First_pos - MousePos;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - After_Mouse_pos.x, gameObject.transform.position.y);
        }
        /*if (Origin_pos.x - gameObject.transform.position.x > 0.5 || Origin_pos.x - gameObject.transform.position.x < (-0.5))
            After_Mouse_pos = new Vector2(0,0);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - After_Mouse_pos.x, gameObject.transform.position.y);**/
        
        First_pos = MousePos;

    }
    private void OnMouseUp()
    {
        if (Answerd)
            return;
        if (gameObject.transform.position.x < Origin_pos.x + 0.1 && gameObject.transform.position.x > Origin_pos.x - 0.1)
        {
            gameObject.transform.position = Origin_pos;
            Answerd = true;
            Answerd_obj.SetActive(true);
        }
    }
    public void Turn_ON()
    {
        if (EM.Doing_Event)
            return;
        Activated = true;
        Trigger.SetActive(Activated);
        EM.Doing_Event = true;
        return;
    }
    public void Turn_OFF()
    {
        Activated = false;
        Trigger.SetActive(Activated);
        EM.Doing_Event = false;
        return;
    }
}
