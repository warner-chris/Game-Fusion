
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEditor;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Boss/Actions/Shoot")]
    public class BossShoot : SubState<BossBase>
    {
        private BossBase baseScript;
        private BossAnim animScript;

        public override void Init(BossBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<BossBase>();
            animScript = parent.GetComponentInChildren<BossAnim>();
            Enter();
        }

        public override void PlayAction()
        {
            ChangeAction();
        }

        public override void PlayFixedAction()
        {

        }

        public override void ChangeAction()
        {
            Debug.Log(animScript.CheckShootFinished());
            if (animScript.CheckShootFinished())
            {
                Debug.Log("change");
                _runner.SetAction(typeof(BossWaitStep));
            }
        }

        public override void Exit()
        {

        }

        private void Enter()
        {
            animScript.ResetShootFinished();
            animScript.ShootAnim();
        }
    }
}