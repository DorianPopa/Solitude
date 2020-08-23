using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float runSpeed = 40f;
    
    
    private float _horizontalMove = 0f;
    private bool _jump = false;
    private bool _crouch = false;

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))    { _crouch = true; }
        else if (Input.GetButtonUp("Crouch")) { _crouch = false; }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", false);
    }

    public void OnFalling()
    {
        animator.SetBool("IsFalling", true);
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    
    private void FixedUpdate()
    {
        controller.Move(_horizontalMove * Time.deltaTime, _crouch, _jump);
        _jump = false;
    }
    
}
