
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
        private BossAnim animScript;
        [SerializeField] private float timeToPass;
        private float timerCurrent;

        public override void Init(BossBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<BossBase>();
            animScript = parent.GetComponentInChildren<BossAnim>();
            Enter();
        }

        public override void PlayAction()
        {
            animScript.IdleAnim();
            ChangeAction();
        }

        public override void PlayFixedAction()
        {
            timerCurrent -= Time.deltaTime;
        }

        public override void ChangeAction()
        {
            if (timerCurrent <= 0)
            {
                int rand = Random.Range(1, 99);
                if (rand%2 == 1)
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
            timerCurrent = timeToPass;
        }

        public override void Exit()
        {

        }
    }
}