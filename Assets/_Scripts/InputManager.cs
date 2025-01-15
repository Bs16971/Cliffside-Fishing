using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;

    private Controls _controls;
    private Vector2 _move;
    private Vector2 _look;
    
    public Vector2 Move
    {
        get => _move;
        private set => _move = value;
    }
    

    public Vector2 Look
    {
        get => _look;
        private set => _look = value;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        _controls = new Controls();
        _controls.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        _controls.Locomotion.Move.performed += MoveOnperformed;
        _controls.Locomotion.Look.performed += LookOnperformed;
    }
    

    private void LookOnperformed(InputAction.CallbackContext obj)
    {
        _look = obj.ReadValue<Vector2>();
    }

    private void MoveOnperformed(InputAction.CallbackContext obj)
    {
        _move = obj.ReadValue<Vector2>();
        
    }
}