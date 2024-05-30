using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPS_Controller : MonoBehaviour
{
    public GameObject cam;
    public Vector2 sensibility;

    float rotateHor, rotateVert;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateHor != 0)
        {
            transform.Rotate(Vector3.up * rotateHor * sensibility.x);
        }

        if (rotateVert != 0)
        {
            float angle = (cam.transform.localEulerAngles.x - rotateVert * sensibility.y + 360) % 360;
            if (angle > 180) angle -= 360;
            angle = Mathf.Clamp(angle, -80, 80);
            cam.transform.localEulerAngles = Vector3.right * angle;
        }
    }

    public void RotateHor(InputAction.CallbackContext ctx)
    {
        rotateHor = ctx.ReadValue<float>();
    }

    public void RotateVert(InputAction.CallbackContext ctx)
    {
        rotateVert = ctx.ReadValue<float>();
    }
}
