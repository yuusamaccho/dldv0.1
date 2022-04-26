using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public Rigidbody player;
    //public Script_PlayerMovement Script_PM;

    private bool wPressed = false;
    private bool aPressed = false;
    private bool sPressed = false;
    private bool dPressed = false;

    public bool onAir = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        WASD_isMoving();
        WASD_Rotation();

       
    }

    private void FixedUpdate()
    {
        //Debug.Log("player rotacao: " + player.rotation);
    }

    void WASD_isMoving()
    {
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            if(onAir == false)
            {
                animator.SetBool("isRunning", true);
            }
            
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void JumpAnima()
    {
        animator.SetTrigger("isJumping");

    }
    
    void WASD_Rotation()
    {
        if(Input.GetKey("w") && wPressed == false)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            wPressed = true;
            aPressed = false;
            sPressed = false;
            dPressed = false;
        }

        if (Input.GetKey("a") && aPressed == false)
        {
            player.transform.rotation = Quaternion.Euler(0, -90, 0);
            wPressed = false;
            aPressed = true;
            sPressed = false;
            dPressed = false;
        }

        if (Input.GetKey("s") && sPressed == false)
        {
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
            wPressed = false;
            aPressed = false;
            sPressed = true;
            dPressed = false;
        }

        if (Input.GetKey("d") && dPressed == false)
        {
            player.transform.rotation = Quaternion.Euler(0, 90, 0);
            wPressed = false;
            aPressed = false;
            sPressed = false;
            dPressed = true;
        }
    }
}
