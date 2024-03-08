using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEngine.Animations;
using UnityEditor.Tilemaps;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Player/Actions/WallJump")]

    public class PlayerWallJump : SubState<PlayerBase>
    {
        private PlayerBase baseScript;
        private Rigidbody2D rb;
        private bool isJumping;


        public override void Init(PlayerBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<PlayerBase>();
            rb = parent.GetComponentInChildren<Rigidbody2D>();
            Enter();
        }

        public override void PlayAction()
        {
            ChangeAction();
        }

        public override void PlayFixedAction()
        {

        }

        public void Enter()
        {
            
        }

        public override void Exit()
        {

        }

        public override void ChangeAction()
        {
            if (false)
            {
                //not holding in while touching
                _runner.SetAction(typeof(PlayerFall));
            }
            else if (false)
            {
                //holding in while touching
                _runner.SetAction(typeof(PlayerWallSlide));
            }
        }
    }
}
