
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEditor;
using Unity.VisualScripting;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Boss/Actions/Move")]
    public class BossMove : SubState<BossBase>
    {
        private BossBase baseScript;
        private float targetPositionX;
        [SerializeField] private float movementSpeed;
        private Rigidbody2D rb;
        private bool changeToWait;
        private bool changeToAttack;
        [SerializeField] private float leftMostEdge;
        [SerializeField] private float rightMostEdge;

        public override void Init(BossBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<BossBase>();
            rb = parent.GetComponentInChildren<Rigidbody2D>();
            Enter();
        }

        public override void PlayAction()
        {
            MoveBoss();
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
            else if (changeToAttack)
            {
                _runner.SetAction(typeof(BossAttack));
            }
        }

        private void Enter()
        {
            changeToWait = false;
            changeToAttack = false;
        }

        public override void Exit()
        {

        }

        private bool EdgeFound()
        {
            if (rb.transform.position.x == leftMostEdge || rb.transform.position.x == rightMostEdge)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private void MoveBoss()
        {
            if (rb.transform.position.x != targetPositionX || EdgeFound())
            {
                rb.transform.position = Vector2.MoveTowards(rb.transform.position, new Vector2(targetPositionX, rb.transform.position.y), movementSpeed * Time.fixedDeltaTime);
            }

            else
            {
                if (rb.transform.position.x <= (targetPositionX + 0.2f) || rb.transform.position.x >= (targetPositionX - 0.2f))
                {
                    changeToAttack = true;
                }
                else
                {
                    changeToWait = true;
                }
            }
        }
    }
}