using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity {
    
    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
        gameObject.tag = "Enemy";
    }
	
	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();

        if (currentState == LivingEntityState.Idle)
        {
            if (target)
            {
                chasing = true;
                Move(target);
            }
        }

    }
}