using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepPrinter : MonoBehaviour
{
    [SerializeField] GameObject footStepPrefab;
    [SerializeField] float footStepDistance;
    [SerializeField] float widthStep;
    [SerializeField] float footStepDuration;
    Vector3 previousPos;
    Vector3 footStepPos;
    bool isLeftFoot;

    void Update()
    {
        if (Vector3.Distance(transform.position, previousPos) >= footStepDistance)
        {
            var newFootStep = Instantiate(footStepPrefab);
            footStepPos = transform.position;
            footStepPos.x = transform.position.x + (isLeftFoot ? -widthStep : widthStep);
            newFootStep.transform.SetPositionAndRotation(footStepPos, transform.rotation);
            previousPos = transform.position;
            isLeftFoot = !isLeftFoot;
            Destroy(newFootStep, footStepDuration);

        }
    }
}
