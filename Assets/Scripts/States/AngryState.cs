using System;
using UnityEditor.Animations;
using UnityEngine;

internal class AngryState : IState
{
    public void ejecutar(GameObject avatar)
    {
       // Debug.Log("Angry ");
    }

    public void UpdateAnims(GameObject gameObject, GameObject avatar, Animator animator, float hungry, float energy, float interaction)
    {

        GameObject avatarMesh = avatar.transform.Find("AvatarMesh").gameObject;
        SkinnedMeshRenderer skinnedMeshRenderer = avatarMesh.GetComponent<SkinnedMeshRenderer>();

        skinnedMeshRenderer.SetBlendShapeWeight(0, 100);
        


    }
}