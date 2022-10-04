using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
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
        Player = FindObjectOfType<PlayerController>();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(LeveltoLoad);
        Player.startPoint = exitPoint;
        //Instantiate(Player, new Vector3(0f, 0f, 0), Quaternion.identity);
    }
}
