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
            int PlayerDeath = PlayerPrefs.GetInt("Player1");
            if (collision.gameObject.name == "Player") PlayerPrefs.SetInt("Player1", PlayerDeath++ );
            if(collision.gameObject.name == "Player 2") GameObject.FindGameObjectWithTag("DeathManager").GetComponent<DeathManager>().PlayerTwoDeath++;
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
