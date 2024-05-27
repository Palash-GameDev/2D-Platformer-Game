using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public Animator animator;
    public BoxCollider2D box2D;
    private Vector2 colliderSize;
    private Vector2 colliderOffset;
    private Rigidbody2D rb2D;
    public float jumpForce;

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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerInput(horizontal, vertical);
        MoveCharcter(horizontal, vertical);
    }
    private void MoveCharcter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * playerSpeed * Time.deltaTime;
        transform.position = position;

        if (vertical > 0)
        {
            rb2D.AddForce((Vector2.up * jumpForce), ForceMode2D.Force);
        }

    }
    void PlayerInput(float horizontal, float vertical)
    {

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

        if (vertical > 0)
        {
            animator.SetBool("Jump",true);
        }
        
        else 
        { 
            animator.SetBool("Jump",false);
        }
        // Crouch animation
        if (Input.GetKeyDown(KeyCode.LeftControl))
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





