using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBasicFish : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TargetPos"))
        {
            _anim.SetBool("Caught", false);
        } else if (other.CompareTag("Player"))
        {
            _anim.SetBool("Caught", true);
            Debug.Log("Code is working");
        } 
    }
}
