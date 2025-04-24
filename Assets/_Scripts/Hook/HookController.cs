using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private InputManager _input;
    private CharacterController _controller;
    [SerializeField] private int UpDownSpeed = 5;
    private Vector3 velocity;
    private Vector3 targetPosition;
    private Vector3 currentVelocity;
    private bool caughtFish = false;
    private float hookSpeed = 5f;
    private Fish2 _fish2;
    public static String TypeOfFishCaught = "Nothing";
    
    
   
    
    void Start()
    {
        _input = InputManager.instance;
        if (_controller == null)
        {
            _controller = GetComponent<CharacterController>();
        }
        GameObject targetObject = GameObject.FindGameObjectWithTag("TargetPos");

        
            targetPosition = targetObject.transform.position;

            caughtFish = false;
            TypeOfFishCaught = null;
            PlayerPrefs.SetString("FishType", TypeOfFishCaught);

    }

    // Update is called once per frame
    void Update()
    {
        if (caughtFish &&  PlayerPrefs.GetInt("DidItBreak", 2) == 1)
        {
            MovePlayer2();
        }
        else if(PlayerPrefs.GetInt("DidItBreak", 2) ==2 )
        {
            
            HandleMovement(Time.deltaTime);
        }

        hookSpeed = PlayerPrefs.GetInt("HookSpeed", 5);

    }

    private void HandleMovement(float delta)
    {
        // create a movement vector that is RELATIVE TO THE DIRECTION THE PLAYER IS FACING
        
            Vector3 movdir = (_input.Move.x * transform.right) + (_input.Move.y * transform.forward) +
                             (_input.Up.y * transform.up);
            if (transform.position.y <= 1f && movdir.y < 0)
            {
                movdir.y = 0;
            }
            // tell the controller to move
            _controller.Move(movdir * (hookSpeed * delta));
        
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            TypeOfFishCaught = other.tag;
            caughtFish = true;
            PlayerPrefs.SetString("FishType", TypeOfFishCaught);
            PlayerPrefs.Save();
        }else if (other.CompareTag("Betta"))
        {
            TypeOfFishCaught = other.tag;
            caughtFish = true;
            PlayerPrefs.SetString("FishType", TypeOfFishCaught);
            PlayerPrefs.Save();
            
        } else if (other.CompareTag("Catfish"))
        {
            TypeOfFishCaught = other.tag;
            caughtFish = true;
            PlayerPrefs.SetString("FishType", TypeOfFishCaught);
            PlayerPrefs.Save();
            
        } 
        if(other.CompareTag("TargetPos"))
        {
            PlayerPrefs.SetInt("DidItBreak", 2);
        }
        PlayerPrefs.SetInt("CaughtAFish", 1);
    }

   

    void MovePlayer2()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance > 0.1f)
        {
            
            _controller.Move(direction * 40f * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                caughtFish = false;
                
            }
        }
        
    }
    
    

    
}
