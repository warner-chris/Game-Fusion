using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Player/States/PlayerKnockedBack")]

    public class PlayerKnockedBack : State<PlayerBase>
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

        public override void Update()
        {
            GetInput();
            ChangeState();
            ApplyMovement();
            IncreaseGrav();
        }

        public override void FixedUpdate()
        {
            _runner.GetActiveAction().PlayFixedAction();
        }

        public override void ChangeAction()
        {
        }

        public override void ChangeState()
        {
            if (baseScript.IsGrounded())
            {
                rb.rotation = 0f;
                _runner.SetState(typeof(Actionable));
            }
        }

        private void Enter()
        {
            animScript.HurtAnim();
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
