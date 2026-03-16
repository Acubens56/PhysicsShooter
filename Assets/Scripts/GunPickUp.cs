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
            transform.SetParent(Guncontainer);
            transform.position = distanceToPlayer;
        }

        if(equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
            
        }
    }

    private void pickUp()
    {
        equipped = true;
        rb.isKinematic = true;
        col.isTrigger = true;
    }

    private void Drop()
    {
        equipped = false;
        rb.isKinematic = false;
        col.isTrigger = false;
    }
}
