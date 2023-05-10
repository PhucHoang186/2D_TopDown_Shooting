using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTimeBetweenShot : MonoBehaviour
{
    [SerializeField] Image fillImage;
    float timeBetweenShoot;

    public void SetUp(float maxTime)
    {
        timeBetweenShoot = maxTime;
    }

    public void UpdateLoadUI(float currentLoadTime)
    {
        fillImage.fillAmount = currentLoadTime / timeBetweenShoot;
    }

}
