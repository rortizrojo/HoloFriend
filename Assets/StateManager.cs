using Assets.Scripts.States;
using UnityEngine;
using UnityEngine.UI;


public struct STATE_LIMITS
{
    public const int HUNGRY_LIMIT = 25;
    public const int INTERACTION_LIMIT = 25;
    public const int ENERGY_LIMIT = 25;
}

public class StateManager : MonoBehaviour {
    
    public IState currentState;
    public IState angryState;
    public IState happyState;
    public IState sadState;
    public IState tiredState;

    // Minimum = 0 ; Maximum = 100
    public float hungry = 50;
    public float energy = 50;
    public float interaction = 50;

    public Image imageHungry;
    public Image imageEnergy;
    public Image imageInteraction;
    public STATE_LIMITS stateLimits;

    public bool IsGivingAPaw { get; set; }
    public bool IsSat { get; set; }
    public bool IsEating { get; set; }
    public bool IsMoving { get; set; }

    public bool IsTakingLeaving { get; set; }
    public bool isHungry { get; set; }


    // Use this for initialization
    void Start () {

        tiredState = new TiredState(gameObject);
        angryState = new AngryState(gameObject);
        sadState = new SadState(gameObject);
        happyState = new HappyState(gameObject);
    }
	

	// Update is called once per frame
    private void FixedUpdate()
    {


        if (IsEating)
        {
            if (hungry < 100)
                hungry += 0.01f;
        }
        else if (hungry > 0) hungry -= 0.008f;

        if (IsMoving)
        {
            if (energy > 0) energy -= 0.05f;
            if (interaction < 100) interaction += 0.05f;
        }
        else
        {
            if (IsSat)
            {
                if (interaction < 100) interaction += 0.05f;
            }
            else
            {
                if (energy < 100) energy += 0.008f;
                if (interaction > 0) interaction -= 0.008f;
            }

        }
        

/*
        Debug.Log("Hungry: "+ hungry);
        Debug.Log("energy: " + energy);
        Debug.Log("interaction: " + interaction);*/


        imageHungry.fillAmount = hungry/100;
        imageEnergy.fillAmount = energy / 100;
        imageInteraction.fillAmount = interaction / 100;

        float hungryBlendShape = 100 - (hungry / STATE_LIMITS.HUNGRY_LIMIT)*100  ;
        float interactionBlendShape = 100 - (interaction / STATE_LIMITS.INTERACTION_LIMIT)*100;
        float energyBlendShape = 100 - (energy / STATE_LIMITS.ENERGY_LIMIT) * 100;
        
        UpdateState();


        if (currentState != null)
            currentState.UpdateAnims(hungry, energy, interaction,  hungryBlendShape, energyBlendShape, interactionBlendShape);

    }

    void OnPaw()
    {
        Debug.Log("Give me a paw command recivied");
        IsGivingAPaw = true;
    }

    void OnUp()
    {
        Debug.Log("Up");
        IsSat = false;
    }

    void OnSit()
    {
        Debug.Log("Sit");
        IsSat = true;
    }

    internal void UpdateState()
    {

        if (hungry < STATE_LIMITS.HUNGRY_LIMIT) // Angry 
        {
            currentState = angryState;
        }
        else if (interaction < STATE_LIMITS.INTERACTION_LIMIT) // Sad
        {
            currentState = sadState;
        }
        else if (energy < STATE_LIMITS.ENERGY_LIMIT) // Tired{
        {
            currentState = tiredState;
        }
        else  // Happy{
        {
            currentState = happyState;
        }
    }
}
