using System;
using UnityEngine;

internal class TiredState : IState
{

    
    public void ejecutar(GameObject avatar)
    {
        //Debug.Log("Tired ");
    }


    public void UpdateAnims(GameObject gameObject, float hungry, float energy, float interaction)
    {
        GameObject avatar = gameObject.transform.Find("Avatar").gameObject;
        Animator animator = gameObject.GetComponentInChildren<Animator>();

        throw new NotImplementedException();
    }
}