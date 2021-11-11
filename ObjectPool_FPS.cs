using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectpool : MonoBehaviour
{

    public GameObject objPrefab;

    public int createOnStart;

 ///Simpler name for lists are Arrays
    private List<GameObject> pooledObjs = new List<GameObject>()
    
    
    // Start is called before the first frame update
    void Start()
    {   // start point,  starting with zero counting loops needed to take
        // condition if its true run until its false and incremint by one each loop
        // for loops are good for repitition 

        for(int x=0; x < createOnStart; x++) 
        {
        CreateNewObject();
        }
        
    }

    GameObject CreateNewObject()
    {
         GameObject obj =  Instantiate(objPrefab); 
            obj.SetActive(false); //
            pooledObjs.Add(obj); // create a certain number of objects

            return obj;
    }
    /// Whenever we need object call to this function 

    public GameObject GetObject()
    {
        /// Collect all of the inactive pooled objects
        GameObject obj = pooledObjs.Find(x => x.activeInHierarchy)
        /// If the scene has zero active objects 
        if(obj == null)
        {
            obj = CreateNewObject();
        }

        /// Activate created objects
        obj.SetActive(true);
    }
}
