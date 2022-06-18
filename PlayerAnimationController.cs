using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    //deals with all the animations required for player
    public static Animator animator;
    private GameObject bow;
    private void Start()
    {
        animator = GetComponent<Animator>();
        bow = GameObject.FindGameObjectWithTag("Bow");
    }
    private void Update()
    {
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        animator.SetBool("sprint", Input.GetKey(KeyCode.LeftShift));
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Equipbow", !animator.GetBool("Equipbow"));
            bow.GetComponent<BowController>().equip();
        }
        if (Input.GetMouseButton(0))
        {
            if (!animator.GetBool("Aim"))
            {
                animator.SetBool("fire", false);
                animator.SetBool("Aim", true);
                animator.SetBool("pullstring", true);
            }
          
        }
        else if (Input.GetMouseButtonUp(0))
        {

            animator.SetBool("fire", true);
            animator.SetBool("Aim", false);
            animator.SetBool("pullstring", false);
        }
   
    }
    public void unequip()
    {
        Debug.Log("Unequipbow");
        bow.GetComponent<BowController>().unequip();
    }
    public void startpullstring()
    {
        Debug.Log("Started to pull string");
        bow.GetComponent<BowController>().pullstring();
    }
    public void releasestring()
    {
        Debug.Log("Released string");
        bow.GetComponent<BowController>().releasestring();
    }
}
