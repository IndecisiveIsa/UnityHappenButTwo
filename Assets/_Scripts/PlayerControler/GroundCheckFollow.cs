using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckFollow : MonoBehaviour
{

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0, -.5f, 0);
        transform.position = target.position+offset; 
    }
}
