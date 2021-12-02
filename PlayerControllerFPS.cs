using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 /// public classes 

    [Header("Stats")]
    public float moveSpeed;             // movement peed in units per second
    public float jumpForce;             // force applied forward 
    public int curHp;

    [Header("Mouse Look")]
    public float lookSensitivity;       // Mouse look Sensitivity 
    public float maxLookX;              // lowest down we can look 
    public float minLookX;               // highest up we can look 
    private float rotX;                 // Current x rotation  of the camera 

    private Camera camera;
    private Rigidbody rb; 
    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>(); 
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get Components 
        camera =  Camera.main;
        rb = GetComponent<Rigidbody>();

        /// Intialize UI
        GameUI.instance.UpdateHealthBar(curHp, maxHp);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    /// Giving health up to player maxHp when picked up 
    public void GiveHealth(int amountToGive)
    {
        curHp = Mathf.Clamp(curHp + amountToGive, 0, maxHp);
        GameUI.intance.UpdateHealthBar(curHp, maxHp);
    }
    /// Mathf.Clamp * contraining the funciton to given values 
    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.crAmmo + amountToGive, 0, weapon.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapon.CurAmmo,weapon.maxAmmo);
    }



    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();

    // Fire Button
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
              weapon.Shoot();
        }


        if(Input.GetButtonDown("Jump"))
           Jump();  
    //pause game when button is pressed
    if(GameManager.instance.gamePaused `== true)
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

    
        /// rb.velocity = new Vector3(x, rb.velocity.y, z)
        // Move direction relative to camera 
        Vector3 dir = transform.right * x + transform.forward * z;
        rb.velocity = dir;
        //Jump with direction
        dir.y = rb.velocity.y;


    }

    void Jump()
    {

     Ray ray = new Ray (transform.position, Vector3.down);

     if(Physics.Raycast(ray,1.1f))
     {
         // Add Force to jump
       rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
     }
     
    }

    

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX)
        camera.transform.localRotation = Quaternion.Euler(-rotx,0,0);
        transform.eulerAngles += Vector3.up * y; 
    }

    /// Applies damage to the player
     public void TakeDamage(int damage) 
    {
        curhp -= damage;
        
        if(curHp<= 0);
            Die();
    }

     /// if the players health is reduced to zero
    void Die()
    {
        GameManager.instance.LoseGame()
    
    }
}
