using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEngine.Animations;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Player/Actions/Jump")]

    public class PlayerJump : SubState<PlayerBase>
    {
        private PlayerBase baseScript;
        private PlayerAnimator animScript;
        private Rigidbody2D rb;
        private bool firstPass;
        private bool isJumping;
        private float jumpCounterCurr;
        [SerializeField] private float jumpCounterMax;
        [SerializeField] private float firstPassJumpForce;
        [SerializeField] private float jumpForce;
        private float horizontalInput;
        [SerializeField] private float horizontalDecelerationValue;
        private int currentDirection;

        public override void Init(PlayerBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<PlayerBase>();
            animScript = parent.GetComponentInChildren<PlayerAnimator>();
            rb = parent.GetComponentInChildren<Rigidbody2D>();
            currentDirection = baseScript.GetPlayerDirection();
            Enter();
        }

        public override void PlayAction()
        {
            GetVariableJump();
            GetMovementInput();
            ApplyMovement();
            ChangeAction();
        }

        public override void PlayFixedAction()
        {
        }

        private void Enter()
        {
            animScript.JumpAnim();
            isJumping = true;
            jumpCounterCurr = jumpCounterMax;
            firstPass = true;
        }

        public override void Exit()
        {
        }

        public override void ChangeAction()
        {
            if (!isJumping)
            {
                _runner.SetAction(typeof(PlayerFall));
            }
        }

        private void GetVariableJump()
        {
            if (!firstPass)
            {
                if (baseScript.GetJump() && jumpCounterCurr > 0)
                {
                    jumpCounterCurr -= Time.deltaTime;

                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }

                else
                {
                    isJumping = false;
                }
            }

            else
            {
                rb.velocity = new Vector2(rb.velocity.x, firstPassJumpForce);
                firstPass = false;
            }   
        }

        private void GetMovementInput()
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }  

        private void ApplyMovement()
        {
            if (currentDirection == 1 &&  horizontalInput < 0.2f)
            {
                rb.velocity = new Vector2((rb.velocity.x + (horizontalDecelerationValue + Time.fixedDeltaTime)), rb.velocity.y);
            }

            else if (currentDirection == -1 && horizontalInput > -0.2f)
            {
                rb.velocity = new Vector2(rb.velocity.x - (horizontalDecelerationValue + Time.fixedDeltaTime), rb.velocity.y);
            }
        }
    }
}