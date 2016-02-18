using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class Player : LivingEntity {

    private float inputDelay = 0;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
        gameObject.tag = "Player";
    }
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();

        if (inputDelay > 0)
        {
            inputDelay -= Time.deltaTime;
        }

        if (currentState == LivingEntityState.Idle && inputDelay <= 0)
        {
            //Remapping of keys?
            if (Input.GetMouseButtonDown(0))
            {
                Target();
                inputDelay = 0.25f;
            }
            if (Input.GetMouseButton(1))
            {
                Move();
                inputDelay = 0.25f;
            }
            if (Input.GetMouseButtonDown(1))
            {
                Action();
            }
        }
	}



    //Combat oriented context actions + move
    //
    public void Action()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            if (hit.transform.tag == "Enemy")
            {
                //Approach and attack somehow
                target = hit.transform.gameObject.GetComponent<LivingEntity>();
                chasing = true;
                Debug.Log("Enemy Clicked: " + hit.transform.gameObject.name);
            }
            //If within auto attack range of target don't move
            //Move(hit.point);
            //agent.destination = hit.point;
        }
    }

    //Movement split from Action incase of constant input (Mousebutton > MousebuttonDown)
    public void Move()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            Move(hit.point);
            chasing = false;
        }
    }

    public void Target()
    {
        //Non-Combat context based actions
        //
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            //Replace with IInteractable interface check
            if (hit.transform.tag == "Interactable")
            {
                //Fire off context based interaction event
            }

            Debug.Log("Object Clicked: " + hit.transform.gameObject.name);
        }
    }
}
