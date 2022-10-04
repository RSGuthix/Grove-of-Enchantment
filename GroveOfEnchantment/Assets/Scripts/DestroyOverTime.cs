using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    // Start is called before the first frame update

    public float timetoDestroy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timetoDestroy -= Time.deltaTime;

        if (timetoDestroy <= 0) 
        {
            Destroy (gameObject);
        }
    }
}
