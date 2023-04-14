using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour
{
    public string savename;
    public Text inputtext;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    public void setname()
    {
         savename = inputtext.text;
         PlayerPrefs.SetString("name", savename);
         SceneManager.LoadScene("MainMenu");
    }
    

}
