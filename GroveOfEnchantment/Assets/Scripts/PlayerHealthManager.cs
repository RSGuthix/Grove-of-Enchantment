using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;

    private bool flashActive;
    public float flashLength;
    private float flashCounter;
    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        
        playerCurrentHealth = playerMaxHealth;
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0) 
        {
            
            playerCurrentHealth = playerMaxHealth;
            SceneManager.LoadScene(0);
            transform.position = new Vector3(0f, 0f, 0f);
           
        }

        if (flashActive) 
        {

            if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if(flashCounter > 0)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else  
            {
                playerSprite.color = new Color(playerSprite.color.r,playerSprite.color.g,playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damageToGive) 
    {
        playerCurrentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;
    }

    public void SetMaxHealth() 
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
