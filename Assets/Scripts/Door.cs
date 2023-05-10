using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] Transform openIcon;
    [SerializeField] float openDuration;
    [SerializeField] float rotateAngle;
    [SerializeField] float rotateTime;
    [SerializeField] float closeDelayTime;
    [SerializeField] BoxCollider2D doorCollider;
    Room room;
    bool isOpening;
    bool isInteractZone;
    float currentDelayTime;

    void Start()
    {
        ToggleOpenIcon(false);
    }

    public void SetRoom(Room room)
    {
        this.room = room;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (!isOpening)
                ToggleOpenIcon(true);
            isInteractZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ToggleOpenIcon(false);
            isInteractZone = false;
        }
    }

    private void ToggleOpenIcon(bool isActive)
    {
        openIcon.gameObject.SetActive(isActive);
    }

    void Update()
    {
        ControlDoor();

        if (!isInteractZone) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(CorOpenDoor());
        }
    }

    private void ControlDoor()
    {
        if (currentDelayTime <= 0 && isOpening)
            CloseDoor();
        else if (currentDelayTime > 0)
            currentDelayTime -= Time.deltaTime;
    }

    IEnumerator CorOpenDoor()
    {
        OpenDoor();
        yield return new WaitForSeconds(openDuration);
        CloseDoor();
    }

    public void OpenDoor()
    {
        currentDelayTime = closeDelayTime;
        room?.ToggleRoofTop(false);
        isOpening = true;
        ToggleOpenIcon(false);
        doorCollider.enabled = false;
        transform.DORotate(Vector3.forward * rotateAngle, rotateTime);
    }

    public void CloseDoor()
    {
        isOpening = false;
        transform.DORotate(Vector3.zero, rotateTime).OnComplete(
            () =>
            {
                doorCollider.enabled = true;
                room?.ToggleRoofTop(true);
            }
        );
    }
}
