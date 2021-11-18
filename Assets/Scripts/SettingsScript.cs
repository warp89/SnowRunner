using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public int lines = 3;
    public float slideSpeed = 5f;
    public float speedIncrease = 1.1f;
    public float spellTime = 3f;
    public float movingSpeed = 2f;
    [SerializeField]
    private int scores;
    public int bonusScores = 10;
    public int runScores = 2;
    private int bonusCounter = 0;
    private string runSpeed = "RunSpeed";
    [HideInInspector]
    public int distance = 15;
    [SerializeField]
    private int interval = 50;
    public float cameraSpeed = 0.03f;
    private float intervalEnd = 0;
    public void AddScores(int scoresToAdd)
    {
        scores += scoresToAdd;
    }
    public void AddBonus()
    {
        bonusCounter++;
    }
    public int GetBonus()
    {
        return bonusCounter;
    }
    public string RunSpeed()
    {
        return runSpeed;
    }
    public string GetScores()
    {
        return scores.ToString();
    }
    private void Start()
    {
        intervalEnd = interval*(1/movingSpeed);
    }
    private void FixedUpdate()
    {
        intervalEnd -= Time.fixedDeltaTime;
        if (intervalEnd <= 0)
        {
            movingSpeed *= speedIncrease;
            intervalEnd = interval * (1 / movingSpeed);            
        }        
    }    
}
