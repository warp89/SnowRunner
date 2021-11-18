using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresScript : MonoBehaviour
{
    private SettingsScript settings;
    private float metersToAdd;
    private int meters = 0;
    [SerializeField]
    private Text inGameDistance;
    [SerializeField]
    private Text endGameScore;
    void Start()
    {
        settings = SettingsScript.FindObjectOfType<SettingsScript>();
        metersToAdd = 1 / settings.movingSpeed;
    }
    
    void FixedUpdate()
    {
        metersToAdd -= Time.fixedDeltaTime;
        if (metersToAdd <= 0)
        {
            meters++;
            inGameDistance.text = meters.ToString();
            metersToAdd = 1 / settings.movingSpeed;
        }
        endGameScore.text = $"Scores: {meters} * {settings.runScores} = \n {meters * settings.runScores} \n Bonuses: {settings.GetBonus()} \n Total scores: {settings.GetScores()}";
    }
}
