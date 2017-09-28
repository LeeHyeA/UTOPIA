using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyWordTrigger : MonoBehaviour {

    public KeyWord KW;
    public int ChapterIndex;
    public int KeywordNumber;
    // Use this for initialization
    private void Awake()
    {
        KW = FindObjectOfType<KeyWord>();
    }

    public void TriggerKeyword()
    {
        KW.AccquiredKeyword(ChapterIndex, KeywordNumber);
    }
}
