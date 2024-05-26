using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D box2D;
    private Vector2 colliderSize;
    private Vector2 colliderOffset;
    // Start is called before the first frame update
    void Start()
    {
        colliderSize = box2D.size;
        colliderOffset = box2D.offset;

    }

    // Update is called once per frame
    void Update()
    {

        PlayerInput();
    }

    void PlayerInput()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(speed);
        }
        transform.localScale = scale;

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

        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);      // Play the jump animation
        }
        else if (vertical < 0)
        {
            animator.SetBool("Jump", false);
        }
    }



}//class





