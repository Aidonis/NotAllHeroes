using UnityEngine;
using System.Collections;

public class Follow2D : MonoBehaviour {

    public Vector2 target;
    public float speed = 0;
    [SerializeField]
    private Vector2 thisSpot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        thisSpot = new Vector2(transform.position.x, transform.position.z);

        //

        Vector2 movement = (target - thisSpot).normalized;
        
        if ((target - thisSpot).magnitude < speed)
        {
            transform.position = new Vector3(target.x, transform.position.y, target.y);
        }
        else
        {
            transform.position += new Vector3(movement.x * speed, 0, movement.y * speed);
        }
	}
}
