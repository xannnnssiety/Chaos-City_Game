using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdSpawner : MonoBehaviour
{
    public GameObject objectToToggle;
    
    private float toggleInterval = 600f;
    private float toggleDelay = 0.5f;
    private float lastToggleTime;



    private void Start()
    {
        objectToToggle.SetActive(false);
       
        lastToggleTime = Time.time;
        
    }

    private void Update()
    {
        if (Time.time - lastToggleTime >= toggleInterval)
        {
            lastToggleTime = Time.time;
            StartCoroutine(ToggleObjectWithDelay());
           
        }
    }

    private IEnumerator ToggleObjectWithDelay()
    {
        objectToToggle.SetActive(true);
        yield return new WaitForSeconds(toggleDelay);
        objectToToggle.SetActive(false);
    }

 
}
