using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMovingScript : MonoBehaviour
{    
    private Vector3 targetTransform;
    private SettingsScript settings;
    private void Start()
    {
        settings = SettingsScript.FindObjectOfType<SettingsScript>();        
        targetTransform = new Vector3(transform.position.x, transform.position.y, -transform.position.z);        
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTransform, Time.deltaTime * settings.movingSpeed);
        if (transform.position == targetTransform)
        {
            Destroy(gameObject);
        }  
    }
}
