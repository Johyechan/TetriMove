using FSM;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState
{
    private PlayerMovement _movement;

    public PlayerIdleState(PlayerMovement movement)
    {
        _movement = movement;
    }

    public void Enter()
    {
        Debug.Log("Idle");
        _movement.StopImmediately();
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
