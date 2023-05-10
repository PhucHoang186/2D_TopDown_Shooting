using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectZone : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enemy.SetPlayerInRange(true, col.transform);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enemy.SetPlayerInRange(false);
        }
    }
}
