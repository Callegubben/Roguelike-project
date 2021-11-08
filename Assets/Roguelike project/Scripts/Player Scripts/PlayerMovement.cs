using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public PlayerStats stats;
    public Animator animator;
    public Inventory inventory;

    float horizontalMove = 0f;
    bool jump = false;
    private bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * stats.speed;
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("IsCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("IsCrouching", false);
        }
        if (Input.GetButtonDown("ActivatePower"))
        {
            if (inventory.currentActivePower != null)
            {
                inventory.ActivateCurrentPower();
            }
            else
            {
                print("No item equipped");
            }
        }
    }

    public void OnLanding()
    {
       animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime , crouch, jump);
        jump = false;
    }
}
