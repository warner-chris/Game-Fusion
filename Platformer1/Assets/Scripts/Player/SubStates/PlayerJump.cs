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
        PlayerBase baseScript;
        Rigidbody2D rb;
        private bool firstPass;
        private bool isJumping;
        private int jumpCounterCurr;
        [SerializeField] private int jumpCounterMax;
        [SerializeField] private float firstPassJumpForce;
        [SerializeField] private float jumpForce;
        private float horizontalInput;
        [SerializeField] private float horizontalDecelerationValue;
        private int playerMovementDirection;
        private float newHorizontalVelocity;
        [SerializeField] private float maxWalkVelocity;


        public override void Init(PlayerBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<PlayerBase>();
            rb = parent.GetComponentInChildren<Rigidbody2D>();
            playerMovementDirection = baseScript.GetPlayerDirection();
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
            isJumping = true;
            jumpCounterCurr = 0;
            firstPass = true;
        }

        public override void Exit()
        {
        }

        public override void ChangeAction()
        {
            if (!isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                _runner.SetAction(typeof(PlayerFall));
            }
        }

        //Change Gravity -
        private void GetVariableJump()
        {
            if (!firstPass)
            {
                if (baseScript.GetJump() && jumpCounterCurr <= jumpCounterMax)
                {
                    jumpCounterCurr++;
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpForce);
                }

                else
                {
                    isJumping = false;
                }
            }

            else
            {
                rb.velocity = new Vector2((rb.velocity.x/2), rb.velocity.y + firstPassJumpForce);
                firstPass = false;
            }   
        }

        private void GetMovementInput()
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }  

        private void ApplyMovement()
        {
            if (playerMovementDirection == 1 &&  horizontalInput < 0.2f)
            {
                newHorizontalVelocity = (rb.velocity.x + (horizontalDecelerationValue + Time.fixedDeltaTime));
                CheckMaxVelocity();
            }

            else if (playerMovementDirection == -1 && horizontalInput > -0.2f)
            {
                newHorizontalVelocity = (rb.velocity.x + (horizontalDecelerationValue + Time.fixedDeltaTime));
                CheckMaxVelocity();
            }
        }

        private void CheckMaxVelocity()
        {
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