using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pokemon : MonoBehaviour
{
    public string pokemonName;
    public int currentHealth;
    public int attack;
    public int defense;
    public int speed;

    [Header("UI")] public TextMeshProUGUI healthText;
    public Slider slider;
    public int maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        healthText.text = this.currentHealth.ToString();
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
        
    }
    
    public void Attack(Pokemon enemy)
    {
        int damage = attack - enemy.defense;
        if (damage < 0)
            damage = 0;
        enemy.TakeDamage(damage);
    }

    private void Update()
    {
        float currentVelocity = 1f;
        float health = Mathf.SmoothDamp(slider.value, this.currentHealth, ref currentVelocity, 10 * Time.deltaTime);
        slider.value = health;
        healthText.text = this.currentHealth.ToString();
    }
}
