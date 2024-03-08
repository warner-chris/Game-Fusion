using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "Player/States/Actionable")]

    public class Actionable : State<PlayerBase>
    {
        PlayerBase baseScript;
        public override void Init(PlayerBase parent)
        {
            base.Init(parent);
            baseScript = parent.GetComponentInChildren<PlayerBase>();
            ChangeAction();
        }

        public override void Update()
        {
            _runner.GetActiveAction().PlayAction();
            baseScript.SetJump();
            Debug.Log(baseScript.IsWalled());
        }

        public override void FixedUpdate()
        {
            _runner.GetActiveAction().PlayFixedAction();
        }

        public override void ChangeAction()
        {
            _runner.SetAction(typeof(PlayerMove));
        }

        public override void ChangeState()
        {

        }

        public override void Exit()
        {

        }
    }
}
