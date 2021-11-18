using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private GameObject runway;
    // Start is called before the first frame update
    void Start()
    {
        BackgroundSpawn();
    }

    private void BackgroundSpawn()
    {
        for (int j = -3; j < 3; j++)
        {
            for (int i = -3; i < 3; i++)
            {
                bool changer = i < -2 || i >= 2 || j==2;
                if (changer)
                {
                    Instantiate(wall, new Vector3(i, 0, j), Quaternion.identity);
                }                
                Instantiate(runway, new Vector3(i, -0.5f, j), Quaternion.identity);
            }
        }
    }
}
