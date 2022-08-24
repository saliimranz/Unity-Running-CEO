using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMover : MonoBehaviour
{
    public float speed;
    private PlayerController playerControllerScript;
    private SpawnManager spawnManager;
    private float leftBound = -5;
    private int pointValue = 5;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false){
       transform.Translate(Vector3.left * Time.deltaTime* speed);
        } 

        if(transform.position.x <= leftBound && gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
            spawnManager.UpdateScore(pointValue);
        }
        if(playerControllerScript.gameOver == true){
        spawnManager.game0verText.gameObject.SetActive(true);
        spawnManager.restartButton.gameObject.SetActive(true);
        }
    }
}
