using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    /// Variables
    ///quesitons animation climbing over fence/inventory and 2d movement for game 

    public PickupType type;

    ///value of the pickups how much ammo or health 
    public int value;

    [Header("Bobbing Motion")]
    public float rotationSpeed;
    public float bobSpeed; 
    public float bobHeight; 
    private bool bobbingUp; 
    private Vector3 startPos; 

    /// Get audio for the pickup
    public AudioClip pickupSFX;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; 
    }

    public enum PickupType
    {
        Health,
        Ammo

    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>(); 


            switch(type)
            {
                case PickupType.Health: 
                player.GiveHealth(value); 
                break; 
                case PickupType.Ammo:
                player.GiveAmmo(value);
                break; 
                default:
                print("Type Not Accepted");
                break; 
            }
        /// keep audio outside of switch
        /// Refrence Audio Source on the player to play the pickup sound effect 
        other.GetComponent<AudioSource>().PlayOneShot(pickupSFX);
        /// Destroy the pickup 
        Destroy(GameObject); 

        }
    }

    // Update is called once per frame
    void Update()
    {
        /// Making rotation more consistant 
        /// Rotates the pickups on the Y-Axis
        transform.Rotation(Vector3.up, rotationSpeed * Time.deltaTime);

        Vector3 offset = (bobbingUp == true ? new Vector3 (o, bobHeight / 2, 0) : new Vector3(0, -bobHeight, 0)); 

        transform.position = Vector3MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        if(transform.position == startPos + offset)
            bobbingUp = !bobbingUp; 

    }

}
