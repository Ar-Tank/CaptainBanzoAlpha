using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRefill : Interactable
{
    public PlayerHealth playerHealth;
    private GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        if (playerHealth != null)
        {
            playerHealth.RestoreHealth(playerHealth.maxHealth);
            Debug.Log("Health Fully Restored");
        }
        else
        {
            Debug.LogWarning("nuh uh");
        }
    }
}
