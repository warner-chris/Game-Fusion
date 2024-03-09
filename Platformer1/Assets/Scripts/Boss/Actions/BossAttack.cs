
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEditor;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Boss/Actions/Attack")]
    public class BossAttack : SubState<BossBase>
    {
        private BossBase baseScript;

        public override void Init(BossBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<BossBase>();
        }

        public override void PlayAction()
        {

        }

        public override void PlayFixedAction()
        {

        }

        public override void ChangeAction()
        {

        }

        public override void Exit()
        {

        }
    }
}