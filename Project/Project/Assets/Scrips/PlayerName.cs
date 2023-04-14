using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
   
    public string nameofplayer=null;
    public Text loadedname=null;
    public Text scoretext = null;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        if (PlayerController.score >= PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", PlayerController.score);
            scoretext.text = "High Score: " + PlayerController.score.ToString();
        }
        else scoretext.text = "Score: " + PlayerController.score.ToString();
        nameofplayer = PlayerPrefs.GetString("name", "none");
        loadedname.text = nameofplayer;
    }
    public void playagain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void menu()
    {
        SceneManager.LoadScene("StartGame");
    }

}
