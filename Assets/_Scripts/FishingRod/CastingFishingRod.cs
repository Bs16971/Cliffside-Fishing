using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = System.Numerics.Vector3;

public class CastingFishingRod : MonoBehaviour
{

    private Animator _anim;

    private float _coolDownITme;
    private float _nextFireTime;
    public static int noOfClicks = 0;
    private float lastClickedTime = 0;

    public Transform lureTransform;
    public Transform RodTipTransform;
    public float castForce = 30f;

    private InputManager _input;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _input = InputManager.instance;

        _input.Cast.performed += _ => OnCastPerformed();
    }

    // Update is called once per frame
    void Update()
    {

        
        
            /*
        if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .7f && _anim.GetCurrentAnimatorStateInfo(0)
            .IsName("Cast"))
        {
            _anim.SetBool("Cast", false);
            noOfClicks = 0;
        }
        
        
        if (Time.time - lastClickedTime > _nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnClick();
            }
        }
        */
        
    }

    private void OnCastPerformed()
    {
        if (Time.time - lastClickedTime >= _coolDownITme)
        {
            lastClickedTime = Time.time;
            CastLure();
        }
    }

    void CastLure()
    {
        if (lureTransform == null || RodTipTransform == null) return;

        lureTransform.SetParent(null);
        lureTransform.position = RodTipTransform.position;
        lureTransform.rotation = RodTipTransform.rotation;

        Rigidbody rb = lureTransform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = UnityEngine.Vector3.zero;
            rb.AddForce(transform.forward * castForce, ForceMode.Impulse);
        }

        _anim.SetTrigger("Cast");
    }

}