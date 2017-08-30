
using UnityEngine;

namespace Assets.Scripts.States
{
    public class State
    {
        protected GameObject avatar;
        protected Animator animator;
        protected GameObject avatarMesh;
        protected SkinnedMeshRenderer skinnedMeshRenderer;
        protected StateManager stateManager;
        protected AudioSource audio;

        protected const int AngryBlenderShapeIndex = 0;
        protected const int HappyBlenderShapeIndex = 1;
        protected const int SadBlenderShapeIndex = 2;

        public State(GameObject agent)
        {
            avatar = agent.transform.Find("Avatar").gameObject;
            animator = agent.GetComponentInChildren<Animator>();
            avatarMesh = avatar.transform.Find("AvatarMesh").gameObject;
            skinnedMeshRenderer = avatarMesh.GetComponent<SkinnedMeshRenderer>();
            stateManager = agent.GetComponent<StateManager>();
            audio = agent.GetComponent<AudioSource>();
        }
  
        protected void GivePaw()
        {
            
            if (stateManager.IsGivingAPaw)
            {
                animator.SetTrigger("Paw");
                stateManager.IsGivingAPaw = false;
            }
        }

        protected void Sit()
        {
            animator.SetBool("IsSat", stateManager.IsSat);
        }



        protected void Move(float energy)
        {

            animator.SetFloat("Energy", energy/100);
            animator.SetBool("IsMoving", stateManager.IsMoving);
        }


        public void UpdateBlendShapes( float hungryBlendShape, float energyBlendShape, float interactionBlendShape)
        {
           /* Debug.Log("Hungry: " + hungryBlendShape);
            Debug.Log("energy: " + energyBlendShape);
            Debug.Log("interaction: " + interactionBlendShape);*/
            skinnedMeshRenderer.SetBlendShapeWeight(AngryBlenderShapeIndex, hungryBlendShape);
            skinnedMeshRenderer.SetBlendShapeWeight(HappyBlenderShapeIndex, energyBlendShape);
            skinnedMeshRenderer.SetBlendShapeWeight(SadBlenderShapeIndex, interactionBlendShape);

        }

        protected void Eat()
        {
            animator.SetBool("IsEating", stateManager.IsEating);
        }

        protected void TakeLeaveObject()
        {
            if (stateManager.IsTakingLeaving)
            {
                animator.SetTrigger("TakeLeave");
                stateManager.IsTakingLeaving = false;
            }
        }


    }


}
