using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    // vars
    public float speed;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Double speed when shift held and undo when released
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
        }
    }

    // DirectionToMove comes in WORLD space
    public void Move (Vector3 directionToMove)
    {
        // Convert my direction from WORLD space to LOCAL space
        directionToMove = transform.InverseTransformDirection(directionToMove);
        // Clamp (Set vector magnitude to 1)
        directionToMove = Vector3.ClampMagnitude(directionToMove, 1.0f);

        // Multiply by speed -- so we are now based on speed, not direction
        directionToMove *= speed;

        // Pass the parameters to play the correct animation
        // THESE need to be in LOCAL space
        anim.SetFloat("Right", directionToMove.x);
        anim.SetFloat("Forward", directionToMove.z);
    }
}
