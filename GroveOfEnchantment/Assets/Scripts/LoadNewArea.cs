using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string LeveltoLoad;

    public string exitPoint;

    private PlayerController Player;
   // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            LoadScene();
        }
    }
    public void LoadScene() {
        SceneManager.LoadScene(LeveltoLoad);
        Player.startPoint = exitPoint;
    }
}
