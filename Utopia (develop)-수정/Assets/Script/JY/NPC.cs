using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
public class NPC : MonoBehaviour {

    public ControlDialogue CD;
    public JsonData normalConver;
    TextAsset normalConver_Text;
    public KeyWord KW;

    public Image Panel;
    public Image StandImage;

    public Text Conver;
    public Text Name;   

    public bool main_conver;

    int normalIndex;
    // Use this for initialization

    private void Awake()
    {
        normalConver_Text = Resources.Load<TextAsset>("Main/NPC/Normal");
        normalConver = JsonMapper.ToObject(normalConver_Text.text);
        normalIndex = normalConver["dialogues"].Count;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartConver(string Keyword)
    {
        /* CD.LoadJSON(normalConver);
         KW.KeyWordControl.SetActive(true);
     */
    }
}
