using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    public Animator anim;

    public void Update()
    {
        bool pose1 = Input.GetKey(KeyCode.Q);
        bool pose2 = Input.GetKey(KeyCode.W);
        bool pose3 = Input.GetKey(KeyCode.E);

        if (pose1) { anim.SetTrigger("Anim1"); }
        if (pose2) { anim.SetTrigger("Anim2"); }
        if (pose3) { anim.SetTrigger("Anim3"); }
    }
    public void Reset()
    {
        anim = GetComponent<Animator>();

    }
}
