using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator _anim;

    public void Initialize()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void UpdateAnimatorValues(float x, float y)
    {
        _anim.SetFloat("x",x,.1f,Time.deltaTime);
        _anim.SetFloat("y", y, .1f, Time.deltaTime);
    }
}
