using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

    enum MobState { NEUTRAL, ATTACKING };

    public bool life = true;
    public float health = 100;
    public float movementSpeed = 0.05f;
    public Mob target;
    public float attackRange = 2;
    public float attackDamage = 2;
    private MobState state = MobState.NEUTRAL;
    private float attackTime = 0;

    public float distanceToTarget
    {
        get
        {
            if (target)
            {
                return (target.transform.position - transform.position).magnitude;
            }
            else
            {
                return Mathf.Infinity;
            }
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	void Update()
    {
        if (state == MobState.ATTACKING)
        {
            attackTime -= Time.deltaTime;
            if (attackTime <= 0)
            {
                state = MobState.NEUTRAL;
            }
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
	    if (life)
        {
            // Attack target
            if (target && state == MobState.NEUTRAL)
            {
                if (distanceToTarget > attackRange)
                {
                    MoveTowardsTarget();
                }
                else if (distanceToTarget <= attackRange)
                {
                    AttackTarget();
                }
            }
        }
	}

    public virtual void TakeDamage(float _amount)
    {
        if (_amount >= health)
        {
            health = 0;
            life = false;
            // Destroy on death (Temporary)
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            health -= _amount;
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 movement = (target.transform.position - transform.position).normalized;

        if ((target.transform.position - transform.position).magnitude < movementSpeed)
        {
            transform.position = target.transform.position;
        }
        else
        {
            transform.position += movement * movementSpeed;
        }
    }

    void AttackTarget()
    {
        if (target)
        {
            state = MobState.ATTACKING;
            attackTime = 1;
            target.TakeDamage(attackDamage);
        }
    }
}
