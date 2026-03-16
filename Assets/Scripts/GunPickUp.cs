using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public Gun gunscript;
    public Rigidbody rb;
    public BoxCollider col;
    public Transform player, Guncontainer;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;
    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            pickUp();
        }

        if(equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }

    private void pickUp()
    {
        equipped = true;

    }
}
