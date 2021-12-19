using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    Animator anim;

    public TMP_Text ScoreText;
    public TMP_Text LivesText;

    public int newterraintrigger = 500;
    public GameObject Terrain;

    public GameObject SpawnPlatform;
    public GameObject[] CurrentPlatforms;

    public GameObject GroundSensor;
    public bool isGrounded;

    public float MoveSpeedBase;
    public float MoveSpeedLim;
    public float CMoveSpeed;
    public float JumpForce;

    public float TimeOfPress;
    public float TimeOfRelease;

    private int lives;
    private int CoinsThisRun;
    private static int CCoins;
    private int ScoreThisRun;

    public float JumpHeldTime;
    public float JumpForceMult;

    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        MoveSpeedBase = 6;
        MoveSpeedLim = 10;

        CMoveSpeed = MoveSpeedBase;

        anim = GetComponent<Animator>();

        playerRigidbody = GetComponent<Rigidbody>();

        isGrounded = true;

        lives = 2;
        CoinsThisRun = 0;
        ScoreThisRun = 0;

        InvokeRepeating("RunFaster", 25f, 25f);

    }

    // Update is called once per frame
    void Update()
    {
        //update score and lives ui text
        ScoreText.text = ScoreThisRun.ToString();
        LivesText.text = lives.ToString();

        //update score value
        ScoreThisRun = (Mathf.RoundToInt(transform.position.x) + 5) + (CoinsThisRun*100);

        //Player continuous movement in positive X direction
        playerRigidbody.velocity = new Vector3(CMoveSpeed, playerRigidbody.velocity.y, playerRigidbody.velocity.z);

        CurrentPlatforms = GameObject.FindGameObjectsWithTag("Platform");
        
        if (isGrounded == true)
        {
            anim.SetBool("Grounded", true);
        }

        if (isGrounded == false)
        {
            anim.SetBool("Grounded", false);
        }

        //when the players x pos reaches the same x pos as the terrain trigger, then create a new terrain and move the trigger 1000+ x
        if (Mathf.RoundToInt(transform.position.x) == newterraintrigger)
        {
            Instantiate(Terrain, new Vector3(transform.position.x + 500, -50, 0), Quaternion.identity);
            newterraintrigger += 1000;
        }

        //If the player has 10 or more coins and under 3 lives, then give the player an extra life and take 10 coins
        if ((CCoins >= 10) && (lives <= 2))
        {
            lives++;
            CCoins = CCoins - 10;
        }

    }

    public void RunFaster()
    {
        if (CMoveSpeed < MoveSpeedLim)
        {
            CMoveSpeed = CMoveSpeed + 0.5f;
        }
        else if (CMoveSpeed >= MoveSpeedLim)
        {
            CMoveSpeed = CMoveSpeed;
        }
        
    }




    //code for variable jump height, based on duration of button press
    public void jumpButton()
    {
        if(isGrounded == true)
        {
            JumpHeldTime = TimeOfRelease - TimeOfPress;

            if (JumpHeldTime < 0.5)
            {
                JumpForceMult = 0.5f;
            }
            else if(JumpHeldTime > 1.25)
            {
                JumpForceMult = 1.25f;
            }
            else
            {
                JumpForceMult = JumpHeldTime;
            }
            playerRigidbody.velocity = Vector3.up * JumpForce * JumpForceMult;
        }
    }
    
    //set jump button press time
    public void JumpPressed()
    {
        TimeOfPress = Time.time;
    }

    //set jump button release time
    public void JumpReleased()
    {
        TimeOfRelease = Time.time;
    }
    
    public void OnCollisionEnter(Collision col)
    {

        //If player collides with coin, then award points and destroy the coin
        if (col.gameObject.tag == "Coin")
        {
            CoinsThisRun++;
            ScoreThisRun++;
            CCoins++;
            Destroy(col.gameObject);
        }

    }

    public void OnTriggerEnter(Collider col)
    {

        //If player collides with KillZone, then either restart, or remove 1 life
        if (col.gameObject.tag == "KillZone")
        {
            if (lives >= 2)
            {
                CurrentPlatforms = GameObject.FindGameObjectsWithTag("Platform");
                for (var p = 0; p < CurrentPlatforms.Length; p++)
                {
                    Destroy(CurrentPlatforms[p]);
                    Debug.Log("Destroyed Platform " + p);
                }

                Instantiate(SpawnPlatform, new Vector3(transform.position.x, transform.position.y - 2, transform.position.z), Quaternion.identity);
                lives--;
            }
            else if (lives <= 1)
            {
                SceneManager.LoadScene("Main Scene");
                Debug.Log("You Died");
            }
        }
    }


    //if the ground sensor is colliding with a platform, the player is grounded
    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    //if the ground sensor is no longer colliding with a platform, the player is not grounded
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }


}
