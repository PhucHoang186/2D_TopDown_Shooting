using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform gunPoint;
    [SerializeField] Transform rightHandPoint;
    [SerializeField] Transform leftHandPoint;
    [SerializeField] GunData gunData;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] ParticleSystem muzzleFlash;
    int remainMegazine;

    public GunData GunData => gunData;
    public void SetUpHoldingGun(Transform rightHand, Transform leftHand)
    {
        rightHand.position = rightHandPoint.position;
        leftHand.position = leftHandPoint.position;
        remainMegazine = GunData.megazine;
    }

    public virtual void Shoot()
    {
        if (remainMegazine > 0)
        {
            PlayMuzzleflash();
            var newBullet = Instantiate(bulletPrefab);
            newBullet.transform.SetPositionAndRotation(gunPoint.position, gunPoint.rotation);
            remainMegazine--;
        }
    }

    private void PlayMuzzleflash()
    {
        // muzzleFlash.gameObject.SetActive(false);
        // muzzleFlash.gameObject.SetActive(true);
        muzzleFlash.Stop();
        muzzleFlash.Play();
    }

    public void Reload()
    {

    }

}

[Serializable]
public class GunData
{
    public bool isAuto;
    public int megazine;
    public float timeBetweenShoot;
}
