using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Ling;


public class EnemyAI : MonoBehaviour
{ 
    /// Int and float are data types 
    /// Enemy Stats 
    public int curHp, maxHp, scoreToGive; 
    ///Movement
    public float moveSpeed, attackRange, yPathOffset; 
    /// the below are class types
    /// Vector3 (Quardinate points setting a path in list)
    private List<Vector3> path; 
    /// Enemy weapon 
    private Weapon weapon; 
    /// Target to follow
    private GameObject target;



    // Start is called before the first frame update
    void Start()
    {
        /// Get the Components 
        weapon = GetComponent<Weapon>(); 
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHp = maxHp;
        
    }

    void UpdatePath()
    {
        /// Giving the AI a path to follow
        /// Calculate a path 
        /// Type = NavMeshPath, Variable = navMeshPath 
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);
        path = navMeshPath.corners.ToList();
    }

    voidChaseTarget()
    {
        if(path.Count == 0)
           return; 

        /// Move towards the closest path
        /// Taking the enemys position getting the starting point of the path and getting new Vector3s as we go while moving at a
        /// consistant rate with the rest of the game
        transform.position = Vector3.MoveTowards(transform.position,path[0] + new Vector3(0,yPathOffset,0), moveSpeed * Time.deltaTime)
        if(transform.position== path[0] + new Vector3(0,yPathOffset,0))
            path.RemoveAt(0);   

    }
    /// Applies damage to the enemy when the health hits 0 they die

    public void TakeDamage(int damage) 
    {
        curhp -= damage;
        
        if(curHp<= 0);
            Die();
        
        void Die()
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        ///Look at the Target 
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x,dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle; 

        /// Calculate the distance between the enemy and the player 
        float dist = Vector3.Distance(transform.position, target.transform.position); 
        /// if within attackrange attack player 
        if(dist <= attackRange)
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
        /// if enemy is too far away chase after player 
        else 
        {
            ChaseTarget();
        }
        
        
    }
}
