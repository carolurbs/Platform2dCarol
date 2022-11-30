using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 


public class HealthBase : MonoBehaviour
{
    public Action OnKill;
    public SO_HealthSetup soHealth;
    private  bool _isDead=false;
    public bool destroyOnKill = false;
    public float delayToKill = .2f;
    [SerializeField]private FlashColor _flashColor;

    private void Awake()
    {
        Init();
        if(_flashColor ==null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
    }
    private void Init()
    { 
        _isDead = false;
        soHealth. _currentLife = soHealth.startLife;

    }

    public void Damage (int damage)
    {
        if (_isDead) return;
        soHealth._currentLife -= damage;
        if (soHealth._currentLife < 0)
        {
            Kill();
        }
        if (_flashColor != null)
        {
            _flashColor.Flash();
        }
    }
    private void Kill()
    {
        _isDead=true;
        if(destroyOnKill==true)
        {
            Destroy(gameObject, delayToKill);
        }
        OnKill?.Invoke();
    }
   

}
