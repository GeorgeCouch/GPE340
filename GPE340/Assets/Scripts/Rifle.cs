using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    // vars for full auto delay
    public float timeNextShotIsReady;
    public float shotsPerMinute = 180;

    private void Awake()
    {
        // Define time on awake
        timeNextShotIsReady = Time.time;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for left mouse click
        if (Input.GetKey(KeyCode.Mouse0))
        {
            OnTriggerPull();
        }
        else
        {
            OnTriggerRelease();
        }
    }

    // Override OnTriggerPull from Weapon class
    public override void OnTriggerPull()
    {
        // If statement to control fire rate
        if (Time.time > timeNextShotIsReady)
        {
            ShootOneBullet();
            timeNextShotIsReady += 60f / shotsPerMinute;
        }
        base.OnTriggerPull();
    }

    // Override OnTriggerRelease from Weapon class
    public override void OnTriggerRelease()
    {
        // Reset time delay when trigger release
        if (Time.time > timeNextShotIsReady)
        {
            timeNextShotIsReady = Time.time;
        }
        base.OnTriggerRelease();
    }

    // Function to shoot a single bullet
    private void ShootOneBullet()
    {
        // Instantiate bullet at firepoint
        GameObject newBullet = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        // Set damage bullet will do
        newBullet.GetComponent<Bullet>().damage = damageDone;
        // propel bullet forward
        newBullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.VelocityChange);
    }
}
