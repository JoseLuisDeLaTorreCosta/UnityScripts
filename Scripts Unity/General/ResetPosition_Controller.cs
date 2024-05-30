using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition_Controller : MonoBehaviour
{
    public bool localPosition = true;
    
    Vector3 originalPos;
    Quaternion originalRot;


    private void Awake()
    {
        Setting();
    }

    public void Setting()
    {
        if (localPosition)
        {
            originalPos = gameObject.transform.localPosition;
            originalRot = gameObject.transform.localRotation;
        }
        else
        {
            originalPos = gameObject.transform.position;
            originalRot = gameObject.transform.rotation;
        }
    }

    

    public void Resetting()
    {
        if (localPosition)
        {
            transform.localPosition = originalPos;
            transform.localRotation = originalRot;
        }
        else
        {
            transform.position = originalPos;
            transform.rotation = originalRot;
        }
    }

    private void OnDisable()
    {
        Resetting();
    }
}
