using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    int _currentHealth;
    int _currentMaxHealth;

    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }

    public UnitHealth(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }


    // Methods

    public void DmgUnit(int dmgAmount)
    {
        if(_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }
    }

    public void SetHealth(int health)
    {
        _currentHealth = health;
    }


    public void HealUnit(int healthAmount)
    {
        if(_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healthAmount;
        }
        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
}
