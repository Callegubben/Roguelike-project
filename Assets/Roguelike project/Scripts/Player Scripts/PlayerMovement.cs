using System.Collections;
using System.Collections.Generic;
using System;
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
    [SerializeField]
    private bool touchingInteractable = false;
    [SerializeField]
    private Interactable interactableObject;
    private Vector2 interactArea = new Vector2(1, 1.5f);
    private LayerMask interactables;

    private void Awake()
    {
        interactables = LayerMask.GetMask("Interactable");
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * stats.speed;
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(horizontalMove));
        CheckInteractArea();
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        if (Input.GetButtonDown("Interact") && touchingInteractable)
        {
            interactableObject.Interact();
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
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void OnLanding()
    {
        Debug.Log("Landed!");
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime , crouch, jump);
        jump = false;
    }
    private void CheckInteractArea()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, interactArea, 0, interactables);
        if (hits.Length > 0)
        {
            interactableObject = hits[0].gameObject.GetComponent<Interactable>();
            touchingInteractable = true;
        }
        else
        {
            touchingInteractable = false;
        }
    }
}
