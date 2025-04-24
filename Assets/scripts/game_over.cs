using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_over : MonoBehaviour
{
    public Text scoretext;
    public void display(int deathscore) 
    {
        scoretext.text = "you score is: " + deathscore;
        gameObject.SetActive(true);
    }
    public void restart() 
    {
        SceneManager.LoadScene(0);
    }
}
