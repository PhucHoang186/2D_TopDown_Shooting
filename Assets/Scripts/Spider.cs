using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    public override void OnBeingDestroyed()
    {
        base.OnBeingDestroyed();
        Destroy(this.gameObject);
    }

    public override void Chasing()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
    }
}
