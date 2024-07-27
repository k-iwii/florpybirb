using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject bottomPipe;
    public GameObject topPipe;
    public GameObject detector;
    private float spawnRate = 2.5f;
    private float timer = 0;
    private float detectorSize = 0;

    void Start()
    {
        if (Settings.difficulty == 1) {
            detectorSize = 12;
            spawnRate = 3;
        } else if (Settings.difficulty == 2) {
            detectorSize = 10;
        } else if (Settings.difficulty == 3) {
            detectorSize = 8;
        }

        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (BirdScript.BirdIsAlive) {
            if (timer < spawnRate)
                timer += Time.deltaTime;
            else {
                spawnPipe();
                timer = 0;
            }
        }
    }

    void spawnPipe() {
        float curDetectorSize = Random.Range(detectorSize + 4, detectorSize - 2);

        float topY = Random.Range(-10, 5);
        float botY = topY + 12 - curDetectorSize;

        float x = transform.position.x;
        Instantiate(topPipe, new Vector3 (x, topY, 0), transform.rotation);
        
        Instantiate(bottomPipe, new Vector3 (x, botY, 0), transform.rotation);
        GameObject detectorObject = Instantiate(detector, new Vector3 (x, botY + curDetectorSize/2, 0), transform.rotation);
        detectorObject.transform.localScale = new Vector2(1, curDetectorSize);
    }
}

// top: 7.5 to 21
// bottom: -7.5 to -21

// detector: 14, 11.5, 9