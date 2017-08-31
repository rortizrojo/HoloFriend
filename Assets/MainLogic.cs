using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class MainLogic : MonoBehaviour {


    public GameObject waterBowl;
    public GameObject foodBowl;
    public GameObject toy;
    public GameObject ball;
    public GameObject dog;
    public GameObject objectsGameObject;
    public GameObject mouth;
    public GameObject avatarMesh;


    // Use this for initialization
    void Start () {
        Dictionary<string,  GameObject> container = GameObjectsContainer.Instance.container;

        container.Add("waterBowl", waterBowl);
        container.Add("foodBowl", foodBowl);
        container.Add("toy", toy);
        container.Add("ball", ball);
        container.Add("dog", dog);
        container.Add("objectsGameObject", objectsGameObject);
        container.Add("mouth", mouth);
        container.Add("avatarMesh", avatarMesh); 


    }

}

