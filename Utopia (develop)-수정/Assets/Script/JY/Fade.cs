using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

	// Use this for initialization
    public void StartFade()
    {
        StartCoroutine(Fading());
    }
    IEnumerator Fading()
    {
        Image AC = GetComponent<Image>();
        for (float i = 0; i <= 1; i += 0.01f)
        {
            AC.color = new Color(AC.color.r, AC.color.g, AC.color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
}
