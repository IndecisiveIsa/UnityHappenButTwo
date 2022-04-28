using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    public Transform target;
    public Rigidbody rtarget;

    private Vector3 offset;
    private Vector3 cameraFollowVelocity = Vector3.zero;

    public float followSpeed = .1f;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, target.position - offset, ref cameraFollowVelocity, Time.deltaTime / followSpeed);
        transform.position = targetPosition;
        if (rtarget.velocity.z > 0)
        {
        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
        if(rtarget.velocity.z < 0)
        {
            transform.RotateAround(target.transform.position, Vector3.down, 20 * Time.deltaTime);
        }
        transform.rotation.z.Equals(Mathf.Clamp(transform.rotation.z, -90, 90));

    }
}
