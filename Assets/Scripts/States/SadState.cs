using Assets.Scripts.States;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class SadState : State, IState
    {
        

        public SadState() : base()
        {

        }


        public void UpdateBehaviour(float hungry, float energy, float interaction, float hungryBlendShape, float energyBlendShape, float interactionBlendShape)
        {
            Play(energy);
            GivePaw();
            UpdateBlendShapes(0, 0, interactionBlendShape);

        }




    }
}
