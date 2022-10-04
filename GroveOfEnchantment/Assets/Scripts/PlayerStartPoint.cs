using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private PlayerController Player;
    private CameraController Camera;

    public Vector2 startDirection;

    public string pointName;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerController>();

        if (Player.startPoint == pointName)
        {
            Player.transform.position = transform.position;
            Player.lastMove = startDirection;

            Camera = FindObjectOfType<CameraController>();
            Camera.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
