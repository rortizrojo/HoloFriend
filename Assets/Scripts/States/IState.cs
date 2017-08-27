using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState {


    void ejecutar(GameObject avatar);
    void UpdateAnims(float hungry , float energy, float interaction, float hungryBlendShape, float energyBlendShape, float interactionBlendShape);
}
