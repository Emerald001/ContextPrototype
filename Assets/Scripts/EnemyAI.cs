using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Vector3[] positions;
    public GameObject player;
    public float speed;
    public float viewDis;

    private Vector3 currentPos;
    private int index;
    private StateMachine<EnemyState> enemyStateMachine = new StateMachine<EnemyState>(); 

    void Start() {
        
    }

    void Update() {
        if(transform.position == currentPos) {
            index++;

            if (index > positions.Length - 1)
                index = 0;

            currentPos = positions[index];
        }

        if(Vector3.Distance(transform.position, player.transform.position) < viewDis) {
            currentPos = player.transform.position;
        }
        else {
            currentPos = positions[index];
        }

        transform.position = Vector3.MoveTowards(transform.position, currentPos, speed * Time.deltaTime);
    }

    public void SwitchState(System.Type stateTo) {

    }

    public bool PlayerInRange() {
        return Vector3.Distance(transform.position, player.transform.position) < viewDis;
    }

    public void AddTransitionWithBool(State _state, bool _bool, System.Type _stateTo) {
        _state.AddTransition(new Transition(
            (x) => {
                if (_bool)
                    return true;
                return false;
            }, _stateTo));
    }
}