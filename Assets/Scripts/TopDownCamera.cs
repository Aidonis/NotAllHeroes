using UnityEngine;
using System.Collections;

public class TopDownCamera : MonoBehaviour {

    public float height = 15.0f;
    public float distance = -10.0f;
    public Transform target;

    Vector3 cameraPosition;

	// Use this for initialization
	void Start () {
	}
 
    void  Update()
    {
        cameraPosition = new Vector3(0, height, distance);
        transform.position = target.position + cameraPosition;
        transform.LookAt(target.position);
    }
}
