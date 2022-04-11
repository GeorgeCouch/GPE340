using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    // vars
    public float speed;
    private Animator anim;
    private Health health;
    public float sprintSpeed = 10f;
    // vars for weapon equip
    public GameObject equippedWeapon;
    public Transform attachmentPoint;
    private Transform RightGrabPoint;
    private Transform LeftGrabPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Get needed components
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        // Spawn with weapon
        EquipWeapon(equippedWeapon);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnAnimatorIK(int layerIndex)
    {
        // Place right hand
        if (RightGrabPoint != null)
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, RightGrabPoint.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            anim.SetIKRotation(AvatarIKGoal.RightHand, RightGrabPoint.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
        }

        // Place left hand
        if (LeftGrabPoint != null)
        {
            anim.SetIKPosition(AvatarIKGoal.LeftHand, LeftGrabPoint.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, LeftGrabPoint.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
        }
    }

    public void EquipWeapon(GameObject weapon)
    {
        // Spawn weapon
        equippedWeapon = Instantiate(weapon);
        // Attach weapon to palyer
        equippedWeapon.transform.SetParent(attachmentPoint);
        equippedWeapon.transform.localPosition = attachmentPoint.transform.localPosition;
        equippedWeapon.transform.localRotation = attachmentPoint.transform.localRotation;
        // Set hand positions
        RightGrabPoint = equippedWeapon.GetComponent<Weapon>().rightHandGrip;
        LeftGrabPoint = equippedWeapon.GetComponent<Weapon>().leftHandGrip;
    }

    // Destroy weapon and set equipped weapon to null
    public void Unequip()
    {
        if (equippedWeapon)
        {
            Destroy(equippedWeapon.gameObject);
            equippedWeapon = null;
        }
    }

    // DirectionToMove comes in WORLD space
    public void Move (Vector3 directionToMove)
    {
        // Convert my direction from WORLD space to LOCAL space
        directionToMove = transform.InverseTransformDirection(directionToMove);
        // Clamp (Set vector magnitude to 1)
        directionToMove = Vector3.ClampMagnitude(directionToMove, 1.0f);

        // If we are sprinting, increase our speed to sprint speed.
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            directionToMove *= sprintSpeed;
        }
        else
        {
            // Multiply by speed -- so we are now based on speed, not direction
            directionToMove *= speed;
        }

        // Pass the parameters to play the correct animation
        // THESE need to be in LOCAL space
        anim.SetFloat("Right", directionToMove.x);
        anim.SetFloat("Forward", directionToMove.z);
    }

    // This is what a pawn does when it Dies!
    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
