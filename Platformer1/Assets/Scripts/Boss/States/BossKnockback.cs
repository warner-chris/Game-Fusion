using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Boss/States/Knockbsck")]
    public class BossKnockback : State<BossBase>
    {
        private BossBase baseScript;

        public override void Init(BossBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<BossBase>();
        }

        public override void Update()
        {

        }

        public override void FixedUpdate()
        {

        }

        public override void ChangeAction()
        {

        }

        public override void ChangeState()
        {

        }

        public override void Exit()
        {

        }
    }
}