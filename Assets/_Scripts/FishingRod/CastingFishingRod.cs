using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastingFishingRod : MonoBehaviour
{

    private Animator _anim;

    private float _coolDownITme = 2f;
    private float _nextFireTime = 0f;
    public static int noOfClicks = 0;
    private float lastClickedTime = 0;

    public Transform lureTransform;
    public Transform RodTipTransform;
    public float castForce = 30f;

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
            if (Input.GetKeyDown(KeyCode.Space))
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
            LanchLure();
        }
    }

    void LanchLure()
    {
        if (lureTransform == null || RodTipTransform == null) return;

        lureTransform.SetParent(null);

        lureTransform.position = RodTipTransform.position;
        lureTransform.rotation = RodTipTransform.rotation;
        
        Rigidbody rb = lureTransform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;

            Vector3 castDirection = transform.forward + transform.up * .5f;
            rb.AddForce(transform.forward * castForce, ForceMode.Impulse);
        }
    }
   
    public void TransitionToScene(string caughtScene)
    {
        SceneManager.LoadScene(caughtScene);
    }
    
    
}