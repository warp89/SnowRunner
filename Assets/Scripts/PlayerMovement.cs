using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int linePosition;
    private float changeLineSpeed;
    private SettingsScript settings;
    void Start()
    {
        settings = SettingsScript.FindObjectOfType<SettingsScript>();
        linePosition = (settings.lines - 1) / 2;
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) && linePosition > 0 || Input.GetKeyUp(KeyCode.A) && linePosition > 0)
        {
            linePosition--;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && linePosition < settings.lines - 1 || Input.GetKeyUp(KeyCode.D) && linePosition < settings.lines - 1)
        {
            linePosition++;
        }
        ChangeLine(linePosition);       
    }

    private void ChangeLine(int line)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(line, 0, 0), Time.deltaTime * settings.slideSpeed);

    }  
}
