using System;
using UnityEditor.Animations;
using UnityEngine;

internal class AngryState : IState
{
    public void ejecutar(GameObject avatar)
    {
       // Debug.Log("Angry ");
    }

    public void UpdateAnims(SkinnedMeshRenderer dogMesh, Animator animator, float hungry, float energy, float interaction)
    {
        dogMesh.SetBlendShapeWeight(0, 100);
    }
}