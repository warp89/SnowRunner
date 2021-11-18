using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusFailScript : MonoBehaviour
{
    [SerializeField]
    private GameObject endGamePanel;
    private SettingsScript settings;
    private float timeToAdd;
    private void Start()
    {
        settings = SettingsScript.FindObjectOfType<SettingsScript>();
        timeToAdd = 1 / settings.movingSpeed;        
    }
    private void FixedUpdate()
    {
        timeToAdd -= Time.fixedDeltaTime;
        if (timeToAdd<=0)
        {
            settings.AddScores(settings.runScores);
            timeToAdd = 1 / settings.movingSpeed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonus"))
        {
            settings.AddScores(settings.bonusScores);
            settings.AddBonus();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Finish"))
        {
            Time.timeScale = 0;
            endGamePanel.SetActive(true);
        }
    }   
}
