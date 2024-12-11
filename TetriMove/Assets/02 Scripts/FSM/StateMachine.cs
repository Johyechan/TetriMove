using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class StateMachine
    {
        private IState _currentState;
        private IState _delayState;

        private bool _isDelay;

        private float _delayTime;
        private float _curTime;

        public virtual void ChangeState(IState newState)
        {
            if(!_isDelay)
            {
                _currentState?.Exit();

                _currentState = newState;

                _currentState.Enter();
            }
        }

        public virtual void ChangeStateWithDelay(IState newState, float delay)
        {
            if(!_isDelay)
            {
                _isDelay = true;
                _delayState = newState;
                _curTime = 0;
                _delayTime = delay;
            }
        }

        public virtual void UpdateExecute()
        {
            if(_isDelay)
            {
                _curTime += Time.deltaTime;
                if(_curTime > _delayTime)
                {
                    _isDelay = false;
                    ChangeState(_delayState);
                }
            }
            _currentState?.Execute();
        }
    }
}

