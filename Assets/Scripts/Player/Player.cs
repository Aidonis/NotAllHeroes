using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class Player : LivingEntity {

    PlayerController control;

	// Use this for initialization
	void Start () {
        base.Start();
        control = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

        //Remapping of keys?
        if (Input.GetMouseButtonDown(0))
        {
            control.Target();
        }
        if (Input.GetMouseButton(1))
        {
            control.Move();
        }
        if (Input.GetMouseButtonDown(1))
        {
            control.Action();
        }
	}
}
