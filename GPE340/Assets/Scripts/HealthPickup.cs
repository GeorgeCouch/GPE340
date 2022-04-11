using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public float healAmount = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate Health (For some reason this stopped working in the Pickup Script
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }
    // Override OnPickup from Pickup script
    protected override void OnPickup()
    {
        //Get player
        GameObject player = GameObject.FindWithTag("Player");
        //Get Health component for player and add health
        player.GetComponent<Health>().currentHealth += healAmount;
        // Call OnPickup from Pickup.cs
        base.OnPickup();
    }
}
