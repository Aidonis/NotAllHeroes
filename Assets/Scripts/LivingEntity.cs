using UnityEngine;
using System.Collections;

public class LivingEntity : MonoBehaviour//, IDamageable
{
    public enum LivingEntityState { Idle, Moving, Attacking };

    protected Rigidbody myRigidBody;
    protected NavMeshAgent agent;

    LivingEntityState CurrentState;
    public LivingEntityState currentState
    {
        get
        {
            return CurrentState;
        }
    }
    [SerializeField]
    protected bool chasing = false;

    protected bool life = true;
    //public float startingHealth;
    [SerializeField]
    public float health;
    [SerializeField]
    protected float range;
    [SerializeField]
    protected float attackDamage;
    private float attackTime;


    public LivingEntity target;
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

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    protected virtual void Update()
    {
        switch (CurrentState)
        {
                // ====
            case LivingEntityState.Idle:
                if (target && chasing)
                {
                    if (!AttackTarget(true))
                    {
                        Move(target);
                    }
                } 
                else
                {
                    chasing = false;
                }
                break;
                // ====
            case LivingEntityState.Moving:
                break;
                // ====
            case LivingEntityState.Attacking:
                agent.destination = transform.position;
                if (attackTime > 0)
                {
                    attackTime -= Time.deltaTime;
                }
                else
                {
                    CurrentState = LivingEntityState.Idle;
                }
                break;
                // ====
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage >= health)
        {
            health = 0;
            Die();
        }
        else
        {
            health -= damage;
        }
    }

    protected void Move(Vector3 _dest)
    {
        agent.destination = _dest;
        //chasing = false;
    }
    protected void Move(LivingEntity _target)
    {
        agent.destination = _target.transform.position;
    }

    protected virtual bool AttackTarget(bool _repeatAttack)
    {
        if (distanceToTarget <= range)
        {
            CurrentState = LivingEntityState.Attacking;
            attackTime = 1;
            //animation trigger goes here
            target.TakeDamage(attackDamage);
            Debug.Log(gameObject.name + " Attacked " + target.gameObject.name + "!!");
            if (!_repeatAttack)
            {
                chasing = false;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    [ContextMenu("Self Destruct")]
    protected void Die()
    {
        life = false;
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }




}