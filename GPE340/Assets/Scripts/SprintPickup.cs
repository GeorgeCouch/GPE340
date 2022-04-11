using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintPickup : Pickup
{
    // public var for permanent sprint increase
    public float sprintIncrease = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate Sprint Pickup (For some reason this stopped working in the Pickup Script
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    // Override OnPickup from Pickup script
    protected override void OnPickup()
    {
        //Get player
        GameObject player = GameObject.FindWithTag("Player");
        // Get Pawn Component and permanently increase the sprintspeed
        player.GetComponent<Pawn>().sprintSpeed += sprintIncrease;
        // Call OnPickup from Pickup.cs
        base.OnPickup();
    }
}
