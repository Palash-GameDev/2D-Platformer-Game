using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

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
    public float levelEndRange;
    private int maxLife = 3;
    public GameObject[] playerHeart;


    public ScoreController scoreController;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        maxLife = playerHeart.Length ;
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

        if (this.transform.position.y < levelEndRange)
        {
            SceneManager.LoadScene("Learn_GamePlay");
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

    public void PickUpKey()
    {
        Debug.Log("Key PickedUp!");
        scoreController.IncreaseScore(10);
    }

    public void DecreaseHealth()
    {
        if (maxLife > 1)
        {
           
            maxLife -= 1; // Decrease health by one.
            Destroy(playerHeart[maxLife].gameObject);
            Debug.Log("Decrease health by one.");

        }
        else
        {
            maxLife -= 1;
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        Debug.Log("Enemy Killed PLayer........");
        //animator.Play("Player_death");

        ReloadLevel();
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }



}//class





