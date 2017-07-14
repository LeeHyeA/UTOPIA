using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
public class KeyPad_Puz : MonoBehaviour {

    public int number;

    Image X;
    
    void Start ()
    {
        X = GetComponent<Image>();
        
        number = 1;

        X.sprite = Resources.Load<Sprite>(number.ToString());
        Debug.Log("ww");
	}
	
	// Update is called once per frame
	void Update ()
    {
        X.sprite = Resources.Load<Sprite>(number.ToString());
    }
    public void plus()
    {
        if (number < 5)
        {
            number++;

            X.sprite = Resources.Load<Sprite>(number.ToString());
        }
        else
            number = 0;

     }
    public void minus()
    {
        if (number > 0)
        {
            number--;
            X.sprite = Resources.Load<Sprite>(number.ToString());
        }
        else
            number = 5;
    }
}
