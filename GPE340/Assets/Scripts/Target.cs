using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // vars
    public float timeRespawnInSeconds;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnTarget(timeRespawnInSeconds));
    }

    // Update is called once per frame
    void Update()
    {
        // If target is inactive, begin Coroutine
        if (!target.activeInHierarchy)
        {
            StartCoroutine(RespawnTarget(timeRespawnInSeconds));
        }
    }

    IEnumerator RespawnTarget(float seconds)
    {
        // Wait for designer defined seconds
        yield return new WaitForSeconds(seconds);
        // Set target to active
        target.SetActive(true);
        // Reset health
        target.GetComponent<Health>().currentHealth = target.GetComponent<Health>().maxHealth;
        
    }

}
