using UnityEngine;
using System.Collections;

public class Follow3D : MonoBehaviour {

    public Vector3 target;
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = (target - transform.position).normalized;

        if ((target - transform.position).magnitude < speed)
        {
            transform.position = target;
        }
        else
        {
            transform.position += movement * speed;
        }
	}
}
