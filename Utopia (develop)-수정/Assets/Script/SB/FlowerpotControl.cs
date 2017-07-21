using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerpotControl : MonoBehaviour {
    public GameObject FlowerLayer;

    // PSO : PlantStateObject
    public GameObject PSO_Carrot;
    public GameObject PSO_Foxtail;
    public GameObject PSO_Potato;
    public GameObject PSO_Banana;
    public GameObject PSO_Bean;


    //화분에 심어져있는 상태
    public bool IsPlantCarrot = false;
    public bool IsPlantFoxtail = false;
    public bool IsPlantPotato = false;
    public bool IsPlantBanana = false;
    public bool IsPlantBean = false;

    //씨앗 사용 여부
    public bool CarrotSeedUse = false;
    public bool FoxtailSeedUse = false;
    public bool PotatoSeedUse = false;
    public bool BananaSeedUse = false;
    public bool BeanSeedUse = false;


    void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    //추가할 사항
    //1.꽝작물(강아지풀,바나나,콩)을 심어버린경우 다시심으려면 커터칼로 잘라야한다.

    public void ShowFlowerpot()
    {
        FlowerLayer.SetActive(true);
        if(IsPlantCarrot)
        {
            //심어진 작물(당근)을 제외한 다른 작물은 해제상태로
            PSO_Carrot.SetActive(true);
            PSO_Foxtail.SetActive(false);
            PSO_Potato.SetActive(false);
            PSO_Banana.SetActive(false);
            PSO_Bean.SetActive(false);
            return;
        }
        else if(IsPlantFoxtail)
        {
            //심어진 작물(강아지풀)을 제외한 다른 작물은 해제상태로
            PSO_Carrot.SetActive(false);
            PSO_Foxtail.SetActive(true);
            PSO_Potato.SetActive(false);
            PSO_Banana.SetActive(false);
            PSO_Bean.SetActive(false);
            return;
        }
        else if (IsPlantPotato)
        {
            //심어진 작물(감자)을 제외한 다른 작물은 해제상태로
            PSO_Carrot.SetActive(false);
            PSO_Foxtail.SetActive(false);
            PSO_Potato.SetActive(true);
            PSO_Banana.SetActive(false);
            PSO_Bean.SetActive(false);
            return;
        }
        else if (IsPlantBanana)
        {
            //심어진 작물(바나나)을 제외한 다른 작물은 해제상태로
            PSO_Carrot.SetActive(false);
            PSO_Foxtail.SetActive(false);
            PSO_Potato.SetActive(false);
            PSO_Banana.SetActive(true);
            PSO_Bean.SetActive(false);
            return;
        }
        else if (IsPlantBean)
        {
            //심어진 작물(콩)을 제외한 다른 작물은 해제상태로
            PSO_Carrot.SetActive(false);
            PSO_Foxtail.SetActive(false);
            PSO_Potato.SetActive(false);
            PSO_Banana.SetActive(false);
            PSO_Bean.SetActive(true);
            return;
        }
    }

    public void ExitFlowerpot()
    {
        FlowerLayer.SetActive(false);
    }
}
