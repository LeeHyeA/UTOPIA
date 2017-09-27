using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
public class KeyWord : MonoBehaviour {

    public GameObject KeyWordControl;
    public NPC npcControl;

    public Text Chapter;

    public string[] KeywordTitle;
    public Text[] CurrentKeywordTitle = new Text[3];

    
    public string[] KeywordSummary;
    public Text[] CurrentKeywordSummary = new Text[3];

    public int contents;

    public Text Pages;

    public int currentpages = 1;
    public int chapterindex= 1;
    public int endofpages;

    TextAsset keywords;
    JsonData keywords_Json;

    // Use this for initialization
    private void Awake()
    {
        keywords = Resources.Load<TextAsset>("Main/NPC/KeyWord");
        keywords_Json = JsonMapper.ToObject(keywords.text);

        Pages.text = currentpages.ToString() + "/" + endofpages.ToString();
        SetChapter();
    }
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ControlPages(bool isNext)
    {
        if (isNext)
        {
            if (currentpages == endofpages)
                return;
            currentpages++;
            SetPage();
        }
        else
        {
            if (currentpages == 1)
                return;
            currentpages--;
            SetPage();
        }
    }
    public void ControlChapter(bool isNext)
    {
        if(isNext)
        {
            if (chapterindex == 3)
                return;
            chapterindex++;
            SetChapter();
        }
        else
        {
            if (chapterindex == 1)
                return;
            chapterindex--;
            SetChapter();  
        }
    }

    void SetChapter()
    {
        currentpages = 1;

        if (keywords_Json["KeyWord"][chapterindex - 1]["Contents"].Count % 3 == 0)
            endofpages = (keywords_Json["KeyWord"][chapterindex - 1]["Contents"].Count) / 3;
        else
            endofpages = ((keywords_Json["KeyWord"][chapterindex - 1]["Contents"].Count) / 3) + 1;    

        Chapter.text = keywords_Json["KeyWord"][chapterindex - 1]["Chapter"].ToString();

        contents = keywords_Json["KeyWord"][chapterindex - 1]["Contents"].Count;



        if (contents % 3 != 0)
        {
            int size = contents + (3 - (contents % 2));
            KeywordTitle = new string[size];
            KeywordSummary = new string[size];

            for (int i = 0; i < keywords_Json["KeyWord"][chapterindex - 1]["Contents"].Count; i++)
            {
                KeywordTitle[i] = keywords_Json["KeyWord"][chapterindex - 1]["Contents"][i]["KeywordTitle"].ToString();
                KeywordSummary[i] = keywords_Json["KeyWord"][chapterindex - 1]["Contents"][i]["KeywordSummary"].ToString();
            }
        }

        else
        {
            KeywordTitle = new string[contents];
            KeywordSummary = new string[contents];

            for (int i = 0; i < keywords_Json["KeyWord"][chapterindex - 1]["Contents"].Count; i++)
            {
                KeywordTitle[i] = keywords_Json["KeyWord"][chapterindex - 1]["Contents"][i]["KeywordTitle"].ToString();
                KeywordSummary[i] = keywords_Json["KeyWord"][chapterindex - 1]["Contents"][i]["KeywordSummary"].ToString();
            }
        }


        SetPage();
    }
    
    void SetPage()
    {
        for(int i=0;i<3;i++)
        {
            CurrentKeywordTitle[i].text = KeywordTitle[i + ((currentpages * 3)-3)];
            CurrentKeywordSummary[i].text = KeywordSummary[i + ((currentpages * 3) - 3)];
        }
        Pages.text = currentpages.ToString() + "/" + endofpages.ToString();
    }

    public void SlectTopic(int index)
    {
        string Conver;
        Conver = keywords_Json["KeyWord"][chapterindex - 1]["Contents"][currentpages * 3 - (3-index)]["Conver"].ToString();

        Debug.Log(Conver);
        npcControl.StartConver(Conver);
    }

}
