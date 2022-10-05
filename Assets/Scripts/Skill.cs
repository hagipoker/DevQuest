using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Transform bow;

    public float skill_damage = 20f;

    public GameObject skill_hit_effect;

    public Animator animator;

    public bool shooting = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            shooting = true;
            Debug.Log("Right Button Click");
            animator.SetBool("rangeAttack", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            shooting = false;
            Debug.Log("Right Button UnClick");
            RaycastHit hit_info;
            if (Physics.Raycast(bow.position, bow.forward, out hit_info))
            {
                Target target = hit_info.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.GetHit(skill_damage);
                }
                Instantiate(skill_hit_effect, hit_info.point, Quaternion.LookRotation(hit_info.normal));
                animator.SetBool("rangeAttack_Stop", true);
                // I couldn't make attacking animation smoothly, 
                // so I added another boolean trigger called 'rangeAttack_Stop'.
                // I want to know how I should have done.
            }

        }
    }
}
