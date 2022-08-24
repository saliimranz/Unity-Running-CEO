using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    private PlayerController playerControllerScript;
    private SpawnManager spawnManager;
    private float leftBound = 1;
    private int pointValue = 5;
    private GameObject dest;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false){
       transform.Translate(Vector3.left * Time.deltaTime* speed);
        } 

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle")){
            spawnManager.UpdateScore(pointValue);
            Destroy(gameObject);
        }
    }
}
