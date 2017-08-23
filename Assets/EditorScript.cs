using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EditorScript : MonoBehaviour
{

    void Awake()
    {
#if UNITY_EDITOR
        gameObject.GetComponent<FirstPersonController>().enabled = true;
        gameObject.GetComponent<CharacterController>().enabled = true;
#else
        gameObject.GetComponent<FirstPersonController>().enabled = false;
        gameObject.GetComponent<CharacterController>().enabled = false;
#endif

    }
}
