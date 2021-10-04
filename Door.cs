using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && gameManager.hasKey == true)
        {
            print("you unlock the door with the key");
            gameManager.isDoorLocked = false;

        }
        else
        {
            print("The Door is Locked. Look for the key if you actually want to get out!");
        }
    
    }
}