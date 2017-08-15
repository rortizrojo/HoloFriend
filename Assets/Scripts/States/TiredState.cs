using System;
using UnityEngine;

internal class TiredState : IState
{

    
    public void ejecutar(GameObject avatar)
    {
        //Debug.Log("Tired ");
    }


    public void UpdateAnims(SkinnedMeshRenderer dogMesh, Animator animator, float hungry, float energy, float interaction)
    {
        throw new NotImplementedException();
    }
}