
using UnityEngine;

namespace Assets.Scripts.States
{
    internal class AngryState : State, IState
    {
        public AngryState() : base()
        {
        }



        public void UpdateBehaviour(float hungry, float energy, float interaction, float hungryBlendShape, float energyBlendShape, float interactionBlendShape)
        {
            if (!audio.isPlaying)
                audio.Play();
            Eat();
            UpdateBlendShapes(hungryBlendShape, 0, 0);

        }
    }
}