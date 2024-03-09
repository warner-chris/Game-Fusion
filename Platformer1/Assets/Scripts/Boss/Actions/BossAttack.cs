
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
        private float targetPositionX;
        [SerializeField] private float dashSpeed;
        private Rigidbody2D rb;
        private bool changeToWait;
        [SerializeField] private float leftMostEdge;
        [SerializeField] private float rightMostEdge;
        private int currentDirection;

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

        }

        public override void PlayFixedAction()
        {

        }

        public override void ChangeAction()
        {
            if (changeToWait)
            {
                _runner.SetAction(typeof(BossWaitStep));
            }
        }

        public override void Exit()
        {

        }

        public void Enter()
        {
            animScript.DashAnim();
            changeToWait = false;
            targetPositionX = baseScript.GetPlayerPositionX();
            if (targetPositionX > rb.transform.position.x)
            {
                currentDirection = 1;
            }
            else
            {
                currentDirection = -1;
            }
            rb.transform.localScale = new Vector2(Mathf.Abs(rb.transform.localScale.x) * currentDirection, rb.transform.localScale.y);
        }
    }
}