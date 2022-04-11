using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunPickup : Pickup
{
    public GameObject handGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate Pickup
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    // Override OnPickup from Pickup script
    protected override void OnPickup()
    {
        //Get player
        GameObject player = GameObject.FindWithTag("Player");
        // Unequip current weapon
        player.GetComponent<Pawn>().Unequip();
        //Set equipped weapon to Handgun prefab
        player.GetComponent<Pawn>().EquipWeapon(handGun);
        // Call OnPickup from Pickup.cs
        base.OnPickup();
    }
}
