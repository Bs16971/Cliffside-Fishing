using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationSceneTransition : MonoBehaviour
{
    public Animator animator; // Assign via Inspector or GetComponent
    public string animationName; // The name of the animation clip
    public string nextSceneName;

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(WaitHalfwayThenLoadScene());
        }
    }

    IEnumerator WaitHalfwayThenLoadScene()
    {
        // Get the AnimationClip duration
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        float clipLength = 0f;

        foreach (AnimationClip clip in clips)
        {
            if (clip.name == animationName)
            {
                clipLength = clip.length;
                break;
            }
        }

        if (clipLength > 0f)
        {
            yield return new WaitForSeconds(clipLength / 2f); // Wait halfway
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Animation clip not found or length is zero.");
        }
    }
}
