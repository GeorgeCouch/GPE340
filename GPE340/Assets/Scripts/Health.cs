using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public UnityEvent OnDeath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reset current health to max health if current health goes over
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // Subtracts current health when damage is taken and dies if reaches 0
    public void TakeDamage (float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Invoke Death event, this should defaultly be to setActive to false
            OnDeath.Invoke();
        }
    }
}
