using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    public float projectileMove = 3f;
    
    public Transform firePoint;
    public GameObject projectile;
    public PlayerController player;
    private float angle;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get input
         if (Input.GetKeyDown(KeyCode.K))
         {
            Shoot();

         }
         
        
    }
    void Shoot() 
    {
        angle = Mathf.Atan2(player.lastMove.y, player.lastMove.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject fireBall = Instantiate(projectile, firePoint.position, rotation);
        Rigidbody2D rb = fireBall.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(player.lastMove.x,player.lastMove.y) * projectileMove, ForceMode2D.Impulse);
        

    }

}