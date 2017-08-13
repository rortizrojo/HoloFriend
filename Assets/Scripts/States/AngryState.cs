using System;
using UnityEngine;

internal class AngryState : IState
{
    public void ejecutar(GameObject avatar)
    {
       // Debug.Log("Angry ");
    }

    public void UpdateAnims(SkinnedMeshRenderer dogMesh)
    {
        dogMesh.SetBlendShapeWeight(0, 100);
    }

}