using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableCube : MonoBehaviour {

    public GameObject terrain;
    void Awake()
    {
#if UNITY_EDITOR
    terrain.SetActive(true);
#else
    terrain.SetActive(false);
#endif

    }
}
