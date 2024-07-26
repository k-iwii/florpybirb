using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    private float flapStrength;
    public LogicScript logic;
    public static bool BirdIsAlive = true;
    public static int difficulty = 3;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        BirdIsAlive = true;

        if (difficulty == 1) {
            flapStrength = 12;
        } else if (difficulty == 2) {
            flapStrength = 10;
        } else if (difficulty == 3) {
            flapStrength = 9;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -16 || transform.position.y >= 15) {
            logic.gameOver();
            BirdIsAlive = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && BirdIsAlive) {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        logic.gameOver();
        BirdIsAlive = false;
    }

    public static void setAlive(bool set) {
        BirdIsAlive = set;
    }
}