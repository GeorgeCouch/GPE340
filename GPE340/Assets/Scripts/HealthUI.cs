using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    // Vars
    private float playerHealth;
    private GameObject player;
    private Text text;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        //Get player
        player = GameObject.FindWithTag("Player");
        //Get Text Component
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Keep health up to date and display as percentage
        playerHealth = player.GetComponent<Health>().currentHealth;
        text.text = string.Format("Health: {0}%", Mathf.RoundToInt(playerHealth));
    }
}
