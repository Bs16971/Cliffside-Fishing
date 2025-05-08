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
        _input.Cast.canceled += _ => OnCastCanceled();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCastPerformed()
    {
       
        
        if (Time.time - lastClickedTime >= _coolDownITme)
        {
            lastClickedTime = Time.time;
            CastLure();
        }
    }

    private void OnCastCanceled()
    {
        _anim.SetBool("Cast", false);
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

        _anim.SetBool("Cast", true);
    }

}