using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathzone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            //if(collision.gameObject.name == "Player") Gameobject.FindGameObjectWithTag.GetComponent<DeathManager>().PlayerOneDeath++;
            //if(collision.gameObject.name == "Player 2") Gameobject.FindGameObjectWithTag.GetComponent<DeathManager>().PlayerTwoDeath++;
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
