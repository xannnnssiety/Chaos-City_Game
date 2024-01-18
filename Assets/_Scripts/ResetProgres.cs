using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgres : MonoBehaviour
{
    public GameObject resetImg;
    public GameObject btnReset;


    private void Start()
    {
        resetImg.SetActive(false);


    }

    public void Update()
    {
        if (KillCount.killCivil >= 1)
        {
            btnReset.SetActive(true);
        }
        else
        {
            btnReset.SetActive(false);
        }
        if (KillCount.killEnemy >= 1)
        {
            btnReset.SetActive(true);
        }
        else
        {
            btnReset.SetActive(false);
        }
    }

    public void Reset()
    {
        resetImg.SetActive(true);
        KillCount.killEnemy = 0;
        KillCount.killCivil = 0;
        PlayerPrefs.SetInt("KillCivil", KillCount.killCivil);
        PlayerPrefs.SetInt("KillEnemy", KillCount.killEnemy);
    }

    public void CloseImg()
    {
        resetImg.SetActive(false);
    }
}
