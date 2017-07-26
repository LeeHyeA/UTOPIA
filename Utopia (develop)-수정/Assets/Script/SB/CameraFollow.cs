using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    void Start()
    {
        //offset = 카메라에서 플레이어까지의 거리
        offset = transform.position - target.position;
    }

    //void FixedUpdate()
    void Update()
    {
        //Debug.Log(transform.position);
        //카메라가 따라가는데 필요한 타켓의 위치
        Vector3 targetCamPos = target.position + offset;

        transform.position = targetCamPos;

        //부드럽게이동
        //transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        //LabA1 카메라 제한
        if ((transform.position.x != 0) && ((transform.position.y > -3) && (transform.position.y < 5)))
        {
            Vector3 v = transform.position;
            v.x = 0.0f;
            v.y = 0.0f;
            transform.position = v;
        }
        //창고 카메라 제한
        if ((transform.position.x != 0) && ((transform.position.y > 9) && (transform.position.y < 17)))
        {
            Vector3 v = transform.position;
            v.x = 0.0f;
            v.y = 12.0f;
            transform.position = v;
        }

        //mainfloor 카메라 제한
        //오른쪽
        if (((transform.position.x >= 32) && ((transform.position.y > -14) && (transform.position.y < -6))))
        {
            Vector3 vr = transform.position;
            vr.x = 32.0f;
            vr.y = -12.0f;
            transform.position = vr;
        }
        //왼쪽
        if (((transform.position.x <= 10.7) && ((transform.position.y > -14) && (transform.position.y < -6))))
        {
            Vector3 vl = transform.position;
            vl.x = 10.7f;
            vl.y = -12.0f;
            transform.position = vl;
        }

        if ((((transform.position.x <= 32) && (transform.position.x >= 10.7)) && ((transform.position.y > -14) && (transform.position.y < -6))))
        {
            Vector3 vu = transform.position;
            vu.y = -12.0f;
            transform.position = vu;
        }


        /*
        //좌표노가다 연습

        //만약 첫번째방 영역에 플레이어가 있으면
        if ((target.position.x >= -960 && target.position.x <= 960) && (target.position.y <= 540 && target.position.y >= -540))
        {
            
            Debug.Log("ok");
            //카메라 포지션을 그방에있을때는 고정
            Vector3 vl = transform.position;
            vl.x = 0.0f;
            transform.position = vl;
        }
        else
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        
        // else if()
        */
    }
}
