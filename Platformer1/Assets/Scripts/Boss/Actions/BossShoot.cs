
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
        private Rigidbody2D rb;

        public override void Init(BossBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<BossBase>();
            animScript = parent.GetComponentInChildren<BossAnim>();
            rb = parent.GetComponentInChildren<Rigidbody2D>();
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
            if (animScript.CheckShootFinished())
            {
                _runner.SetAction(typeof(BossWaitStep));
            }
        }

        public override void Exit()
        {

        }

        private void Enter()
        {
            if (rb.transform.position.x <= baseScript.GetPlayerPositionX())
            {
                rb.transform.localScale = new Vector2(Mathf.Abs(rb.transform.localScale.x), rb.transform.localScale.y);
            }
            else if (rb.transform.position.x >= baseScript.GetPlayerPositionX())
            {
                rb.transform.localScale = new Vector2(Mathf.Abs(rb.transform.localScale.x) * -1, rb.transform.localScale.y);
            }
            animScript.ResetShootFinished();
            animScript.ShootAnim();
        }
    }
}