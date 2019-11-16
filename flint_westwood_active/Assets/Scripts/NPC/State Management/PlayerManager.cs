using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    WEAPON_HOLSTERED,
    WEAPON_DRAWN,
    DEAD
}

public class PlayerManager : MonoBehaviour
{
    private const int INITIAL_HEALTH = 5;
    private int currentHealth = INITIAL_HEALTH;
    public event Action PlayerDeathEvent;
    public event Action<PlayerState> PlayerStateChangeEvent;
    public bool isFiring;
    private bool isHolstered;

    private void ChangeState(PlayerState newState)
    {
        PlayerStateChangeEvent?.Invoke(newState);
    }

    private void DebugChangeState()
    {
        if (Input.GetKeyDown(KeyCode.H) && isHolstered)
        {
            isHolstered = false;
            Debug.Log("Weapon Drawn");
            ChangeState(PlayerState.WEAPON_DRAWN);
        }
        else if (Input.GetKeyDown(KeyCode.H) && !isHolstered)
        {
            isHolstered = true;
            Debug.Log("Weapon Holstered");
            ChangeState(PlayerState.WEAPON_DRAWN);
        }
    }
    
    private void Die()
    {
        if (this.currentHealth <= 0)
        {
           PlayerDeathEvent?.Invoke();
        }
        
        Debug.Log("im dead rip");
    }

    void Update()
    {
        DebugChangeState();
    }
}