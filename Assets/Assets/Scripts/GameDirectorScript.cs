using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorScript : MonoBehaviour
{
    // Controls the interface and gamedata too
    private int score;



    private void Awake()
    {
        score = 0;

        
    }


    public void addScore()
    {
        score++;

        if(score == 4)
        {
            endGame();
        }

    }


    void endGame() { 

    }


    void resetGame() {

        

    }
 
}
