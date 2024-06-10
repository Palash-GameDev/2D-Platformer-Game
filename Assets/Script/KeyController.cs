using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
   
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            SoundManager.Instance.Play(Sounds.KeyCollect);
            playerController.PickUpKey();
            
            Destroy(gameObject);
        }
        
    }
}
