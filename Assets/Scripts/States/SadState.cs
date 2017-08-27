using Assets.Scripts.States;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class SadState : State, IState
    {
        

        public SadState(GameObject agent) : base(agent)
        {

        }

        public void ejecutar(GameObject avatar)
        {
        }


        public void UpdateAnims(float hungry, float energy, float interaction, float hungryBlendShape, float energyBlendShape, float interactionBlendShape)
        {
            Eat();
            Move(energy);
            GivePaw();
            TakeLeaveObject();
            UpdateBlendShapes(0, 0, interactionBlendShape);

        }




    }
}
