using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState {

    void ejecutar(GameObject avatar);
    void UpdateAnims(SkinnedMeshRenderer dogMesh);
}
