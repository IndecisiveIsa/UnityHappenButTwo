using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float x = .5f;
    public float y = .5f;
    public float z = .5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = new Vector3(x,y,z);
        transform.Rotate(rot);
    }
}
