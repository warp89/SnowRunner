using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChangerScript : MonoBehaviour
{
    private Animator animator;
    private float animationSpeed;
    private SettingsScript settings;
    private void Start()
    {
        settings = SettingsScript.FindObjectOfType<SettingsScript>();
        animator = GetComponentInChildren<Animator>(); 
    }
    private void Update()
    {        
        animator.SetFloat(settings.RunSpeed(), settings.movingSpeed);        
    }
}
