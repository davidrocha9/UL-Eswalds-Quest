using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCharacter : MonoBehaviour
{
    // Animator variables
    private Animator anim;
    private string WALK_ANIMATION = "is_walking";
    private string JUMP_ANIMATION = "is_jumping";
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        ThirdPersonMovement.PlayerActionInfo += PlayerActionListener;
    }

    //update function
    void Update()
    {
        // if animation is not jumping, then set anim param to false
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            // check if animation is finished
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                anim.SetBool(JUMP_ANIMATION, false);
            }
        }
    }

    void PlayerActionListener(bool isWalking)
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
