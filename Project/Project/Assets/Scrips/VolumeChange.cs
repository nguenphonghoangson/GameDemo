using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    [SerializeField] Slider volumeslider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicvolume"))
            {
            PlayerPrefs.SetFloat("musicvolume", 1);
            Load();

        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
   
    public void changevolume()
    {
        AudioListener.volume = volumeslider.value;
        Save();
    }
    private void Load()
    {
        volumeslider.value = PlayerPrefs.GetFloat("musicvolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicvolume", volumeslider.value);
    }
}
