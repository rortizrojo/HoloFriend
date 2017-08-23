using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableCube : MonoBehaviour {

    public GameObject cube;
    void Awake()
    {
#if UNITY_EDITOR
        cube.SetActive(true);
#else
    cube.SetActive(false);
#endif

    }
}
