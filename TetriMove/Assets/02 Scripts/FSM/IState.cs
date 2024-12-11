using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public interface IState
    {
        public void Enter();

        public void Execute();

        public void Exit();
    }
}

