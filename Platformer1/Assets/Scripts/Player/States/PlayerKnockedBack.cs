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
        [SerializeField] private float jumpForce;
        private float horizontalMovement;
        private float currentFallSpeed;
        private bool canFall;
        private float currJumpTimer;
        [SerializeField] private float maxJumpTimer;


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
            currJumpTimer -= Time.deltaTime;
            if (currJumpTimer <= 0)
            {
                canFall = true;
            }

            if (canFall)
            {
                GetInput();
                ChangeState();
                ApplyMovement();
                IncreaseGrav();
            }

            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
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
                rb.velocity = Vector2.zero;
                rb.rotation = 0f;
                _runner.SetState(typeof(Actionable));
            }
        }

        private void Enter()
        {
            animScript.HurtAnim();
            currJumpTimer = maxJumpTimer;
            canFall = false;
        }

        public override void Exit()
        {

        }

        private void IncreaseGrav()
        {
            currentFallSpeed = rb.velocity.y - (gravMultiplier * Time.deltaTime);
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
                rb.velocity = new Vector2((rb.velocity.x + (airSpeed * Time.deltaTime)), rb.velocity.y);
            }

            else if (horizontalMovement < -0.2f)
            {
                rb.velocity = new Vector2((rb.velocity.x - (airSpeed * Time.deltaTime)), rb.velocity.y);
            }
        }
    }
}
