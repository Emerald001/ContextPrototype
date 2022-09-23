using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : EnemyState {

    public bool IsDone = false;

    public NavMeshAgent agent;

    public PatrolState(StateMachine<EnemyAI> stateMachine, EnemyAI owner, NavMeshAgent agent) : base(stateMachine, owner) {
        this.agent = agent;
    }

    public override void OnEnter() {
        IsDone = false;

        var pos = RandomNavmeshLocation(owner.transform.position, owner.walkingRange);
        while (pos == Vector3.zero) {
            pos = RandomNavmeshLocation(owner.transform.position, owner.walkingRange);
        }

        agent.SetDestination(pos);
    }

    public override void OnExit() {
        IsDone = false;
    }

    public override void OnUpdate() {
        base.OnUpdate();

        if (owner.transform.position == agent.destination)
            IsDone = true;
    }

    public Vector3 RandomNavmeshLocation(Vector3 pos, float radius) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += pos;
        Vector3 finalPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}