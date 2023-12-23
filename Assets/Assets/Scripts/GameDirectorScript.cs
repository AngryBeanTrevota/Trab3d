using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameDirectorScript : MonoBehaviour
{
    // Controls the interface and gamedata too
    private int score;

    public GameObject gameOverPanel;

    public GameObject enemy;
    public GameObject bread;

    public Transform player;


    private Vector2 levelCenter;
    private Vector2 levelBound;

    public TextMeshProUGUI scoreCounter;
    AudioHandler audioHandler;






    private void Awake()
    {
        score = 0;
        scoreCounter.text = score.ToString();

        levelCenter = new Vector2(430, 515); //eyeing it
        levelBound = new Vector2(140, 150);

        
    }

    void Start()
    {
        audioHandler = FindObjectOfType<AudioHandler>();
        audioHandler.Play("plimPlimPlom");
    }

    public void addScore()
    {
        score++;


        //add a new enemy and increase it's speed
        //20 meters behind player

        GameObject g = Instantiate(enemy);
        g.GetComponent<EnemyAIController>().increaseSpeed((score*10)/10.0f);
        g.transform.position =  player.transform.position + (player.transform.forward*-15);

        //Generate a new piece of bread around the player

        Vector2 randomPoint = Random.insideUnitCircle * 40.0f;

        Vector3 targetPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) + player.position;


        //No time for a check of colision on other objects

        GameObject b = Instantiate(bread);
        targetPosition.y = 3.0f;
        b.transform.position = targetPosition;
        scoreCounter.text = score.ToString();








    }

    public void showGameOver()
    {
        audioHandler.Stop("plimPlimPlom");
        audioHandler.Play("gameOver");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverPanel.SetActive(true);

    }


    public void endGame() {
        SceneManager.LoadScene(0);

    }


    public void resetGame() {

        SceneManager.LoadScene(1);



    }
 
}
