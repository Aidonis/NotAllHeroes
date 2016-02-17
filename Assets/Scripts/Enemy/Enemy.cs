using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity {

    public enum State { Idle, Chasing, Attacking };
    State currentState;

    // Use this for initialization
    void Start () {
        gameObject.tag = "Enemy";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}