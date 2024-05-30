using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Coll
{
    public string name;
    public string tag;
    public bool collision_for_name;
    public float specific_damage;
}

public class Damage_Controller : MonoBehaviour
{
    public bool damaged_by_all;
    public float general_damage;


    [SerializeField]
    private List<Coll> names_colliders = new List<Coll>();

    [SerializeField]
    private Dictionary<string, float> names_colliders_name = new Dictionary<string, float>();

    [SerializeField]
    private Dictionary<string, float> names_colliders_tags = new Dictionary<string, float>();


    private Health_Controller _health;


    private void Awake()
    {
        if (!damaged_by_all)
        {
            foreach (Coll c in names_colliders)
            {
                if (c.collision_for_name) names_colliders_name.Add(c.name, c.specific_damage);
                else names_colliders_tags.Add(c.tag, c.specific_damage);
            }
        }
    }

    private void Start()
    {
        _health = GetComponent<Health_Controller>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float damage = general_damage;
        if (damaged_by_all)
        {
            _health.Hurt(general_damage);
        }
        else if (names_colliders_tags.TryGetValue(collision.gameObject.tag, out damage) || names_colliders_name.TryGetValue(collision.gameObject.name, out damage))
        {
            _health.Hurt(damage);
        }
    }
}
