using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyWin;
    public GameObject CivilWin;

    public int enemyToWin;
    public int civilToWin;

    // Start is called before the first frame update
    void Start()
    {
        EnemyWin.SetActive(false);
        CivilWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(KillCount.killCivil >= civilToWin)
        {
            EnemyWin.SetActive(true);
        }

        if (KillCount.killEnemy >= enemyToWin)
        {
            CivilWin.SetActive(true);
        }
    }
}
