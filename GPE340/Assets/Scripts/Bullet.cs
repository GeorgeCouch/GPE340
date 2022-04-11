using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Check for collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>())
        {
            if (collision.gameObject.tag != "Player")
            {
                // take damage if health component found and gameObject doesn't hold player tag
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }
        // Destroy bullet
        Destroy(gameObject);
    }
}
