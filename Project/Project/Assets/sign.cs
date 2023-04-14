using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sign : MonoBehaviour

{
    public Text guide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        



    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player=collision.gameObject.GetComponent<PlayerController>();
        if(player != null)
        {
            guide.gameObject.SetActive(true);
        }

        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            guide.gameObject.SetActive(false);
        }


    }

}
