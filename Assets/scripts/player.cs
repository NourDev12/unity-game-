using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    private bool isGrounded;
    public float speed;
    public float jump;
    private Rigidbody2D player_rigidbody;
    private float hdirection;
    private float vdirection;
    private Animator canimator;
    private int score;
    public Text ttext;
    private int hearts;
    public Text hearttext;
    private Vector3 respawn;
    public game_over gameov;
    // Start is called before the first frame update
    void Start()
    {
        respawn = transform.position;
        hearts = 3;
        score = 0;
        jump = 9f;
        speed = 7f;
        player_rigidbody = GetComponent<Rigidbody2D>();
        canimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vdirection = Input.GetAxis("Vertical");
        hdirection = Input.GetAxis("Horizontal");
        if (hdirection != 0)
        {
            player_rigidbody.velocity = new Vector2(hdirection * speed, player_rigidbody.velocity.y);
        }
        if (vdirection > 0 && isGrounded)
        {
            player_rigidbody.velocity = new Vector2(player_rigidbody.velocity.x, jump);
            isGrounded = false;
        }
        if (hdirection > 0)
            GetComponent<SpriteRenderer>().flipX = false;
        else if (hdirection < 0)
            GetComponent<SpriteRenderer>().flipX = true;

        canimator.SetFloat("speed", Mathf.Abs(hdirection * speed));
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            score += 5;
            ttext.text = "coins: " + score;
            collision.gameObject.SetActive(false);
        }
        else if (collision.tag == "Respawn")
        {
            hearts -= 1;
            hearttext.text = "lives:" + hearts;
            transform.position = respawn;
            if (hearts == 0) 
            {
                gameov.display(score);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "checkpoint")
        {
            respawn = transform.position;
        }
    }
}
