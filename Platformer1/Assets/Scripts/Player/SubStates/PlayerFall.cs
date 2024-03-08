using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Player/Actions/Fall")]

    public class PlayerFall : SubState<PlayerBase>
    {
        private PlayerBase baseScript;
        private Rigidbody2D rb;
        [SerializeField] private float airSpeed;
        [SerializeField] private float gravMultiplier;
        private float horizontalMovement;
        private float currentFallSpeed;
        private int playerMovementDirection;
        private float newHorizontalVelocity;
        [SerializeField] private float maxWalkVelocity;

        public override void Init(PlayerBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<PlayerBase>();
            rb = parent.GetComponentInChildren<Rigidbody2D>();
            playerMovementDirection = baseScript.GetPlayerDirection();
        }

        public override void PlayAction()
        {
            IncreaseGrav();
            GetInput();
            ApplyMovement();
        }

        public override void PlayFixedAction()
        {
            ChangeAction();
        }

        public override void ChangeAction()
        {
            if (baseScript.IsGrounded())
            {
                _runner.SetAction(typeof(PlayerMove));
            }
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
                newHorizontalVelocity = (rb.velocity.x + (airSpeed * Time.fixedDeltaTime));
                CheckMaxVelocity();
            }

            else if (horizontalMovement < -0.2f)
            {
                newHorizontalVelocity = (rb.velocity.x - (airSpeed * Time.fixedDeltaTime));
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
