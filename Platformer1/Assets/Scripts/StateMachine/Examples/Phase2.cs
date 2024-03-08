/*using Statemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "States/Boss/Phase2")]


    public class Phase2 : State<KainBase>
    {
        EnemyHealth healthScript;
        private int currentPhase;
        KainBase baseScript;

        private int currentAction = 0;
        private bool playerinRange = false;
        private bool attackOnCooldown = false;

        SpriteRenderer sprite;

        public override void Init(KainBase parent)
        {
            base.Init(parent);
            healthScript = parent.GetComponentInChildren<EnemyHealth>();
            baseScript = parent.GetComponentInChildren<KainBase>();
            sprite = parent.GetComponentInChildren<SpriteRenderer>();
            SetColor();
            ChangeAction(); 
        }

        public override void Update()
        {
            baseScript.IncrementTimers();
            _runner.GetActiveAction().PlayAction();
            currentPhase = healthScript.GetPhase();
        }

        public override void FixedUpdate()
        {

        }

        public override void ChangeState()
        {
            if (currentPhase > 3)
            {
                _runner.SetState(typeof(Phase2Dot5));
                Debug.Log("Go to phase 2.5");
            }
        }

        public override void ChangeAction()
        {
            _runner.SetAction(typeof(Chase));
        }


        public override void Exit()
        {

        }

        private void SetColor()
        {
            sprite.color = new Color(1, 0, 0, 1);
        }
    }
}*/