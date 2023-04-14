using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State {idle, running, jumping, falling}
    private State state = State.idle;
    private Collider2D coll;
    Vector3 locationstart;
    public Text textscore;
    public static int score=0;
    public Transform life;
    public int lifenum = 5;
    [SerializeField] private LayerMask ground;
    [SerializeField] float speed = 10;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private AudioSource jumpsound;
    [SerializeField] private AudioSource damagesound;
    [SerializeField] private AudioSource deathsound;
    [SerializeField] private AudioSource diamonsound;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        locationstart = transform.position;
        score = PlayerController.score;
        textscore.text = " SCORE :" + score;   
        
    }
    private void Update()
    {
        Movement();
        AnimationState();
        anim.SetInteger("state", (int)state);
        textscore.text = " SCORE :" + score;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "save")
        {
            locationstart = collision.transform.position;
        }
        if (collision.gameObject.tag == "Diamon")
        {
            diamonsound.Play();
            score += 10;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {      
        if (collision.gameObject.tag == "Enemy")
        {
            if (state == State.falling)
            {
                score += 20;
                Destroy(collision.gameObject);
                damagesound.Play();
                Jump(false);
            }
            else
            {
                transform.position = locationstart;
               if(life.childCount>0)
                {
                    deathsound.Play();
                    Destroy(life.GetChild(0).gameObject);
                    lifenum--;
                }
            }
            if (lifenum <= 0)
            {
                SceneManager.LoadScene("DeathScene");
            }

        }
        if(collision.gameObject.tag =="dbjump")
        {
            jumpsound.Play();
            Jump(true);
        }
        if(collision.gameObject.tag == "dead")
        {
            if (life.childCount > 0)
            {
                deathsound.Play();
                transform.position = locationstart;
                Destroy(life.GetChild(0).gameObject);
                lifenum--;      
            }
            if (lifenum <= 0)
            {
                SceneManager.LoadScene("DeathScene");
            }
        }
        if (collision.gameObject.tag == "win")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");
        anim.SetFloat("dfaf",Mathf.Abs(hDirection));
        transform.position += new Vector3(hDirection, 0, 0)*Time.deltaTime*speed;
        if (hDirection < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        else if (hDirection > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
   
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            jumpsound.Play();
            Jump(false);
        }
    }

    private void Jump(bool dbjump)
    {
        if(dbjump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 15f);
            state = State.jumping;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
        }
    
    }

    private void AnimationState() {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f) { 
                state = State.falling;
            }
        }

       else if (state == State.falling) {
            if (coll.IsTouchingLayers(ground)) {
                state = State.idle;
            }       
        }     
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
   
}
