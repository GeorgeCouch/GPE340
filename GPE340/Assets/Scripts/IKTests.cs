using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTests : MonoBehaviour
{
    //public Weapon weapon;
    public Transform grabPoint;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex)
    {
        //weapon.rightHandGrip
        if (grabPoint != null)
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, grabPoint.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            anim.SetIKRotation(AvatarIKGoal.RightHand, grabPoint.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
        }
        
    }
}
