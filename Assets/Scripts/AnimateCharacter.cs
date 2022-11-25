using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCharacter : MonoBehaviour
{
    // Animator variables
    private Animator anim;
    private string WALK_ANIMATION = "walk";
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        ThirdPersonMovement.PlayerWalkingInfo += PlayerWalkingListener;

    }

    void PlayerWalkingListener(bool isWalking)
    {
        if (isWalking)
        {
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
}
