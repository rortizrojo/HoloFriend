using System;
using UnityEngine;

namespace Assets.Scripts.States
{
    internal class TiredState : State, IState
    {
        public TiredState(GameObject agent) : base(agent)
        {
        }

        public void ejecutar(GameObject avatar)
        {
            //Debug.Log("Tired ");
        }


        public void UpdateAnims(float hungry, float energy, float interaction, float hungryBlendShape, float energyBlendShape, float interactionBlendShape)
        {
            Eat();
            Move(energy);
            TakeLeaveObject();
            
            UpdateBlendShapes(0,0, 0);
        }
    }
}