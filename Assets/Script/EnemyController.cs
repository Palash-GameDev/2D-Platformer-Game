using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform[] patrolPoints;
    public int patrolDestination;


    void Update()
    {

        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position,patrolPoints[0].position)  <0.5f)
            {
                transform.localScale = new Vector3(-1,1,1);
                patrolDestination = 1;
            }
        }
        if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position,patrolPoints[1].position)  <0.5f)
            {
                transform.localScale = new Vector3(1,1,1);
                patrolDestination = 0;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();

        }

    }


}
