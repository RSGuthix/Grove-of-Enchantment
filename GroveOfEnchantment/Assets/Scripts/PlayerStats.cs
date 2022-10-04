using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;
    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefence;

    private PlayerHealthManager playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];
        playerHealth = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= toLevelUp[currentLevel])
        {
            LevelUp();
        }
           
    }

    public void AddExperience(int experienceToAdd) 
    {
        currentExp += experienceToAdd;
    }

    public void LevelUp() 
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];

        playerHealth.playerMaxHealth = currentHP;
        playerHealth.playerCurrentHealth += (currentHP - HPLevels[currentLevel - 1]);

        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }
}
