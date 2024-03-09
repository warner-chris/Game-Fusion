using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System.Runtime.CompilerServices;
using UnityEditor;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Player/Actions/Move")]

    public class PlayerMove : SubState<PlayerBase>
    {
        private PlayerBase baseScript;
        private PlayerAnimator animScript;
        private Rigidbody2D rb;
        private float moveHorizontal;
        [SerializeField] private float baseSpeed;
        private int playerMovementDirection;
        private float newHorizontalVelocity;
        [SerializeField] private float maxWalkVelocity;
        [SerializeField] private float maxRunVelocity;
        private bool firstPass;
        [SerializeField] private float firstPassVelocityCut;

        public override void Init(PlayerBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<PlayerBase>();
            animScript = parent.GetComponentInChildren<PlayerAnimator>();
            rb = parent.GetComponentInChildren<Rigidbody2D>();
            Enter();
        }

        public override void PlayAction()
        {
            GetInput();
            MoveCheck();
            ChangeAction();
        }

        public override void PlayFixedAction()
        {
        }

        public override void ChangeAction()
        {
            if (baseScript.GetJump())
            {
                _runner.SetAction(typeof(PlayerJump));
            }

            else if (!baseScript.IsGrounded())
            {
                _runner.SetAction(typeof(PlayerFall));
            }
        }

        private void Enter()
        {
            firstPass = true;
        }

        public override void Exit()
        {
        }

        private void GetInput() 
        {
            moveHorizontal = Input.GetAxis("Horizontal");
        }

        private void MoveCheck()
        {
            if (!firstPass)
            {
                ApplyMovement();
            }
            else
            {
                if (moveHorizontal > -0.2f && moveHorizontal < 0.2f)
                {
                    animScript.IdleAnim();
                    rb.velocity = Vector2.zero;
                }
                else if (moveHorizontal < -0.2f && rb.velocity.x > 0.1f)
                {
                    playerMovementDirection = -1;

                    rb.transform.localScale = new Vector2(Mathf.Abs(rb.transform.localScale.x) * playerMovementDirection, rb.transform.localScale.y);
                    animScript.RunAnim();
                    rb.velocity = new Vector2((rb.velocity.x / firstPassVelocityCut), rb.velocity.y);
                }
                else if (moveHorizontal > 0.2f && rb.velocity.x  < -0.1f)
                {
                    playerMovementDirection = 1;

                    rb.transform.localScale = new Vector2(Mathf.Abs(rb.transform.localScale.x) * playerMovementDirection, rb.transform.localScale.y);
                    animScript.RunAnim();
                    rb.velocity = new Vector2((rb.velocity.x / firstPassVelocityCut), rb.velocity.y);
                }
                else
                {
                    ApplyMovement();
                }
                firstPass = false;
            }
        }

        private void ApplyMovement()
        {
            if (moveHorizontal < 0.2f && moveHorizontal > -0.2f)
            {
                animScript.IdleAnim();
                rb.velocity = Vector2.zero;
            }
            else
            {
                if (moveHorizontal > 0.2f)
                {
                    playerMovementDirection = 1;
                    rb.transform.localScale = new Vector2(Mathf.Abs(rb.transform.localScale.x) * playerMovementDirection, rb.transform.localScale.y);
                    newHorizontalVelocity = (rb.velocity.x + (baseSpeed * Time.fixedDeltaTime));
                    CheckMaxVelocity();
                }
                else if (moveHorizontal < -0.2f)
                {
                    playerMovementDirection = -1;
                    rb.transform.localScale = new Vector2(Mathf.Abs(rb.transform.localScale.x) * playerMovementDirection, rb.transform.localScale.y);
                    newHorizontalVelocity = (rb.velocity.x - (baseSpeed * Time.fixedDeltaTime));
                    CheckMaxVelocity();
                }
            }
        }

        private void CheckMaxVelocity()
        {
            animScript.RunAnim();
            if (Mathf.Abs(newHorizontalVelocity) >= maxWalkVelocity)
            {
                rb.velocity = new Vector2((playerMovementDirection * maxWalkVelocity), rb.velocity.y);
            }

            else
            {
                rb.velocity = new Vector2(newHorizontalVelocity, rb.velocity.y);
            }
        }
    }
}
