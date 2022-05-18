using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    private Vector3 flipY;

    // Start is called before the first frame update
    void Start()
    {
    flipY = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    transform.localScale = flipY;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
