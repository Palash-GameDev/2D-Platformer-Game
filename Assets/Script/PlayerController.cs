using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator animator;           
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed= Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(speed) );
        Vector3 scale = transform.localScale;
        if(speed < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if(speed > 0)
        {
            scale.x = Mathf.Abs(speed);
        }
        transform.localScale = scale;
    }



}//class




