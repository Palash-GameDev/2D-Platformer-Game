using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public Animator animator;
    public BoxCollider2D box2D;
    private Vector2 colliderSize;
    private Vector2 colliderOffset;
    private Rigidbody2D rb2D;
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask layerGround;
    private bool isTouchingGround;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

        colliderSize = box2D.size;
        colliderOffset = box2D.offset;

    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerGround);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        HorizontalMovement(horizontal);
        VerticalMovement(vertical);
        CrouchMovement();

        if (this.transform.position.y < -10)
        {
            SceneManager.LoadScene("GamePlay_Learning");
        }

    }

    void HorizontalMovement(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * playerSpeed * Time.deltaTime;
        transform.position = position;

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(horizontal);
        }
        transform.localScale = scale;

    }


    void VerticalMovement(float vertical)
    {
        if (vertical > 0 && isTouchingGround == true)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Crouch", false);

            // rb2D.AddForce((Vector2.up * jumpForce), ForceMode2D.Force);
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

    }
    void CrouchMovement()
    {
        // Crouch animation
        if (Input.GetKeyDown(KeyCode.LeftControl) && isTouchingGround == true)
        {
            animator.SetBool("Crouch", true);                    // Crouch animation playing
            box2D.offset = new Vector2(colliderOffset.x, colliderOffset.y / 2);       // Resize the offset
            box2D.size = new Vector2(colliderSize.x, colliderSize.y / 2);            // Resize the collider
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);             // Stop the crouch animation
            box2D.size = colliderSize;                  // Reset the collider size 
            box2D.offset = colliderOffset;
        }
    }

}//class





