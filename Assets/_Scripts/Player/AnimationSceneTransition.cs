using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationSceneTransition : MonoBehaviour
{
    public Animator animator; 
    public string Cast; 
    public string nextSceneName;

    private InputManager _input;
    
    void Start()
    {
        _input = InputManager.instance;
        
        // _input.Cast.performed += context => StartCoroutine(WaitHalfwayThenLoadScene());
    }

    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(nextSceneName);
    }
    

    IEnumerator WaitHalfwayThenLoadScene()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        float clipLength = 0f;

        foreach (AnimationClip clip in clips)
        {
            if (clip.name == Cast)
            {
                clipLength = clip.length;
                break;
            }
        }

        if (clipLength > 0f)
        {
            yield return new WaitForSeconds(clipLength / 2f);
            // Wait halfway
            SceneManager.LoadSceneAsync(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Animation clip not found or length is zero.");
        }
        
        
    }

   
}
