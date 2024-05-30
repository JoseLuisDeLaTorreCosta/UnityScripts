using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot_Controller : MonoBehaviour
{
    public GameObject bullet;
    public float FireRate = 0.5f;
    public float Range = 2f;


    private float timer;


    private Pulling_Controller _pulling_Controller;
    
    // Start is called before the first frame update
    void Start()
    {
        _pulling_Controller = FindAnyObjectByType<Pulling_Controller>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (Time.time >= timer)
        {
            GameObject x = _pulling_Controller.GetPooledObject(bullet.name);
            x.transform.position = gameObject.transform.position;
            x.transform.rotation = gameObject.transform.rotation;
            x.SetActive(true);
            x.GetComponent<Destroy_Controller>().StartDeactivation(Range);


            timer = Time.time + FireRate;
        }
    }


    public void PlayerShoot(InputAction.CallbackContext ctx)
    {
        Shoot();
    }
}
