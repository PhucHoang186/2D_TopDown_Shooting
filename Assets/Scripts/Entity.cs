using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    protected float currentHealth;

    public virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealth(float healthAmount, Action cb = null)
    {
        currentHealth += healthAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (currentHealth <= 0)
        {
            cb?.Invoke();
        }
    }
    
    public void TakeDamage(float damageAmount,  Action cb = null)
    {
        UpdateHealth(damageAmount, cb);
    }
}
