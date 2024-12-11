using FSM;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IState
{
    private PlayerMovement _movement;

    public PlayerMoveState(PlayerMovement movement)
    {
        _movement = movement;
    }

    public void Enter()
    {
        Debug.Log("Move");
    }

    public void Execute()
    {
        _movement.Move();
    }

    public void Exit()
    {
        
    }
}
