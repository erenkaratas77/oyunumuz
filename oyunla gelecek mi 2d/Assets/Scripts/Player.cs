using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ParticleSystem teleport;
    public ParticleSystem gravity;
    public ParticleSystem portal;

    Rigidbody2D myRigidbody;
    bool isGround = false;
    bool facingRight = true;
    bool isRun = false;
    bool isJump = false;
    bool isDead = false;
    public AudioSource torchSound;

    bool changeGravityDown = false;

    [SerializeField] GameObject sarkıt1;
    //public AudioSource sesZıplama;
    //public AudioSource buEngeller;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
     
            if (!changeGravityDown)
            {


                if (myRigidbody.velocity.x < 0 && facingRight)
                {
                    facingRight = !facingRight;

                    transform.eulerAngles = new Vector3(0, 180, 0);



                }
                else if (myRigidbody.velocity.x > 0 && !facingRight)
                {
                    facingRight = !facingRight;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
            else
            {



                if (myRigidbody.velocity.x < 0 && facingRight)
                {
                    facingRight = !facingRight;

                    transform.eulerAngles = new Vector3(0, 0, 180);


                }
                else if (myRigidbody.velocity.x > 0 && !facingRight)
                {
                    facingRight = !facingRight;
                    transform.eulerAngles = new Vector3(0, 180, 180);
                }

            }
            if (Input.GetAxis("Horizontal") == 0)
            {
                isRun = false;
            }
            else
            {
                isRun = true;
            }
            if (Input.GetAxis("Vertical") == 0)
            {
                isJump = false;
            }
            else
            {
                isJump = true;
            }
            GetComponentInChildren<Animator>().SetBool("isRun", isRun);
            GetComponentInChildren<Animator>().SetBool("isJump", isJump);


        
    }
    private void FixedUpdate()
    {
        if (!isDead)
        {
            if (!changeGravityDown)
            {
                myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * 4f, myRigidbody.velocity.y, 0);

                if (Input.GetAxis("Vertical") > 0 && isGround)
                {
                    GameManager.instance.JumpSound();

                    myRigidbody.AddForce(new Vector2(0, 180));
                    isGround = false;

                }
            }
            else
            {

                myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * 4f, myRigidbody.velocity.y, 0);


                //myRigidbody.AddForce(new Vector2(0, 60));

                if (Input.GetAxis("Vertical") > 0 && isGround)
                {
                    GameManager.instance.JumpSound();

                    myRigidbody.AddForce(new Vector2(0, -180));
                    //transform.position = transform.position + new Vector3(0, -10, 0);
                    isGround = false;


                }
            }
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            GameManager.instance.Deneme();
        }

        //neden oncollisionstay yaptın burayı enter yapsak olur.
        if (collision.gameObject.tag == "border")
        {
            isDead = true;
            Debug.Log("sen varya bittin bittin");
            GameManager.instance.GameOver();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Teleport")
        {
            teleport.Play();
        }


        if (collision.gameObject.tag == "ChangeGravityDown" && !changeGravityDown)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);

            gravity.Play();
            changeGravityDown = true;
            //platformAfterGravityChange.gameObject.SetActive(true);
            myRigidbody.gravityScale = -1;

        }
        if (collision.gameObject.tag == "sarkıt1")
        {
            portal.Play();

            sarkıt1.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "ChangeGravityUp" && changeGravityDown)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

            gravity.Play();
            changeGravityDown = false;
            //platformAfterGravityChange.gameObject.SetActive(true);
            myRigidbody.gravityScale = 1;
            print("girdi");

        }
        if (collision.gameObject.tag == "buEngeller")
        {
            GameManager.instance.EngelSound();

        }
        if (collision.gameObject.tag == "torch")
        {
            GameManager.instance.torch();

        }
        if (collision.gameObject.tag == "torchSound")
        {
            torchSound.Play();
        }

    }

    
}
