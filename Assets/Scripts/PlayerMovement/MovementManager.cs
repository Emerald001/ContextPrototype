using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public Vector3 velocity;

    //StateMachine
    private StateMachine<MovementManager> movementStateMachine;

    [Header("Objects Needed")]
    public GameObject Visuals;
    public GameObject GroundCheck;
    public Animator animator;
    public Transform SlopeTransform;
    public Transform YRotationParent;
    public LayerMask GroundLayer;
    [HideInInspector] public CharacterController controller;
    [HideInInspector] public MovementEvaluator evaluator;

    [Header("World Settings")]
    public float gravity = -19.62f;
    public float airDrag = 10;
    public float Acceleration;

    [Header("Player Settings")]
    public float maxSpeed;
    public float speed;
    public float airbornSpeed;
    public float runSpeed;
    public float crouchSpeed;
    public float jumpHeight;
    [HideInInspector] public int jumpAmount = 0;

    //Keep Track of Info
    [HideInInspector] public Vector3 CurrentDirection; 
    [HideInInspector] public Vector3 GroundAngle; 

    void Start() {
        controller = GetComponent<CharacterController>();

        movementStateMachine = new StateMachine<MovementManager>(this);

        evaluator = new MovementEvaluator();
        evaluator.owner = this;

        var groundedState = new GroundedState(movementStateMachine);
        movementStateMachine.AddState(typeof(GroundedState), groundedState);
        AddTransitionWithPrediquete(groundedState, (x) => { return !evaluator.IsGrounded(); }, typeof(AirbornState));
        AddTransitionWithBool(groundedState, !evaluator.IsGrounded(), typeof(AirbornState));
        AddTransitionWithKey(groundedState, KeyCode.LeftControl, typeof(CrouchingState));

        var airbornState = new AirbornState(movementStateMachine);
        movementStateMachine.AddState(typeof(AirbornState), airbornState);
        AddTransitionWithPrediquete(airbornState, (x) => { return evaluator.IsGrounded(); }, typeof(GroundedState));

        var crouchingState = new CrouchingState(movementStateMachine);
        AddTransitionWithPrediquete(crouchingState, (x) => { return !evaluator.IsGrounded(); }, typeof(AirbornState));
        movementStateMachine.AddState(typeof(CrouchingState), crouchingState);
        AddTransitionWithPrediquete(crouchingState, (x) => {
            if (Input.GetKeyDown(KeyCode.LeftControl)) {
                if (!evaluator.TouchedRoof()) {
                    return true;
                }
                return false;
            }
            return false;
        }, typeof(GroundedState));

        movementStateMachine.ChangeState(typeof(GroundedState));
    }

    void Update() {
        movementStateMachine.OnUpdate();

        SlopeTransform.rotation = Quaternion.FromToRotation(SlopeTransform.up, evaluator.GetSlopeNormal()) * SlopeTransform.rotation;
        SlopeTransform.localEulerAngles = new Vector3(SlopeTransform.localEulerAngles.x, 0, SlopeTransform.localEulerAngles.z);

        controller.Move(velocity * Time.deltaTime);

        if(velocity.magnitude > 1) {
            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, velocity.normalized, 30 * Time.deltaTime, 0f);
            desiredForward.y = 0;
            transform.LookAt(transform.position + desiredForward);
        }
    }

    public void AddTransitionWithKey(State<MovementManager> state, KeyCode keyCode, System.Type stateTo) {
        state.AddTransition(new Transition<MovementManager>(
            (x) => {
                if (Input.GetKeyDown(keyCode)) {
                    return true;
                }
                return false;
            }, stateTo));
    }
    public void AddTransitionWithBool(State<MovementManager> state, bool check, System.Type stateTo) {
        state.AddTransition(new Transition<MovementManager>(
            (x) => {
                if (check)
                    return true;
                return false;
            }, stateTo));
    }
    public void AddTransitionWithPrediquete(State<MovementManager> state, System.Predicate<MovementManager> predicate, System.Type stateTo) {
        state.AddTransition(new Transition<MovementManager>(predicate, stateTo));
    }
}