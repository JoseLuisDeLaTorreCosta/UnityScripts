using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interact_Controller : MonoBehaviour
{
    public float distanceInteraction;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject origin)
    {
        RaycastHit hit;
        if (Physics.Raycast(origin.transform.position, origin.transform.forward, out hit, distanceInteraction))
        {
            Action(hit);
        }
    }

    public abstract void Action(RaycastHit obj);
}
