using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingFishingRod : MonoBehaviour
{

    private Animator _anim;

    private float _coolDownITme = 2f;

    private float _nextFireTime = 0f;

    public static int noOfClicks = 0;

    private float lastClickedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .7f && _anim.GetCurrentAnimatorStateInfo(0)
            .IsName("Cast"))
        {
            _anim.SetBool("Cast", false);
            noOfClicks = 0;
        }
        if (Time.deltaTime - lastClickedTime > _nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
        }
    }

    void OnClick()
    {
        lastClickedTime = Time.deltaTime;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            _anim.SetBool("Cast", true);
            
        }
    }
}