using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : Movement
    {
        [SerializeField] private float _speed;

        private Vector2 _dir;

        private bool _isRight;

        protected override void Start()
        {
            base.Start();
            _dir = Vector2.right;
            _isRight = true;
            _rigid2D.velocity = _dir * _speed;
        }

        public override void Move()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_isRight)
                {
                    _dir = Vector2.left;
                    _isRight = false;
                }
                else
                {
                    _dir = Vector2.right;
                    _isRight = true;
                }
            }

            _rigid2D.velocity = _dir * _speed;
        }
    }
}

