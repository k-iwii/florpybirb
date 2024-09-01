using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject bottomPipe;
    public GameObject topPipe;
    public GameObject detector;
    public GameObject coin;
    private float spawnRate = 2.5f;
    private float timer = 0;
    private float detectorSize = 0;
    // [SerializeField] CoinScript coinscript;

    void Start()
    {
        //coinscript = GetComponent<CoinScript>();
        //Debug.Log(coinscript);
        
        if (Settings.difficulty == 1) {
            detectorSize = 12;
            spawnRate = 3;
        } else if (Settings.difficulty == 2) {
            detectorSize = 10;
        } else if (Settings.difficulty == 3) {
            detectorSize = 8;
        }

        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (BirdScript.BirdIsAlive) {
            if (timer < spawnRate)
                timer += Time.deltaTime;
            else {
                spawn();
                timer = 0;
            }
        }
    }

    void spawn() {
        float curDetectorSize = Random.Range(detectorSize + 4, detectorSize - 2);

        float topY = Random.Range(-10, 7);
        float botY = topY + 12 - curDetectorSize;
        if (botY < -6) botY = -6;
        float x = transform.position.x;

        Instantiate(topPipe, new Vector3 (x, topY, 0), transform.rotation);
        Instantiate(bottomPipe, new Vector3 (x, botY, 0), transform.rotation);
        GameObject detectorObject = Instantiate(detector, new Vector3 (x, botY + curDetectorSize/2, 0), transform.rotation);
        detectorObject.transform.localScale = new Vector2(1, curDetectorSize);

        int rand = Random.Range(1, 100);
        if (rand <= 15) {
            float coinY = (topY + botY) / 2;
            Instantiate(coin, new Vector3(x, coinY, 0), transform.rotation);
        }
            
    }
}

// top: 7.5 to 21
// bottom: -7.5 to -21

// detector: 14, 11.5, 9