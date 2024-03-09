
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEditor;
using UnityEngine.Animations;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Boss/Actions/Attack")]
    public class BossAttack : SubState<BossBase>
    {
        private BossBase baseScript;
        private BossAnim animScript;

        public override void Init(BossBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<BossBase>();
            animScript = parent.GetComponentInChildren<BossAnim>();
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

        public void Enter()
        {
            animScript.DashAnim();
        }
    }
}