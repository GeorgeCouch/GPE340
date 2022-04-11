using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This was working at one point for all pickups, however something caused it to break
        // Rotate Pickup
        //transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    // Check for player collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPickup();
        }
    }

    // base method for pickup
    protected virtual void OnPickup()
    {
        Destroy(gameObject);
    }
}
