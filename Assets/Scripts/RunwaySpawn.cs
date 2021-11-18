using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunwaySpawn : MonoBehaviour
{
    private float timeToCreate;
    private SettingsScript settings;
    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private GameObject runway;
    private void Start()
    {
        settings = SettingsScript.FindObjectOfType<SettingsScript>();
        timeToCreate = 1 / settings.movingSpeed;
        StartingFieldSpawn();
    }
    private void FixedUpdate()
    {
        timeToCreate -= Time.fixedDeltaTime;
        if (timeToCreate <= 0)
        {
            for (int i = (settings.lines - settings.lines) - 1; i < settings.lines + 1; i++)
            {
                bool changer = i < settings.lines - settings.lines || i >= settings.lines;
                if (changer)
                {
                    Instantiate(wall, new Vector3(i, 0, settings.distance), Quaternion.identity);
                }
                Instantiate(runway, new Vector3(i, -0.5f, settings.distance), Quaternion.identity);
            }
            timeToCreate = 1 / settings.movingSpeed;
        }

    }

    private void StartingFieldSpawn()
    {
        for (int j = -5; j < settings.distance + 2; j++)
        {
            for (int i = (settings.lines - settings.lines) - 1; i < settings.lines + 1; i++)
            {
                bool changer = i < settings.lines - settings.lines || i >= settings.lines;
                if (changer && j >= 0)
                {
                    Instantiate(wall, new Vector3(i, 0, j), Quaternion.identity);
                }
                Instantiate(runway, new Vector3(i, -0.5f, j), Quaternion.identity);
            }
        }
    }
}
