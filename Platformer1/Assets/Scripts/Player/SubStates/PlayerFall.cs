using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEditor;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Player/Actions/Fall")]

    public class PlayerFall : SubState<PlayerBase>
    {
        private PlayerBase baseScript;
        private PlayerAnimator animScript;
        private Rigidbody2D rb;
        [SerializeField] private float airSpeed;
        [SerializeField] private float gravMultiplier;
        private float horizontalMovement;
        private float currentFallSpeed;

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
            ChangeAction();
            ApplyMovement();
            IncreaseGrav();
        }

        public override void PlayFixedAction()
        {
        }

        public override void ChangeAction()
        {
            if (baseScript.IsGrounded())
            {
                if (horizontalMovement < 0.2f && horizontalMovement > -0.2f)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
                _runner.SetAction(typeof(PlayerMove));
            }
        }

        private void Enter()
        {
            //rb.velocity = new Vector2(rb.velocity.x/2, rb.velocity.y);
        }

        public override void Exit()
        {
        }

        private void IncreaseGrav()
        {
            currentFallSpeed = rb.velocity.y - (gravMultiplier * Time.fixedDeltaTime);
            if (currentFallSpeed <= -50)
            {
                rb.velocity = new Vector2(rb.velocity.x, -50);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, currentFallSpeed);
            }
            
        }

        private void GetInput()
        {
            horizontalMovement = Input.GetAxis("Horizontal");
        }

        private void ApplyMovement()
        {
            if (horizontalMovement > 0.2f)
            {
                rb.velocity = new Vector2((rb.velocity.x + (airSpeed * Time.fixedDeltaTime)), rb.velocity.y);
            }

            else if (horizontalMovement < -0.2f)
            {
                rb.velocity = new Vector2((rb.velocity.x - (airSpeed * Time.fixedDeltaTime)), rb.velocity.y);
            }
        }
    }
}
