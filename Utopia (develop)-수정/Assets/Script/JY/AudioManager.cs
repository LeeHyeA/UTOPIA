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

    public void PlayAudio(string name)
    {
        var addAS = this.gameObject.AddComponent<AudioSource>();
             
        AudioClip audio = Resources.Load("Soundd/" + name) as AudioClip;

        addAS.loop = false;
        addAS.PlayOneShot(audio); 
    }

    public void PlayBGM(string name)
    {
        AudioClip audio = Resources.Load("Soundd/" + name) as AudioClip;

        AS.loop = true;
        AS.PlayOneShot(audio);
    }

    public void StopBGM(string name)
    {
        AS.Stop();
    }
}
