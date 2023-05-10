using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private static readonly string Roof_Covered ="Roof_Covered";
    private static readonly string Roof_UnCovered ="Roof_UnCovered";
    [SerializeField] GameObject roof;
    [SerializeField] Animator roofAnimator;
    [SerializeField] Door roomDoor;
    bool isPlayerIntheRoom;

    void Start()
    {
        roomDoor.SetRoom(this);
        ToggleRoofTop(true);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerIntheRoom = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerIntheRoom = false;
        }
    }

    public void ToggleRoofTop(bool isActive)
    {
        if(!isPlayerIntheRoom)
            if(isActive)
                roofAnimator.Play(Roof_Covered);
            else
                roofAnimator.Play(Roof_UnCovered);
    }
}
