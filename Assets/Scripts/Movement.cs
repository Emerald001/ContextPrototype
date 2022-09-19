using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController contr;
    public Animator mannetje;
    public float speed;
    public float croughSpeed;

    public bool crouching;

    // Start is called before the first frame update
    void Start() {
        contr = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (input.magnitude > 0) {
            mannetje.SetBool("Walking", true);
            transform.LookAt(transform.position + input, Vector3.up);
        } 
        else {
            mannetje.SetBool("Walking", false);
        }

        if(!crouching)
            contr.Move(new Vector3(input.x, 0, input.z) * speed * Time.deltaTime);
        else if (crouching)
            contr.Move(new Vector3(input.x, 0, input.z) * croughSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            crouching = !crouching;

            if (crouching)
                GoSmol();
            else if (!crouching)
                GoBig();
        }
    }

    void GoSmol() {
        contr.height = .5f;
        contr.center = new Vector3(0, .5f, 0);

        mannetje.SetBool("Walking", false);
        mannetje.SetTrigger("Switch");
    }

    void GoBig() {
        contr.height = 1f;
        contr.center = new Vector3(0, 1f, 0);

        mannetje.SetBool("Walking", false);
        mannetje.SetTrigger("Switch");
    }
}