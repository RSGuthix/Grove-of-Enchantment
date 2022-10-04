using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public float movespeed;

    private Rigidbody2D rb;

    public bool isMoving;

    public float walkTime;
    private float walkCounter;
    private float waitCounter;
    public float waitTime;

    private int walkDirection;

    public Collider2D walkZone;
    private Vector2 minWalk;
    private Vector2 maxWalk;
    private bool hasZone;

    public bool canMove;
    private DialogueManager dMan;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dMan = FindObjectOfType<DialogueManager>();
        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
        if (walkZone != null)
        {
            minWalk = walkZone.bounds.min;
            maxWalk = walkZone.bounds.max;
            hasZone = true;
        }
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dMan.dialogueActive) 
        {
            canMove = true;
        }
        if(!canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (isMoving)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection) 
            {
                case 0:
                    rb.velocity = new Vector2(0, movespeed);
                    if(hasZone && transform.position.y > maxWalk.y)
                    {
                        isMoving = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    if (hasZone && transform.position.x > maxWalk.x)
                    {
                        isMoving = false;
                        waitCounter = waitTime;
                    }
                    rb.velocity = new Vector2(movespeed, 0);
                    break;
                case 2:
                    rb.velocity = new Vector2(0, -movespeed);
                    if (hasZone && transform.position.y < minWalk.y)
                    {
                        isMoving = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    if (hasZone && transform.position.x < minWalk.x)
                    {
                        isMoving = false;
                        waitCounter = waitTime;
                    }
                    rb.velocity = new Vector2(-movespeed, 0);
                    break;
            }
            if (walkCounter < 0)
            {
                isMoving = false;
                waitCounter = waitTime;
            }
        }
        else 
        {
            waitCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;
            if (waitCounter < 0) 
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection() 
    {
        walkDirection = Random.Range(0, 4);
        isMoving = true;
        walkCounter = walkTime;

    }
}
