using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] public GameObject coin;
    public PipeMoveScript pipemove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * pipemove.moveSpeed) * Time.deltaTime;

        if (transform.position.x < pipemove.deadZone && gameObject != null) {
            //Debug.Log("Coin deleted");
            Destroy(gameObject);
        }
        
        if (!BirdScript.BirdIsAlive) {
            this.enabled = false;
            //Debug.Log("Coin movement disabled");
        }
    }

    public void SpawnCoin(float x, float topY, float botY) {
        float coinY = (topY + botY) / 2;
        Instantiate(coin, new Vector3(x, coinY, 0), transform.rotation);
    }
}
