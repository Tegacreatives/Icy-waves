using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimatorSpeed(float speed = 0)
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));
    }

    public void SetGameStarted()
    {
        print("Game Started");
    }
}
