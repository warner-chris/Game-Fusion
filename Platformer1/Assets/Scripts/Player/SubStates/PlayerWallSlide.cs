using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEngine.Animations;
using UnityEditor.Tilemaps;
using UnityEditor;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Player/Actions/WallSlide")]

    public class PlayerWallSlide : SubState<PlayerBase>
    {
        PlayerBase baseScript;
        Rigidbody2D rb;
        private float horizontalMovement;
        [SerializeField] private float airSpeed;
        private bool isWallSlide;

        public override void Init(PlayerBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<PlayerBase>();
            rb = parent.GetComponentInChildren<Rigidbody2D>();
            Enter();
        }

        public override void PlayAction()
        {
            GetInput();
            IsWallSlide();
            ApplyMovement();
            ChangeAction();
        }

        public override void PlayFixedAction()
        {

        }

        private void Enter()
        {
            isWallSlide = false;
        }

        public override void Exit()
        {

        }

        public override void ChangeAction()
        {
            if (!isWallSlide && baseScript.IsGrounded())
            {
                _runner.SetAction(typeof(PlayerMove));
            }
            else if (baseScript.GetJump())
            {
                _runner.SetAction(typeof(PlayerWallJump));
            }
            else if (!isWallSlide)
            {
                _runner.SetAction(typeof(PlayerFall));
            }
        }

        private void IsWallSlide()
        {
            if (baseScript.GetWallDirection() == 'R' && horizontalMovement > 0.2f)
            {
                isWallSlide = true;
            }
            else if (baseScript.GetWallDirection() == 'L' && horizontalMovement < -0.2f)
            {
                isWallSlide = true;
            }
            else
            {
                isWallSlide = false;
            }
        }

        private void GetInput()
        {
            horizontalMovement = Input.GetAxis("Horizontal");
        }

        private void ApplyMovement()
        {
            if (baseScript.GetWallDirection() == 'L' && horizontalMovement > 0.2f)
            {
                rb.velocity = new Vector2((rb.velocity.x + (airSpeed * Time.fixedDeltaTime)), rb.velocity.y);
            }

            else if (baseScript.GetWallDirection() == 'R' && horizontalMovement < -0.2f)
            {
                rb.velocity = new Vector2((rb.velocity.x - (airSpeed * Time.fixedDeltaTime)), rb.velocity.y);
            }
        }
    }
}
