using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 1000f;
    private float lerpTimer;
    public float health;
    public float damageOverTime;
    public Image frontHealthBar;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        health -= damageOverTime * (Time.deltaTime / 3);

        health = Mathf.Clamp(health, 0, maxHealth);

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        frontHealthBar.fillAmount = health / maxHealth;
    }

    public void RestoreHealth(float healAmount)
    {
        health = Mathf.Clamp(healAmount, 0, maxHealth);
        UpdateHealthBar();
    }
}
