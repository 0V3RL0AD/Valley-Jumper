using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Animator anim;

    public int newterraintrigger = 500;
    public GameObject Terrain;

    public GameObject GroundSensor;
    public bool isGrounded;

    public float MoveSpeed;
    public float JumpForce;

    public float TimeOfPress;
    public float TimeOfRelease;

    private float HeldTime;
    private float HeldJumpForce;

    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        playerRigidbody = GetComponent<Rigidbody>();

        isGrounded = true;


    }

    // Update is called once per frame
    void Update()
    {
        //Player continuous movement in positive X direction
        playerRigidbody.velocity = new Vector3(MoveSpeed, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
        
        if (isGrounded == true)
        {
            anim.SetBool("Grounded", isGrounded);
        }

        if (isGrounded == false)
        {
            anim.SetBool("Grounded", isGrounded);
        }

        
        if ((playerRigidbody.velocity.y <= -30) && (isGrounded == false))
        {
            SceneManager.LoadScene("Main Scene");
        }

        if (Mathf.RoundToInt(transform.position.x) == newterraintrigger)
        {
            Instantiate(Terrain, new Vector3(transform.position.x + 500, 0, 0), Quaternion.identity);
            newterraintrigger += 1000;
        }



    }

    public void jumpButton()
    {
        if(isGrounded == true)
        {
            HeldTime = TimeOfRelease - TimeOfPress;

            if (HeldTime < 0.5)
            {
                HeldJumpForce = 0.5f;
            }
            else if(HeldTime > 1.25)
            {
                HeldJumpForce = 1.25f;
            }
            else
            {
                HeldJumpForce = HeldTime;
            }
            playerRigidbody.velocity = Vector3.up * JumpForce * HeldJumpForce;
        }
    }

    
    public void JumpPressed()
    {
        TimeOfPress = Time.time;
    }

    public void JumpReleased()
    {
        TimeOfRelease = Time.time;
    }
    
    public void OnCollisionEnter(Collision ground)
    {
        if (ground.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    public void OnTriggerStay(Collider ground)
    {
        if (ground.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    public void OnTriggerExit(Collider ground)
    {
        if (ground.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }


    public void OnCollisionExit(Collision ground)
    {
        if (ground.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }





}
