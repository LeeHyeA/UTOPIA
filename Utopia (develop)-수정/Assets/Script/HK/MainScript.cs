using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {


    // Use this for initialization
    void Start () {
		if (PlayerPrefs.GetInt ("StartMain", 0) == 1) {
			this.gameObject.transform.Find ("Panel(Start)").gameObject.SetActive (false);
			this.gameObject.transform.Find ("Panel").gameObject.SetActive (true);


        }
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void PrologueStart()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Prologue");
	}
}
