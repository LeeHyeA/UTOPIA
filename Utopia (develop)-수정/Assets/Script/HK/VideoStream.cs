using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoStream : MonoBehaviour {

    //public RawImage image;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;




    void Start()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();

        videoPlayer.Play();


    }

    void Update()
    {
        if (!videoPlayer.isPlaying)
        {
            if (videoPlayer.transform.name == "PrologueVideo")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
                PlayerPrefs.SetInt("StartMain", 1);
            }

            ///if (videoPlayer.transform.name == "EndVideo")
            ///    Application.Quit();
        }
    }


}
