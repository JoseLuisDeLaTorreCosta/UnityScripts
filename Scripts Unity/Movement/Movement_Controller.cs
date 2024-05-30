using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate(GameObject obj, Vector3 angle)
    {
        obj.transform.Rotate(angle);
    }

    public void Move(Vector3 dir)
    {
        transform.position += Time.deltaTime * dir * moveSpeed;
    }

    public void Move(Vector3 dir, float move)
    {
        transform.position += Time.deltaTime * dir * moveSpeed * move;
    }
}
