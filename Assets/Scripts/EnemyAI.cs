using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Vector3[] positions;
    public GameObject player;
    public float speed;
    public float viewDis;
    public float viewAngle;

    private Vector3 currentPos;
    private int index;
    private StateMachine<EnemyAI> enemyStateMachine;
    private EnemyAIEvaluator evaluator;

    void Start() {
        enemyStateMachine = new StateMachine<EnemyAI>(this);
        evaluator = new EnemyAIEvaluator(this);
    }

    void Update() {
        Debug.Log(evaluator.PlayerSeen(player));

        //if(transform.position == currentPos) {
        //    index++;

        //    if (index > positions.Length - 1)
        //        index = 0;

        //    currentPos = positions[index];
        //}

        //if(Vector3.Distance(transform.position, player.transform.position) < viewDis) {
        //    currentPos = player.transform.position;
        //}
        //else {
        //    currentPos = positions[index];
        //}

        //transform.position = Vector3.MoveTowards(transform.position, currentPos, speed * Time.deltaTime);
    }

    public void SwitchState(System.Type stateTo) {

    }

    public bool PlayerInRange() {
        return Vector3.Distance(transform.position, player.transform.position) < viewDis;
    }

    public void AddTransitionWithBool(State<EnemyAI> state, bool check, System.Type stateTo) {
        state.AddTransition(new Transition<EnemyAI>(
            (x) => {
                if (check)
                    return true;
                return false;
            }, stateTo));
    }
}