using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage; 
    public float lifetime;
    public gameObject hitParticle; 
    private float shootTime;

    

    void OnEnable()
    { 
        shootTime = Time.time; 
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        /// if hit deal out damage to the Player 
        if(other.CompareTag("Player"))
           other.GetComponent<PlayerController>().TakeDamage(damage);
        /// if hit deal out damage to the Enemy 
        else if(other.CompareTag("Enemy"))
             other.GetComponent<Enemy>().TakeDamage(damage);
        /// Disable Projectile for future use989+
        gameObject.Setactive(false);
        /// Create particle effect on hit
        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(obj, o.5f); 
    }
    
    // Update is called once per frame
    void Update()
    {
      if(Time.time - shootTime <= lifetime)  
           gameObject.SetActive(false); 

    }
}
