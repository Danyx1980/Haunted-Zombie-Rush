using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MovingObject {

    private Vector3 topPosition = new Vector3(0, 25, -4);
    private Vector3 bottomPosition = new Vector3(0, 11, -4);
    private float speed = 5f;

    private float waitTime = 0.5f; 
	// Use this for initialization
	void Start () {
        StartCoroutine(Move(bottomPosition));
        StartCoroutine(Rotate()); 
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update(); 
	}

    IEnumerator Move(Vector3 target)
    {
        while(Mathf.Abs((target - transform.position).y) > 0.2f)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * Time.deltaTime * speed;

            yield return null; 
        }

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(Move(target.y == topPosition.y ? bottomPosition : topPosition)); 
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(0, 3, 0);

            yield return null;
        }
    }
}
