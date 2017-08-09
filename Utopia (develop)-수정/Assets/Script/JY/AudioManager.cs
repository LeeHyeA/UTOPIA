using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    AudioSource AS;
	// Use this for initialization
	void Start ()
    {
        AS = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}
    
    public void PlaySound(AudioClip AC)
    {
        AS.PlayOneShot(AC);
    }
}
