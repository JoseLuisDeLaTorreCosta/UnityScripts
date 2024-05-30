using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RBMovement_Controller : MonoBehaviour
{
    Rigidbody rb;

    public float speed, jumpSpeed;

    bool jump;
    float movex, movey, movez;
    float rotatey;

    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<Rigidbody> (out rb))
        {
            rb = GetComponentInParent<Rigidbody>();
        }

        jump = true;
    }

    void Update()
    {
        moveHorizontal(movex, movez);
    }


    public void moveHorizontal(float movex, float movez)
    {
        Vector3 velocity = transform.forward * speed * movez + transform.right * speed * movex;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (jump)
        {
            rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
        }
    }

    public void MoveX(InputAction.CallbackContext ctx)
    {
        movex = ctx.ReadValue<float>();
    }

    public void MoveZ(InputAction.CallbackContext ctx)
    {
        movez = ctx.ReadValue<float>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = false;
        }
    }
}
