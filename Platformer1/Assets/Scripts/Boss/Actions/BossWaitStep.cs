
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEditor;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Boss/Actions/Wait")]
    public class BossWaitStep : SubState<BossBase>
    {
        private BossBase baseScript;
        [SerializeField] private float timeToPass;
        private float timerCurrent;

        public override void Init(BossBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<BossBase>();
            Enter();
        }

        public override void PlayAction()
        {

        }

        public override void PlayFixedAction()
        {
            timerCurrent -= Time.deltaTime;
        }

        public override void ChangeAction()
        {
            if (timerCurrent >= 0)
            {
                //generate random number to use projectile instead
                if (true)
                {
                    _runner.SetAction(typeof(BossMove));
                }
                else
                {
                    _runner.SetAction(typeof(BossShoot));
                }
            }
        }

        private void Enter()
        {
            //set an idle anim
            timerCurrent = timeToPass;
        }

        public override void Exit()
        {

        }
    }
}