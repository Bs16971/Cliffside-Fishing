using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator _anim;
    private  Vector3 movement;
    public void Initialize()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void UpdateAnimatorValues(float x, float y)
    {
        _anim.SetFloat("x",x, .1f, Time.deltaTime);
        _anim.SetFloat("y", y, .1f, Time.deltaTime);
    }

    
    public void HandleCast(bool cast)
    {
        _anim.applyRootMotion = cast;

        if (cast)
        {
            _anim.SetBool("cast", false);
            _anim.Play("Cast", -1, 0f);
        }

        _anim.SetBool("cast", cast);
    }

    
    
}

