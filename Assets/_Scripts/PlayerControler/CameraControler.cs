using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    public Transform target;
    public GameObject gtarget;

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
    }
}
