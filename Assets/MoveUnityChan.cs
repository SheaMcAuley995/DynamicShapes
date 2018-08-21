using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnityChan : MonoBehaviour {

    Rigidbody rb;
    Animator anim;

	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); 
	}

	void Update () {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        rb.velocity = input * 2.0f;
	}
}
