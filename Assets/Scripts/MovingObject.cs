using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    [SerializeField]
    private float Speed = 5; 

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    protected virtual void Update() {
        transform.Translate(new Vector3(-1, 0, 0) * (Speed * Time.deltaTime), Space.World); 
	}
}
