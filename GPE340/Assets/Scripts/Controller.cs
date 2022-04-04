using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Designers can choose pawn, target, and speed
    public Pawn pawn;
    public Transform target;
    public float speed = 90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Pass controller positions to the move function
        pawn.Move(new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        // Gets look rotation between pawn and target
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position);
        // transforms pawn location in direction of target rotation over time
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
