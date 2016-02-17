using UnityEngine;
using System.Collections;

namespace TDShooter
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {

        public enum State { Idle, Moving, Attacking };
        State currentState;

        Rigidbody myRigidBody;
        Vector3 velocity;

        bool hasTarget = false;

        // Use this for initialization
        void Start()
        {
            myRigidBody = GetComponent<Rigidbody>();

            if (hasTarget != null)
            {

            }
        }

        void FixedUpdate()
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.fixedDeltaTime);
        }

        public void Move(Vector3 _velocity)
        {
            //velocity = _velocity;
        }

        public void LookAt(Vector3 lookPoint)
        {
            Vector3 heightCorrection = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
            transform.LookAt(heightCorrection);
        }

        public void MoveTo(Vector3 _position)
        {

        }
    }
}