using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
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
        playerRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //Player continuous movement in positive X direction
        playerRigidbody.velocity = new Vector3(MoveSpeed, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
        
    }

    public void jumpButton()
    {
        if(playerRigidbody.velocity.y == 0)
        {
            HeldTime = TimeOfRelease - TimeOfPress;

            if (HeldTime < 0.5)
            {
                HeldJumpForce = 0.5f;
            }
            else if(HeldTime > 1.5)
            {
                HeldJumpForce = 1.5f;
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

}
