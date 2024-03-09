using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System.Runtime.CompilerServices;

namespace StateMachine
{
    public class BossBase : StateRunner<BossBase>
    {
        [SerializeField] LayerMask playerLayer;
        private bool edgeFound = false;
        private int currentDirection;

        protected override void Awake()
        {
            base.Awake();
        }

        public float GetPlayerPositionX()
        {
            float _playerPositionx = GameObject.FindWithTag("Player").transform.position.x;

            return _playerPositionx;
        }

        public void SetMovementDirection(int _setDirection)
        {
            currentDirection = _setDirection;
        }

        public int GetDirection()
        {
            return currentDirection;
        }
    }

}
