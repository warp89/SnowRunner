using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarrierScript : MonoBehaviour
{    
    private float barrierCreateTime;
    private float timeToCreate;
    private SettingsScript settings;
    [SerializeField]
    private GameObject[] barriers = new GameObject[3];

    private void Start()
    {
        settings = SettingsScript.FindObjectOfType<SettingsScript>();        
        timeToCreate = settings.spellTime / settings.movingSpeed;
    }
    private void Update()
    {   
        timeToCreate -= Time.deltaTime;
        if (timeToCreate <= 0)
        {
            CreateBarriers();
            timeToCreate = settings.spellTime / settings.movingSpeed;
        }
    }
    private void CreateBarriers()
    {
        int[] barriersOnLines = new int[settings.lines];
        for (int i = 0; i < barriersOnLines.Length; i++)
        {
            barriersOnLines[i] = Random.Range(0, barriers.Length);           
        }
        if (CheckLine(barriersOnLines))
        {
            BuildBarriers(barriersOnLines);
        }else
        {            
            CreateBarriers();
        }
    }

    private void BuildBarriers(int[] buildLine)
    {
        for (int i = 0; i < buildLine.Length; i++)
        {
            Instantiate(barriers[buildLine[i]], new Vector3(i, 0, settings.distance), Quaternion.identity);
        }
    }

    private bool CheckLine(int[] line)
    {
        int equalNumber = 0;
        for (int i = 0; i < line.Length - 1; i++)
        {
            if (line[i] == line[i + 1])
            {
                equalNumber++;
            }
        }        
        return equalNumber != line.Length - 1;
    }
}
