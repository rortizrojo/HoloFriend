﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public interface IState {

    void ejecutar(GameObject avatar);
    void UpdateAnims(SkinnedMeshRenderer dogMesh, Animator animator, float hungry, float energy, float interaction);
}
