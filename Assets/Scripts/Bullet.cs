using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDamage;
    [SerializeField] LayerMask collideLayer;
    private RaycastHit2D hit;

    void Start()
    {
        DestroyBullet(10f);
    }

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     DestroyBullet();
    // }

    private void DestroyBullet(float delayDestroyTime = 0)
    {
        StartCoroutine(CorDestroyBullet(delayDestroyTime));
    }

    private IEnumerator CorDestroyBullet(float delayDestroyTime)
    {
        yield return new WaitForSeconds(delayDestroyTime);
        this.gameObject.SetActive(false);
        Destroy(gameObject);

    }

    void Update()
    {
        hit = Physics2D.Raycast(transform.position, transform.up, bulletSpeed * Time.deltaTime, collideLayer);
        if (hit && hit.transform.gameObject != null)
        {
            DestroyBullet();
            var enemy = hit.transform.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.OnEnemyTakeDamage(bulletDamage);
            }
        }

        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime, Space.Self);
    }
}
