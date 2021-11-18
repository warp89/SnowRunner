using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    private SettingsScript settings;
    [SerializeField]
    private Transform playerTransform;    
    private Vector3 offset;
    private void Start()
    {
        settings = SettingsScript.FindObjectOfType<SettingsScript>();
        offset = transform.position - playerTransform.position;        
    }
    private void FixedUpdate()
    {        
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position + offset, Time.fixedDeltaTime + settings.cameraSpeed);                
    }

    
}
