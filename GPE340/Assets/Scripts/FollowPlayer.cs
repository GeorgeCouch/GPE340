using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Allows for designers to choose what object to follow
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        // Moves camera towards 5 meters above player
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position + new Vector3(0, 5, 0), 10);
    }
}
