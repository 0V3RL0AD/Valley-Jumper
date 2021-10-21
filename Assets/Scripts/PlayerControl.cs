using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;

    public float TimeOfPress;
    public float TimeOfRelease;

    private float HeldTime;

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
            playerRigidbody.velocity = Vector3.up * JumpForce * HeldTime;
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
