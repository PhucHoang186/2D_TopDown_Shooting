using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Entity
{

    [Header("References")]
    [HideInInspector] public bool isPlayerInRange;
    [SerializeField] protected Image healthBar;
    [Header("Params")]
    [SerializeField] protected float moveSpeed;
    protected Transform target;

    public void OnEnemyTakeDamage(float _damageAmount)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
        TakeDamage(-_damageAmount, OnBeingDestroyed);
        Debug.Log("take damage");
    }

    public virtual void OnBeingDestroyed()
    {
        Debug.Log(this.transform.name + " being destroyed");
    }

    public virtual void Attack()
    {

    }

    public virtual void Chasing()
    {

    }

    public void Update()
    {
        if (isPlayerInRange)
        {
            Chasing();
        }
    }

    public void SetPlayerInRange(bool _isPlayerInRange, Transform _target = null)
    {
        isPlayerInRange = _isPlayerInRange;
        target = _target;
    }
}
