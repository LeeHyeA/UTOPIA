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

    public Sprite[] ChapterImagesList = new Sprite[4];
    public Image ChapterImage;

    public string[] KeywordSummary;
    public Text[] CurrentKeywordSummary = new Text[3];

    int[] ActiveStatus;
    int[] ReadOnce;

    public Image[] NotRead = new Image[3];

    public int contents;

    public Text Pages;

    public int currentpages = 1;
    public int chapterindex= 1;
    public int endofpages;

    public TextAsset keywords;
    JsonData keywords_Json;

    // Use this for initialization
    private void Awake()
    {
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

    public void SetChapter()
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
            ActiveStatus = new int[size];
            ReadOnce = new int[size];
        }

        else
        {
            KeywordTitle = new string[contents];
            KeywordSummary = new string[contents];
            ActiveStatus = new int[contents];
            ReadOnce = new int[contents];
        }
        for (int i = 0; i < keywords_Json["KeyWord"][chapterindex - 1]["Contents"].Count; i++)
        {
            KeywordTitle[i] = keywords_Json["KeyWord"][chapterindex - 1]["Contents"][i]["KeywordTitle"].ToString();
            KeywordSummary[i] = keywords_Json["KeyWord"][chapterindex - 1]["Contents"][i]["KeywordSummary"].ToString();
            ActiveStatus[i] = int.Parse(keywords_Json["KeyWord"][chapterindex - 1]["Contents"][i]["isActive"].ToString());
            ReadOnce[i] = int.Parse(keywords_Json["KeyWord"][chapterindex - 1]["Contents"][i]["ReadYet"].ToString());
        }


        SetPage();
    }
    
    public void SetPage()
    {
        for (int i = 0; i < 3; i++)
        {
            if (ActiveStatus[i + ((currentpages * 3) - 3)] == 1)
            {
                CurrentKeywordTitle[i].text = "????";
                CurrentKeywordSummary[i].text = "???????";
                NotRead[i].color = new Color(NotRead[i].color.r, NotRead[i].color.g, NotRead[i].color.b, 0);
            }
            else
            {
                CurrentKeywordTitle[i].text = KeywordTitle[i + ((currentpages * 3) - 3)];
                CurrentKeywordSummary[i].text = KeywordSummary[i + ((currentpages * 3) - 3)];
                if (ReadOnce[i + ((currentpages * 3) - 3)] == 1)
                    NotRead[i].color = new Color(NotRead[i].color.r, NotRead[i].color.g, NotRead[i].color.b, 255);
                else
                    NotRead[i].color = new Color(NotRead[i].color.r, NotRead[i].color.g, NotRead[i].color.b, 0);
            }

        }
        Pages.text = currentpages.ToString() + "/" + endofpages.ToString();
    }

    public void SlectTopic(int index)
    {
        if (currentpages * 3 - (3 - index) > contents-1|| ActiveStatus[currentpages * 3 - (3 - index)]==1)
            return;
        string Conver;
        Conver = keywords_Json["KeyWord"][chapterindex - 1]["Contents"][currentpages * 3 - (3-index)]["Conver"].ToString();

        if (keywords_Json["KeyWord"][chapterindex - 1]["Contents"][currentpages * 3 - (3 - index)]["ReadYet"].ToString() == "1")
        {
            keywords_Json["KeyWord"][chapterindex - 1]["Contents"][currentpages * 3 - (3 - index)]["ReadYet"] = "0";
            SetChapter();
        }

        Debug.Log(Conver);

        KeyWordControl.SetActive(false);
        npcControl.TalkAboutKeyWord(Conver);
    }

    public void OpenKeyWord()
    {
        chapterindex = 1;
        SetChapter();
        KeyWordControl.SetActive(true);
    }
    public void CloseKeyWord()
    {
        KeyWordControl.SetActive(false);
    }
    public void AccquiredKeyword(int chapter, int number)
    {
        keywords_Json["KeyWord"][chapter - 1]["Contents"][number-1]["isActive"] = "0";
    }
}
