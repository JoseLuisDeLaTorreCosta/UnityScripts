using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractUser_Controller: Interact_Controller
{
    public GameObject cam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Action(RaycastHit obj)
    {
        if (obj.collider.gameObject.tag == "Key")
        {
            Destroy(obj.collider.gameObject);
        }
    }

    public void LaunchRaycast(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) Interact(cam);
    }
}
