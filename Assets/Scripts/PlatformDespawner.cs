using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDespawner : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Tile"))
            other.gameObject.transform.position = new Vector3(21, 10, -4);
        if (other.gameObject.name.Contains("Bridge"))
            other.gameObject.transform.position = new Vector3(26.5f, 10, -4); 
    }
}
