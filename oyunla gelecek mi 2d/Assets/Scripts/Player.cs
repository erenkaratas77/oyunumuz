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
    
    bool changeGravity = false;
    [SerializeField] GameObject platformAfterGravityChange;

    [SerializeField] GameObject sarkıt1;




    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!changeGravity)
        {


            if (myRigidbody.velocity.x < 0 && facingRight)
            {
                facingRight = !facingRight;

                transform.eulerAngles = new Vector3(0, 180,0);



            }
            else if (myRigidbody.velocity.x > 0 && !facingRight)
            {
                facingRight = !facingRight;
                transform.eulerAngles = new Vector3(0, 0,0);
            }
        }
        else
        {



            if (myRigidbody.velocity.x < 0 && facingRight)
            {
                facingRight = !facingRight;

                transform.eulerAngles = new Vector3(0, 0,180);


            }
            else if (myRigidbody.velocity.x > 0 && !facingRight)
            {
                facingRight = !facingRight;
                transform.eulerAngles = new Vector3(0, 180,180);
            }

        }
    }
    private void FixedUpdate()
    {
        if (!changeGravity) {
            myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * 3f, myRigidbody.velocity.y, 0);

            if (Input.GetAxis("Vertical") > 0 && isGround)
            {

                myRigidbody.AddForce(new Vector2(0, 165));
                isGround = false;


            }
        }
        else
        {

            myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * 3f, myRigidbody.velocity.y, 0);


            //myRigidbody.AddForce(new Vector2(0, 60));

            if (Input.GetAxis("Vertical") > 0 && isGround)
            {
                myRigidbody.AddForce(new Vector2(0, -165));
                //transform.position = transform.position + new Vector3(0, -10, 0);
                isGround = false;


            }
        } 
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Teleport")
        {
            teleport.Play();
        }
        if (collision.gameObject.tag == "ChangeGravity")
        {
            transform.eulerAngles = new Vector3(0, 0, 180);

            gravity.Play();
            changeGravity = true;
            //platformAfterGravityChange.gameObject.SetActive(true);
            myRigidbody.gravityScale = -1;

        }
        if (collision.gameObject.tag == "sarkıt1") { 
            portal.Play();
        
            sarkıt1.gameObject.SetActive(true);      
        }


    }
    
}
