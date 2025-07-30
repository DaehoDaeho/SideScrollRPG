using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpPower = 5.0f;
    private bool isGrounded = true;
    private int jumpCount = 0;
    public GameObject objText;
    public TextMeshProUGUI textMessage;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * h * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) == true && (isGrounded == true || jumpCount < 2))
        {
            Jump();
        }
    }

    void Jump()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
            ++jumpCount;
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            objText.SetActive(false);
        }
    }
}
