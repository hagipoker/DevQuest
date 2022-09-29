using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public Transform bow;

    public float arrow_damage = 5f;

    //public ParticleSystem shooting_effect;

    public GameObject arrow_hit_effect;

    public Animator animator;

    public bool shooting = false;

    void Start()
    {
        //animator.SetBool("rangeAttack", false);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // If press left mouse button
        {
            shooting = true;
            animator.SetBool("rangeAttack", true);
            Debug.Log("Left Button Click");
        }
        if (Input.GetMouseButtonUp(0))
        {
            shooting = false;
            Debug.Log("Left Button UnClick");
            RaycastHit hit_info;
            if (Physics.Raycast(bow.position, bow.forward, out hit_info))
            {
                Target target = hit_info.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.GetHit(arrow_damage);
                }

                Instantiate(arrow_hit_effect, hit_info.point, Quaternion.LookRotation(hit_info.normal));
                animator.SetBool("rangeAttack_Stop", true);
            }
            
        }
    }
}
