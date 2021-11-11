using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon: MonoBehaviour
{

    ///public code

    // public GameObject bulletPrefab; (old code)
    public Objectpool bulletPool; /// < (New code)
    public Transform muzzle; 

    ///Ammo 
    public int curAmmo; 
    public int maxAmmo
    public bool infiniteAmmo; 

    public float bulletSpeed;
    public float shootRate; /// cool down, reload, etc

    ///private code
    private float lastShootTime;
    private bool isPlayer;


    void private void Awake() 
    {
        //Disable cursor
        Cursor.lockState = CursorLockMode.Locked;

        if(GetComponent<PlayerController>())
            isPlayer = true; 
        
    }

    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate) /// can we shoot, cool down measure with time
        {
        If(curAmmo > 0 || infiniteAmmo == true)
        return true;
        }
        
        return false;
        
    }

    public void Shoot() ///Made public because so it is able to be accessed by other scripts
    { 
        // Cooldown
        lastShootTime = Time.time;
        curAmmo --;
        /// Creating an instance of the bullet prefab at muzzles position and rotation
        /// GameObject bullet = Instatiate(bulletPrefab,muzzle.position, muzzle.rotation); (old code)
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;
        
        ///add velocity to projectile
        bullet. GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
