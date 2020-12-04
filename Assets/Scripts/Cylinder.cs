using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)//event
    {
        
        if (!other.gameObject.name.Equals("Object_1(Clone)"))
        { 
            this.gameObject.AddComponent<FixedJoint>();
            Debug.Log("IM HERE");
        }
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
