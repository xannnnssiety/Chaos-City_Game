using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public Text killEnemyText;
    public Text killCivilText;

    public static int killEnemy = 0;
    public static int killCivil = 0;


    // Start is called before the first frame update
    void Start()
    {
        killCivil = PlayerPrefs.GetInt("KillCivil", KillCount.killCivil); 
        killEnemy = PlayerPrefs.GetInt("KillEnemy", KillCount.killEnemy);

    }

    // Update is called once per frame
    void Update()
    {
        killEnemyText.text = killEnemy.ToString();
        killCivilText.text = killCivil.ToString();
    }
}
