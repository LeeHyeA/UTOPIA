using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlayerMovement : MonoBehaviour {
    public GameObject MazePuzzlePlayer;
    public GameObject MazePuzzle;
    public float directionX = 0;
    public float directionY = 0;
    public float movespeed = 2.0f;
    public bool IsMoving = true;
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        Move();


    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MazeMapGoal")
        {

            Debug.Log("골인");
            //MazePlayer에 있는 MazePlayerMovement 스크립트의 InitPlayerPosition함수 호출
            GameObject.Find("MazePlayer").GetComponent<MazePlayerMovement>().InitPlayerPosition();
            //미로종료
            MazePuzzle.SetActive(false);
            
            //IsMoving = false;
        }
        // 만약 트리거 상태의 오브젝트와 충돌했을때
        
        /*
        if (other.transform.tag == "room1_door")
        {
            transform.localPosition = new Vector3(20, -1, 0);
        }
        */
        
        //만약 트리거 상태의 오브젝트와 충돌하고 충돌한 물체의 태그가 player일때 괄호안내용을 실행한다.
    }
    public void InitPlayerPosition()
    {
        // MazePuzzlePlayer.transform.Translate(-750f, -127f, 0f);
        MazePuzzlePlayer.GetComponent<RectTransform>().localPosition = new Vector3(-750, -127, 0);
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        /*
        if(Input.GetAxisRaw("Horizontal")<0)
        {
            moveVelocity = Vector3.left;
        }
        else if(Input.GetAxisRaw("Horizontal")>0)
        {
            moveVelocity = Vector3.right;
        }
        */
        if (IsMoving)
        {
            if (Input.GetKey(KeyCode.D))
            {
                directionX = 1;
                directionY = 0;
                transform.localScale = new Vector3(-1, 1, 1);
                transform.Translate(new Vector3(directionX, directionY, 0) * Time.deltaTime * movespeed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                directionX = -1;
                directionY = 0;
                transform.localScale = new Vector3(1, 1, 1);
                transform.Translate(new Vector3(directionX, directionY, 0) * Time.deltaTime * movespeed);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                directionX = 0;
                directionY = 1;
                transform.localScale = new Vector3(1, -1, 1);
                transform.Translate(new Vector3(directionX, directionY, 0) * Time.deltaTime * movespeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                directionX = 0;
                directionY = -1;
                transform.localScale = new Vector3(1, 1, 1);
                transform.Translate(new Vector3(directionX, directionY, 0) * Time.deltaTime * movespeed);
            }
        }

        //transform.position += moveVelocity * m
    }
}
