using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Player/States/Actionable")]

    public class Actionable : State<PlayerBase>
    {
        private PlayerBase baseScript;
        private PlayerHealth healthScript;

        public override void Init(PlayerBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<PlayerBase>();
            healthScript = parent.GetComponentInChildren<PlayerHealth>();
            ChangeAction();
        }

        public override void Update()
        {
            _runner.GetActiveAction().PlayAction();
            baseScript.SetJump();
            ChangeState();
        }

        public override void FixedUpdate()
        {
            _runner.GetActiveAction().PlayFixedAction();
        }

        public override void ChangeAction()
        {
            _runner.SetAction(typeof(PlayerMove));
        }

        public override void ChangeState()
        {
            if (healthScript.AskKnockBack())
            {
                _runner.SetState(typeof(PlayerKnockedBack));
            }
        }

        public override void Exit()
        {

        }
    }
}
