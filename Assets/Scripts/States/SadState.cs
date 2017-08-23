using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadState : IState
{
    public void ejecutar(GameObject avatar)
    {
    }


    public void UpdateAnims(GameObject gameObject, float hungry, float energy, float interaction)
    {
        GameObject avatar = gameObject.transform.Find("Avatar").gameObject;
        Animator animator = gameObject.GetComponentInChildren<Animator>();


        animator.SetBool("Paw", gameObject.GetComponent<StateManager>().IsGivingAPaw);
    }
}
