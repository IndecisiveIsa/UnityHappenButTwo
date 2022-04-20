using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    public static InputManager instance; //singleton

    Controls controls;

    //control data
    public Vector2 move;
    public bool jumpPressed = false;
    public bool movePressed = false;

    private void Awake()
    {

        if (instance == null)
        {
            //if instance is null, set it to this
            instance = this;

        }
        else
        {
            //if instance is not null, destroy this
            Destroy(this);
        }

        controls = new Controls();
        
    }

    private void OnEnable()
    {
       
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        //*params* => code to execute
        controls.Locamotion.Move.performed += obj => move = obj.ReadValue<Vector2>();
        controls.Locamotion.Move.performed += obj => movePressed = true;
        controls.Locamotion.Move.canceled += obj => movePressed = false;
        // the same as += obj => {
        // move = obj.ReadValue<Vector2>();
        // }

        //listen for jump press
        controls.Locamotion.Jump.performed += obj => jumpPressed = true;
        controls.Locamotion.Jump.canceled += obj => jumpPressed = false;
        
    }

}
