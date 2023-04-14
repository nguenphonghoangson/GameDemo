using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainController : MonoBehaviour
{
    public string nameofplayer;
    public Text loadedname;


    void Update()
    {
        nameofplayer = PlayerPrefs.GetString("name", "none");
        loadedname.text = nameofplayer;
    }
    public void loadgame()
    {
        SceneManager.LoadScene("level1");
    }
    public void loadgame2()
    {
        SceneManager.LoadScene("level2");
    }
    public void loadgame3()
    {
        SceneManager.LoadScene("level3");
    }



    public void back()
    {
        SceneManager.LoadScene("StartGame");
    }
}
