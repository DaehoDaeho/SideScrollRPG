using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;

    //public Sprite[] idleSprites;
    //public Sprite[] moveSprites;

    int state = 0;  // 0 : 대기, 1 : 이동.
    public SpriteRenderer sr;
    //int frame = 0;
    //float timer = 0.0f;
    //public float frameRate = 0.15f;

    public float speed = 5.0f;
    public float jumpPower = 5.0f;
    private bool isGrounded = true;
    private int jumpCount = 0;
    public GameObject objText;
    public TextMeshProUGUI textMessage;
    public AudioSource audioSource;

    List<int> number = new List<int>();

    private void Start()
    {
        // int 형 값을 저장할 수 있는 100개의 메모리 공간을 새로 할당하겠다.
        for(int i=0; i<100; i++)
        {
            number.Add(i + 1);
        }

        int value = number[49];
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        bool move = false;

        if(h != 0.0f)
        {
            state = 1;
            move = true;
        }
        else
        {
            state = 0;
        }

        transform.position += Vector3.right * h * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) == true && (isGrounded == true || jumpCount < 2))
        {
            Jump();
        }

        //timer += Time.deltaTime;
        //if(timer >= frameRate)
        //{
        //    timer = 0.0f;
        //    PlayAnimation();
        //}

        animator.SetBool("Move", move);
    }

    void Jump()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
            ++jumpCount;
            audioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        jumpCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            NPC npc = collision.gameObject.GetComponent<NPC>();
            if(npc != null)
            {
                textMessage.text = npc.message;
            }
            objText.SetActive(true);
        }
        else if(collision.gameObject.tag == "QuestObject")
        {
            QuestManager.Instance.CompleteQuest();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            objText.SetActive(false);
        }
    }

    void PlayAnimation()
    {
        //Sprite[] curArr = idleSprites;
        //if(state == 1)  // 현재 이동상태면.
        //{
        //    curArr = moveSprites;
        //}

        //frame = (frame + 1) % curArr.Length;
        //sr.sprite = curArr[frame];  // 현재 동작의 현재 프레임에 해당하는 스프라이트를 넣어준다.
    }
}
