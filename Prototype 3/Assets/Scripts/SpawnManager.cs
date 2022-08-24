using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI game0verText;
    public Button restartButton;

    public GameObject obstaclePrefab;
    private int score = 0;
    private Vector3 spawnPos = new Vector3 (25, 0 ,0);
    private float startDelay = 2;
    private float repeatDelay = 2;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle",startDelay,repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle(){
        if(playerControllerScript.gameOver == false){
        Instantiate(obstaclePrefab,spawnPos,obstaclePrefab.transform.rotation);
        }
    
    }
        public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: "+score;
    }
}
