using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.States
{

    public class HappyState : State, IState
    {
        public HappyState( ) : base()
        {
        }

        
        public void UpdateBehaviour(float hungry, float energy, float interaction, float hungryBlendShape, float energyBlendShape, float interactionBlendShape)
        {
            Play(energy);
            Sit();           
            GivePaw();

            float happyness = ((hungry + energy + interaction) / 300)*100;
            UpdateBlendShapes(0, happyness, 0);

        }






    }
}