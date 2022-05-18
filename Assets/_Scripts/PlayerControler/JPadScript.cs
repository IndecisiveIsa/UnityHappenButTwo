using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPadScript : MonoBehaviour
{

    public float xForce;
    public float yForce;
    public float zForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddForce(xForce, yForce, zForce);
    }
}
