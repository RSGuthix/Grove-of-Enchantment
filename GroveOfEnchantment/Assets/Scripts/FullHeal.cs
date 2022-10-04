using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHeal : MonoBehaviour
{
    private PlayerHealthManager pHMan;
    // Start is called before the first frame update
    void Start()
    {
        pHMan = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        pHMan.playerCurrentHealth = pHMan.playerMaxHealth;
    }
}
