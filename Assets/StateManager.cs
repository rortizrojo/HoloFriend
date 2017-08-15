using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {


    public IState currentState;
    public IState angryState;
    public IState happyState;
    public IState sadState;
    public IState tiredState;

    // Minimum = 0 ; Maximum = 100
    public float hungry;
    public float energy;
    public float interaction;

    public Image imageHungry;
    public Image imageEnergy;
    public Image imageInteraction;

    public SkinnedMeshRenderer DogMesh;

    public Animator animator;


    // Use this for initialization
    void Start () {
        animator = GetComponentInChildren<Animator>();
        hungry = 50;
        energy = 50;
        interaction = 50;
        
        tiredState = new TiredState();
        angryState = new AngryState();
        sadState = new SadState();
        happyState = new HappyState();
    }
	

	// Update is called once per frame
    private void FixedUpdate()
    {

        hungry -= 0.008f;
        energy -= 0.008f;
        interaction -= 0.008f;

        float hungryAux = hungry / 100;
        float energyAux = energy / 100;
        float interactionyAux = interaction / 100;


        imageHungry.fillAmount = hungryAux;
        imageEnergy.fillAmount = energyAux;
        imageInteraction.fillAmount = interactionyAux;

        UpdateState();


        if (currentState != null)
            currentState.UpdateAnims(DogMesh, animator, hungryAux, energyAux, interactionyAux);

    }



    internal void UpdateState()
    {

        if (hungry < 25) // Angry 
        {
            currentState = angryState;
        }
        else if (interaction < 25) // Sad
        {
            currentState = sadState;
        }
        else if (energy < 25) // Tired{
        {
            currentState = tiredState;
        }
        else  // Happy{
        {
            currentState = happyState;
        }
    }
}
