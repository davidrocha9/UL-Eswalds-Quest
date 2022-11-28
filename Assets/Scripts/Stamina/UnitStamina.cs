using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStamina
{
    float _currentStamina;
    float _currentMaxStamina;
    [SerializeField] private float stamina = 100f;
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float _useAmount = 15f;
    [SerializeField] private float _reloadAmount = 3f;

    public float Stamina
    {
        get
        {
            return _currentStamina;
        }
        set
        {
            _currentStamina = value;
        }
    }

    public float MaxStamina
    {
        get
        {
            return _currentMaxStamina;
        }
        set
        {
            _currentMaxStamina = value;
        }
    }

    public float UseAmount
    {
        get
        {
            return _useAmount;
        }
        set
        {
            _useAmount = value;
        }
    }

    public float ReloadAmount
    {
        get
        {
            return _reloadAmount;
        }
        set
        {
            _reloadAmount = value;
        }
    }

    // Constructors
    public UnitStamina() { 
    }

    public UnitStamina(float stamina, float maxStamina)
    {
        _currentStamina = stamina;
        _currentMaxStamina = maxStamina;
    }


    // Methods

    public void UseUnit()
    {
        if(_currentStamina > 0)
        {
            _currentStamina -= _useAmount;
        }
    }

    public void SetStamina(float stamina)
    {
        _currentStamina = stamina;
    }


    public void ReloadUnit(float reloadAmount)
    {
        if(_currentStamina < _currentMaxStamina)
        {
            _currentStamina += reloadAmount;
        }
        if (_currentStamina > _currentMaxStamina)
        {
            _currentStamina = _currentMaxStamina;
        }
    }
}
