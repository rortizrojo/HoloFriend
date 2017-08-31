using System;
using UnityEngine;

namespace Assets.Scripts.States
{
    internal class TiredState : State, IState
    {
        public TiredState() : base()
        {
        }


        public void UpdateBehaviour(float hungry, float energy, float interaction, float hungryBlendShape, float energyBlendShape, float interactionBlendShape)
        {
            
            Play(energy);
            
            UpdateBlendShapes(0,0, 0);
        }
    }
}