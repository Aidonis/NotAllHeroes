using UnityEngine;
using System.Collections;

namespace TDShooter {

    [RequireComponent(typeof(NavMeshAgent))]
    public class Player : LivingEntity
    {
        Camera viewCamera;

        public float moveSpeed = 5;

        NavMeshAgent pathfinder;
        Vector3 moveTarget;
        bool hasMoveTarget;

        // Use this for initialization
        protected override void Start()
        {
            base.Start();
            pathfinder = GetComponent<NavMeshAgent>();
            viewCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            //Movement Input
            //Look Input
            Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                //Debug.DrawLine(ray.origin, point, Color.red);
            }

            if (hasMoveTarget)
            {
                StartCoroutine(UpdatePath());
            }

            //Movement
            if (Input.GetMouseButtonDown(1))
            {
                hasMoveTarget = true;
                moveTarget = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
                Debug.Log("Right-Click: " + moveTarget);
            }
        }

        IEnumerator UpdatePath()
        {
            Debug.Log("Update Path Started");
            float refreshRate = .25f;

            while (hasMoveTarget)
            {
                Vector3 dirToTarget = (moveTarget - transform.position).normalized;

                Vector3 targetPosition = moveTarget - dirToTarget;

                pathfinder.SetDestination(targetPosition);

                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
}