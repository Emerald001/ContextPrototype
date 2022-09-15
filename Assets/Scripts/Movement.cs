using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController contr;
    public Animator mannetje;
    public float speed;
    public float croughSpeed;

    public bool croughing;

    // Start is called before the first frame update
    void Start() {
        contr = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(!croughing)
            contr.Move(new Vector3(input.x, 0, input.y) * speed * Time.deltaTime);
        else if (croughing)
            contr.Move(new Vector3(input.x, 0, input.y) * croughSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            croughing = !croughing;

            if (croughing)
                GoSmol();
            else if (!croughing)
                GoBig();
        }
    }

    void GoSmol() {
        contr.height = .5f;
        contr.center = new Vector3(0, .5f, 0);
    }

    void GoBig() {
        contr.height = 1f;
        contr.center = new Vector3(0, 1f, 0);
    }
}