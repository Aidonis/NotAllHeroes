using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour {

    public enum State { Idle, Moving, Attacking };

    State currentState;
    Rigidbody myRigidBody;
    NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        gameObject.tag = "Player";
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    //Combat oriented context actions + move
    //
    public void Action()
    {  
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            if(hit.transform.tag == "Enemy")
            {
                //Approach and attack somehow
                Debug.Log("Enemy Clicked: " + hit.transform.gameObject.name);
            }

            //If within auto attack range of target don't move
            agent.destination = hit.point;
        }
    }

    //Movement split from Action incase of constant input (Mousebutton > MousebuttonDown)
    public void Move()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            agent.destination = hit.point;
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
            if(hit.transform.tag == "Interactable")
            {
                //Fire off context based interaction event
            }

            Debug.Log("Object Clicked: " + hit.transform.gameObject.name);
        }
    }
}
