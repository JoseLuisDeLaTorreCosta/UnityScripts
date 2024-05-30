using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health_Controller : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public UnityEvent OnDie; //Declaraci�
    public UnityEvent OnAwake;
    public UnityEvent<float> OnUpdateHealth;

    private void Start()
    {
        OnSpawn();
    }

    private void OnDisable()
    {
        OnSpawn();
    }

    private void UpdateHealth()
    {
        OnUpdateHealth.Invoke(currentHealth);
    }

    public void OnSpawn()
    {
        OnAwake.Invoke();
        Heal();
    }


    public void Heal(float h)
    {
        currentHealth += h;

        if (currentHealth > maxHealth)
        {
            Heal();
        }

        UpdateHealth();
    }

    public void Heal()
    {
        currentHealth = maxHealth;
    }

    public void Hurt(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDie.Invoke(); //Invocaci�
        }

        UpdateHealth();
    }

    public void IncreaseMaxHealth(float inchealth)
    {
        maxHealth += inchealth;
    }
}
