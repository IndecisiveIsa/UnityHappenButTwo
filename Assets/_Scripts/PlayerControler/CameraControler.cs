using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    public Transform target;
    public Rigidbody rtarget;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = target.position - offset;
        transform.position = move;
        if(rtarget.velocity.z > 0 && transform.rotation.z != 90)
        {
        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
        if(rtarget.velocity.z < 0 && transform.rotation.z != -90)
        {
            transform.RotateAround(target.transform.position, Vector3.down, 20 * Time.deltaTime);
        }
    }
}
