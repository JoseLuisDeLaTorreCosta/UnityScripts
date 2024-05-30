using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    private Movement_Controller _move;

    // Start is called before the first frame update
    void Start()
    {
        _move = GetComponent<Movement_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        _move.Move(gameObject.transform.forward);
    }
}
