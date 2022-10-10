using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Shooting : MonoBehaviour
{
    public PlayerControl pcon;

    public Transform bow;

    public float arrow_damage = 5f;
    public float skill_damage = 20f;

    public GameObject arrow_hit_effect;
    public GameObject skill_hit_effect;

    public Animator animator;

    public bool shooting = false;

    private bool SkillEnable = true;
    public float cool_time = 10f;
    private float time;
    public TextMeshProUGUI cool_time_text;

    private bool leftDown = false, rightDown = false;

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(cool_time);
        SkillEnable = true;
    }

    HomeMenu home_menu;
    CameraControl camera_control;

    void Awake()
    {
        home_menu = GameObject.Find("HomeMenu").GetComponent<HomeMenu>();
        camera_control = GameObject.Find("Main Camera").GetComponent<CameraControl>();
    }

    void Update()
    {
        if (!home_menu.GamePaused && camera_control.CursorLocked && pcon.landed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                leftDown = true;
                shooting = true;
                Debug.Log("Left Button Click");
                animator.SetBool("rangeAttack", true);
            }
            if (Input.GetMouseButtonUp(0) && leftDown)
            {
                leftDown = false;
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

            if (Input.GetMouseButtonDown(1))
            {
                if (SkillEnable)
                {
                    rightDown = true;
                    shooting = true;
                    Debug.Log("Right Button Click");
                    animator.SetBool("rangeAttack", true);
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                if (SkillEnable & rightDown)
                {
                    rightDown = false;
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
                        Instantiate(skill_hit_effect, hit_info.point, Quaternion.LookRotation(new Vector3(0, 0, 1)));
                        animator.SetBool("rangeAttack_Stop", true);
                    }
                    SkillEnable = false;

                    StartCoroutine(CoolTime());
                    // cool time�� ������ �˸��� text - 10���� �Ʒ��� ����
                    // cool time�� ������ skill�� ����� �� �ִٴ� text
                }
            }

            if (!SkillEnable)
            {
                time -= Time.deltaTime;
                cool_time_text.text = Convert.ToString(Mathf.FloorToInt(time));
            }
            else
            {
                time = cool_time + 1f;
                cool_time_text.text = null;
                SkillEnable = true;
            }
        }
    }
}

