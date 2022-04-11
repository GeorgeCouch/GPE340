using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Grip positions
    public Transform rightHandGrip;
    public Transform leftHandGrip;
    // Projectile being fired
    public GameObject Bullet;
    // Where projectile is fired from
    public Transform FirePoint;
    // projectile vars
    public float damageDone;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Overridable
    public virtual void OnTriggerPull ()
    {
        Debug.Log("pewpewpew");
    }

    // Overridable
    public virtual void OnTriggerRelease()
    {
        Debug.Log("...");
    }
}
