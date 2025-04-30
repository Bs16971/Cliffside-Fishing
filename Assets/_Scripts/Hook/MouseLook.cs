using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private InputManager _input;

    [SerializeField] private Transform playerParent;

    [SerializeField] private float sensitivity = 50;

    private float _xRot;
    public Transform target;
    public float duration = 3f; 

    private bool isForcingLook = false;
    // Start is called before the first frame update
    void Start()
    {
        _input = InputManager.instance;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleLook(Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        target = other.transform;
    }

    private void HandleLook(float delta)
    {
        // create the true value that we want to apply
        float mouseX = _input.Look.x * delta * sensitivity;
        float mouseY = _input.Look.y * delta * sensitivity;
        // avoid inverting look up/down
        _xRot -= mouseY;
        
        // clamp x rotation to avoid breaking neck
        _xRot = Mathf.Clamp(_xRot, -90, 90);
        // apply rotation to appropriate things.
        transform.localRotation = Quaternion.Euler(_xRot, 0, 0);
       playerParent.Rotate(Vector3.up, mouseX);
       
    }
    IEnumerator LookRoutine()
    {
        isForcingLook = true;

        Transform cam = Camera.main.transform;
        Quaternion originalRotation = cam.rotation;
        

        playerParent.Rotate(target.transform.position);

        yield return new WaitForSeconds(duration);

        cam.rotation = originalRotation; 
        isForcingLook = false;
    }
    public void ForceLookAtTarget()
    {
        if (!isForcingLook)
        {
            StartCoroutine(LookRoutine());
        }
    }
}
