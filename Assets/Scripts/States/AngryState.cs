
using UnityEngine;

namespace Assets.Scripts.States
{
    internal class AngryState : State, IState
    {
        public AngryState(GameObject agent) : base(agent)
        {
        }


        public void ejecutar(GameObject avatar)
        {
            // Debug.Log("Angry ");
        }

        public void UpdateAnims(float hungry, float energy, float interaction, float hungryBlendShape, float energyBlendShape, float interactionBlendShape)
        {

            Eat();
            UpdateBlendShapes(hungryBlendShape, 0, 0);

        }
    }
}