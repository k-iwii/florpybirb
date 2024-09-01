using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) {
            // Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
        
        if (!BirdScript.BirdIsAlive) {
            this.enabled = false;
            //Debug.Log("Pipe movement disabled");
        }
    }
}
