using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroller : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;
    private float maxHealth = 100f;

    [SerializeField]
    private GameObject punch;
    [SerializeField]
    private GameObject kick;

    private Animator animator;

    private bool isPunch = false;
    [SerializeField]
    private float punchTimer = 1f;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPunch)
        {
            punchTimer -= Time.deltaTime;

            if (punchTimer <= 0)
            {
                animator.SetBool("isPunching", false);
                isPunch = false;
                punchTimer = 1f;
            }
        }




        animator.SetBool("isRun", false);
        animator.SetBool("isKicking", false);
    }

    public void OnMove()
    {
        animator.SetBool("isRun", true);
    }
    public void OnPunch()
    {
        animator.SetBool("isPunching", true);
        isPunch = true;
    }

    public void OnKick()
    {
        animator.SetBool("isKicking", true);
    }

    private bool isKick = false;
    [SerializeField]
    private float kickTimer = 2f;

    

    private void update()
    {
        if (isPunch)
        {
            kickTimer -= Time.deltaTime;

            if (kickTimer <= 0)
            {
                animator.SetBool("isKicking", false);
                isKick = false;
                kickTimer = 2f;
            }
        }
    }
   
}
       
