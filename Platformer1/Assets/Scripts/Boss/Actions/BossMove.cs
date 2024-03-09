
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
        private BossAnim animScript;
        private float targetPositionX;
        private float targetDashPositionX;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float dashSpeed;
        private Rigidbody2D rb;
        private bool changeToWait;
        private bool changeToAttack;
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
            MoveBoss();
            ChangeAction();
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
            targetDashPositionX = baseScript.GetPlayerPositionX();
            //targetPositionX = rb.transform.position.x 
            if (targetPositionX > rb.transform.position.x)
            {
                currentDirection = 1;
            }
            else
            {
                currentDirection = -1;
            }
            rb.transform.localScale = new Vector2(Mathf.Abs(rb.transform.localScale.x) * currentDirection, rb.transform.localScale.y);
            animScript.RunAnim();
        }

        public override void Exit()
        {

        }

        private bool EdgeFound()
        {
            if (rb.transform.position.x <= leftMostEdge && currentDirection == -1)
            {
                return true;
            }

            else if (rb.transform.position.x >= rightMostEdge && currentDirection == 1)
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
            if (rb.transform.position.x != (targetPositionX) && !EdgeFound())
            {

                animScript.DashAnim();
                rb.transform.position = Vector2.MoveTowards(rb.transform.position, new Vector2(targetPositionX, rb.transform.position.y), movementSpeed * Time.fixedDeltaTime);
            }

            else
            {
                if (rb.transform.position.x != targetPositionX && !EdgeFound())
                {
                    animScript.DashAnim();
                    rb.transform.position = Vector2.MoveTowards(rb.transform.position, new Vector2(targetPositionX, rb.transform.position.y), dashSpeed * Time.fixedDeltaTime);
                }
                else
                {
                    changeToWait = true;
                }
            }
        }
    }
}


//