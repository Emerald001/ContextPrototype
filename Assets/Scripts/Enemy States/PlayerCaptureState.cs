using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaptureState : EnemyState {

    GameObject Player;

    public PlayerCaptureState(StateMachine<EnemyAI> stateMachine, EnemyAI owner, GameObject Player) : base(stateMachine, owner) {
        this.Player = Player;
    }

    public override void OnEnter() {

    }

    public override void OnExit() {

    }

    public override void OnUpdate() {
        owner.transform.position = Vector3.MoveTowards(owner.transform.position, Player.transform.position, owner.speed);
    }
}