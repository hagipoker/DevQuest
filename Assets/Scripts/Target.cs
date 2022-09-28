using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float target_health = 30f;

    public bool actual_hit = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHit(float damage)
    {
        actual_hit = false;
        Debug.Log("Target Damanged");
        target_health -= damage;
        if (target_health <= 0f)
        {
            Destroy(gameObject);
            Debug.Log("Target Destroyed");
        }
    }
}
