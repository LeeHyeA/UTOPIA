using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerControl : MonoBehaviour {

    protected Animator animator;
    public float directionX = 0;
    public float directionY = 0;
    public bool IsWalking = false;
    public float movespeed = 2.0f;
    public bool isdoor = false;
    public RectTransform t;

    //sound
    public AudioSource bgm;
    public AudioClip Walk;
    public AudioClip Door;

    public bool canMove;
    //public Transform ScreenFader;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
    /*
    //충돌이벤트 발생
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player") 
        transform.localPosition = new Vector3(22, 0, 0);
    }
    */

    
    void OnTriggerEnter2D(Collider2D other)
    {
        // 만약 트리거 상태의 오브젝트와 충돌했을때
        /*
        if (other.transform.tag == "room1_door")
        {
            transform.localPosition = new Vector3(20, -1, 0);
        }
        */
        //만약 트리거 상태의 오브젝트와 충돌하고 충돌한 물체의 태그가 player일때 괄호안내용을 실행한다.
    }

    //IEnumerator Warp()
    void Warp()
    {
       // Debug.Log("Collide success");
       /*
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        yield return StartCoroutine(sf.FadeToBlack());
        */

        gameObject.transform.position = t.position;
        Camera.main.transform.position = t.position;

    //    yield return StartCoroutine(sf.FadeToClear());
    }

    public void WalkSound()
    {
        if (canMove)
        {
            bgm = GetComponent<AudioSource>();
            bgm.PlayOneShot(Walk);
        }
        //transform.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (animator)
        {
            IsWalking = true;

            /*
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            
            //오른쪽
            if (h > 0)
            {
                directionX = 1;
                directionY = 0;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            //왼쪽
            else if (h < 0)
            {
                directionX = -1;
                directionY = 0;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (v > 0)
            {
                directionX = 0;
                directionY = 1;
            }
            else if(v<0)
            {
                directionX = 0;
                directionY = -1;
            }
            */
            if (canMove)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    directionX = 1;
                    directionY = 0;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    directionX = -1;
                    directionY = 0;
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    IsWalking = false;
                }
                if (IsWalking)
                {
                    transform.Translate(new Vector3(directionX, directionY, 0) * Time.deltaTime * movespeed);
                }
                animator.SetFloat("DirectionX", directionX);
                animator.SetFloat("DirectionY", directionY);
                animator.SetBool("IsWalking", IsWalking);

                if (isdoor)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        bgm = GetComponent<AudioSource>();
                        bgm.PlayOneShot(Door);
                        Warp();
                        //StartCoroutine(Warp());
                        //ScreenFader.gameObject.GetComponent<Image>().enabled = true;
                    }
                }
            }
        }
    }
}
