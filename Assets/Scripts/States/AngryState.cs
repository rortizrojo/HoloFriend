using System;
using UnityEngine;

internal class AngryState : IState
{
    public void ejecutar(GameObject avatar)
    {
       // Debug.Log("Angry ");
    }

    public void UpdateAnims( GameObject gameObject,  float hungry, float energy, float interaction)
    {
        GameObject avatar = gameObject.transform.Find("Avatar").gameObject;
        Animator animator =  gameObject.GetComponentInChildren<Animator>();
       
        GameObject avatarMesh = avatar.transform.Find("AvatarMesh").gameObject;
        SkinnedMeshRenderer skinnedMeshRenderer = avatarMesh.GetComponent<SkinnedMeshRenderer>();

        skinnedMeshRenderer.SetBlendShapeWeight(0, 100);
        


    }
}