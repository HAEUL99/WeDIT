using UnityEngine;
using System.Collections;
using Photon.Bolt;

public class PlayerMovement3D : Photon.Bolt.EntityBehaviour<IPlayerState>
{
    private float moveSpeed = 5.5f;
    private float jumpForce = 3.5f;
    private float gravity = -9.8f;
    private Vector3 moveDirection;
    /*private Vector3 pPosition;
    private Vector3 pRotation;
    private Vector3 cPosition;
    private Vector3 cRotation;*/

    //private GameObject car;
    private CharacterController characterController;
    private Animator animator;

    private void Awake()
    {
        //car = GameObject.Find("car");
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        /*pPosition = transform.position;
        pRotation = transform.eulerAngles;
        cPosition = car.transform.position;
        cRotation = car.transform.eulerAngles;*/
    }
    private void Update()
    {
        float z = Input.GetAxisRaw("Horizontal");

        if (IsCheckGrounded() == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
        if (moveDirection.x != 0 || z != 0)
        {
            state.isWalking = true;
            animator.SetBool("isWalking", state.isWalking);
        }
        else
        {
            state.isWalking = false;
            animator.SetBool("isWalking", state.isWalking);
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        if (IsCheckGrounded())
        {
            state.isJumping = false;
            animator.SetBool("isJumping", state.isJumping);
        }
        else
        {
            state.isJumping = true;
            animator.SetBool("isJumping", state.isJumping);
        }
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }

    public void Rotation(float z)
    {
        transform.Rotate(new Vector3(0, z, 0));
    }

    public void JumpTo()
    {
        if (IsCheckGrounded() == true)
        {
            moveDirection.y = jumpForce;
        }
    }

    /*public void PositionInitialize()
    {
        characterController.enabled = false;
        transform.position = pPosition;
        transform.eulerAngles = pRotation;
        characterController.enabled = true;
        car.GetComponent<CharacterController>().enabled = false;
        car.transform.position = cPosition;
        car.transform.eulerAngles = cRotation;
        car.GetComponent<CharacterController>().enabled = true;
    }*/

    private bool IsCheckGrounded()
    {
        if (characterController.isGrounded) return true;
        var ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        var maxDistance = 0.1f;
        Debug.DrawRay(transform.position + Vector3.up * 0.1f, Vector3.down * maxDistance, Color.red);
        return Physics.Raycast(ray, maxDistance);
    }
}
