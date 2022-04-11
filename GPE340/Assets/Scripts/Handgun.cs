using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for trigger pull
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnTriggerPull();
        }
        else
        {
            OnTriggerRelease();
        }
    }

    //override for OnTiggerPull in Weapon
    public override void OnTriggerPull()
    {
        ShootOneBullet();
        base.OnTriggerPull();
    }

    //override for OnTriggerRelease in Weapon
    public override void OnTriggerRelease()
    {
        base.OnTriggerRelease();
    }

    //Shoots a single bullet
    private void ShootOneBullet()
    {
        // Instantiate at fire point
        GameObject newBullet = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        // sets damage
        newBullet.GetComponent<Bullet>().damage = damageDone;
        // sends projectile forward
        newBullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.VelocityChange);
    }
}
