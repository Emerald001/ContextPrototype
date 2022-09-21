using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : State {
    public EnemyAI owner;

    public EnemyState(EnemyAI owner) {
        this.owner = owner;
    }

    public override void OnEnter() { }

    public override void OnExit() { }

    public override void OnUpdate() {
        foreach (var transition in transitions) {
            if (transition.condition.Invoke(owner.gameObject)) {
                Debug.Log("Change State");

                owner.SwitchState(transition.toState);
                return;
            }
        }
    }
}