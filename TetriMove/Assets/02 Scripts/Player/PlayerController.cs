using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement _movement;

        private StateMachine _machine;

        private IState _idleState;
        private IState _moveState;
        private IState _jumpState;
        private IState _dieState;

        void Start()
        {
            _movement = GetComponent<PlayerMovement>();

            _machine = new StateMachine();

            _idleState = new PlayerIdleState(_movement);
            _moveState = new PlayerMoveState(_movement);

            _machine.ChangeState(_idleState);
            _machine.ChangeStateWithDelay(_moveState, 3.5f);
        }

        void Update()
        {
            _machine.UpdateExecute();
        }
    }
}

