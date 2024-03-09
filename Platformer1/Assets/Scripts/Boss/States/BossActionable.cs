using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Boss/States/Actionable")]
    public class BossActionable : State<BossBase>
    {
        private BossBase baseScript;

        public override void Init(BossBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<BossBase>();
            ChangeAction();
        }

        public override void Update()
        {
            _runner.GetActiveAction().PlayAction();
        }

        public override void FixedUpdate()
        {
            _runner.GetActiveAction().PlayFixedAction();
            ChangeState();
        }

        public override void ChangeAction()
        {
            _runner.SetAction(typeof(BossWaitStep));
        }

        public override void ChangeState()
        {
            //_runner.SetState(typeof(BossKnockback));
        }

        public override void Exit()
        {

        }
    }
}