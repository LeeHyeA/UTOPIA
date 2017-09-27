using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Linq;

public class SortGrid : MonoBehaviour {

    LinkedList<ChildItem> list = new LinkedList<ChildItem>();

   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void init(string a)
    {
        ChildItem item = new ChildItem(a);
    }

    //public void test()
    //{
    //    list.AddLast(false, "Head");
    //}
}



public class ChildItem
{
    public bool IsFull;
    public int ItemNum;
    public string ItemName;
    public bool OnDrag;

    public ChildItem()
    {
        IsFull = false;
        ItemNum = -1;
        ItemName = "";
        OnDrag = false;
    }

    public ChildItem(bool isfull, string iteminfo)
    {
        string number = iteminfo.Substring(0, 1);
        ItemNum = Convert.ToInt32(number);

        string name = iteminfo.Substring(2);
        ItemName = name;

    }

    public ChildItem(string iteminfo)
    {
        string number = iteminfo.Substring(0, 1);
        Debug.Log("number : " + number);
        ItemNum = Convert.ToInt32(number);

        string name = iteminfo.Substring(2);
        Debug.Log("name : " + name);
        ItemName = name;
    }

    public void Full(bool active)
    {
        IsFull = active;
    }

    public void Drag(bool active)
    {
        OnDrag = active;
    }

}
