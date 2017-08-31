using UnityEngine.AI;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace Assets.Scripts.States
{
	
    public class State
    {
		protected NavMeshAgent agent;

        protected GameObject avatar;
        protected GameObject waterBowl;
        protected GameObject foodBowl;
        protected GameObject currentToy;
        protected GameObject currentObject;
        protected GameObject dog;
        protected GameObject objectsGameObject;
        protected GameObject mouth;

        protected static Animator animator;
        protected GameObject avatarMesh;
        protected SkinnedMeshRenderer skinnedMeshRenderer;
        protected StateManager stateManager;
        protected AudioSource audio;
        protected Animation anim;

        static System.Diagnostics.Stopwatch timer;

        protected const int AngryBlenderShapeIndex = 0;
        protected const int HappyBlenderShapeIndex = 1;
        protected const int SadBlenderShapeIndex = 2;

        public State()
        {
            Dictionary<string ,GameObject> container = GameObjectsContainer.Instance.container;
            timer = new System.Diagnostics.Stopwatch();
            foodBowl = container["foodBowl"];
            waterBowl = container["waterBowl"];
            foodBowl = container["foodBowl"];
            dog = container["dog"];
            objectsGameObject = container["objectsGameObject"];
            mouth = container["mouth"];
            avatarMesh = container["avatarMesh"];


            agent = dog.GetComponent<NavMeshAgent>();
            avatar = dog.transform.Find("Avatar").gameObject;
			animator = dog.GetComponentInChildren<Animator>();
            skinnedMeshRenderer = avatarMesh.GetComponent<SkinnedMeshRenderer>();
			stateManager = dog.GetComponent<StateManager>();
			audio = dog.GetComponent<AudioSource>();
            
            
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



        protected void MoveAnimation(float energy)
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

        protected void EatAnim()
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


        private void ComeBack(float speed)
        {
           // Debug.Log("ComeBack");
            agent.destination = Camera.main.transform.position;
            agent.speed = speed;
            agent.stoppingDistance = 1;
            stateManager.IsMoving = true;
            //Debug.Log("IsMoving = true");
        }

        private void GoToObject(Transform currentObject, float speed)
		{
            
            if(Vector3.Distance(Camera.main.transform.position, currentObject.position) > 2.5f)
            {
                agent.destination = currentObject.position;
                agent.speed = speed;
                agent.stoppingDistance = stateManager.stoppingDistance;

                stateManager.IsMoving = true;
                //Debug.Log(" .IsMoving = true;");
                if (timer.ElapsedMilliseconds == 0)
                {
                    timer.Start();
                    //Debug.Log(" timer.Start();");
                }
                
            }
            
		}

        protected void Play(float energy)
        {
            Debug.Log("Change3a ");
            if (ToyCommands.CurrentToy != null)
            {

                currentObject = ToyCommands.CurrentToy;


                switch (currentObject.GetComponent<ToyCommands>().ToyState)
                {
                    case ToyCommands.ToyStates.ThrowedState:
                        {
                            GoToObject(currentObject.transform, stateManager.speed);
                            
                            if (HasArrived(currentObject.transform) )
                            {

                                //Debug.Log("has arrived and :" + timer.ElapsedMilliseconds);
                                TakeObject(currentObject);
                                timer.Reset();
                            }

                            if (Vector3.Distance(mouth.transform.position, currentObject.transform.position) < 0.3f)
                            {
                                //Debug.Log("TakeObject2");
                                TakeObject2(currentObject);

                            }


                        }
                        break;

                    case ToyCommands.ToyStates.CatchedState:
                        {
                            if (HasTakenObject())
                            {
                                ComeBack(stateManager.speed);

                            }

                            if (HasArrived(Camera.main.transform))
                            {
                                stateManager.IsMoving = false;
                                LeaveObject(currentObject.transform);
                                timer.Stop();

                            }
                        }
                        break;

                }
                
            }

            
            MoveAnimation(energy);
            TakeLeaveObject();
        }

        void LeaveObject2(Transform currentObject)
        {
            currentObject.gameObject.GetComponent<ToyCommands>().ToyState = ToyCommands.ToyStates.StandByState;
            currentObject.SetParent(objectsGameObject.transform);
            var rigidbody = currentObject.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rigidbody.drag = 1.5f;
        }



        void TakeObject2(GameObject currentObject)
        {
            currentObject.GetComponent<ToyCommands>().ToyState = ToyCommands.ToyStates.CatchedState;
            currentObject.transform.SetParent(mouth.transform);
            currentObject.transform.localPosition = new Vector3(-1.418f, 0, -0.316f);
            MonoBehaviour.Destroy(currentObject.GetComponent<Rigidbody>());
        }

        private bool HasTakenObject()
        {

            return (timer.ElapsedMilliseconds > 1600 );
        
        }

        protected void Eat()
        {
            if (waterBowl.GetComponent<PositionManager>().IsPlaced ||
                foodBowl.GetComponent<PositionManager>().IsPlaced)
            {
                currentObject = waterBowl.GetComponent<PositionManager>().IsPlaced ? waterBowl : foodBowl;
                GoToObject(currentObject.transform, stateManager.speed);
                if (HasArrived(currentObject.transform))
                {
                    stateManager.IsEating = true;
                }
            }
            EatAnim();
            

        }


        private bool HasArrived(Transform currentObject)
        {
            bool hasArrived = Distance(agent.transform.position, currentObject.position) <= agent.stoppingDistance;

            if (hasArrived && timer.ElapsedMilliseconds > 1000)
            {
                stateManager.IsMoving = false;
                //Debug.Log("IsMoving = false");
            }

            return hasArrived && timer.ElapsedMilliseconds > 2000;
        }
        

        void LeaveObject(Transform currentObject)
        {
            LeaveObject2(currentObject);
        }
        
        void TakeObject(GameObject currentObject)
        {
            stateManager.IsTakingLeaving = true;
            Debug.Log("IsTakingLeaving = true");
                        
        }
        
        float Distance(Vector3 pos1, Vector3 pos2)
        {
            return Mathf.Sqrt(Mathf.Pow(Mathf.Abs(pos1.x - pos2.x), 2) + Mathf.Pow(Mathf.Abs(pos1.z - pos2.z), 2));
        }

    }


}
