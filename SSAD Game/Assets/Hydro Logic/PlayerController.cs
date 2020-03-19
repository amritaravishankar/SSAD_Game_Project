using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// State of player : Solid/Liquid/Gas
    /// </summary>


    public enum States
    {
        STATES_CLOUD,
        STATES_SOLID,
        STATES_LIQUID,
        STATES_GAS
        
    }

    /// <summary>
    /// Current state of player
    /// </summary>
    private States currState;

    // Start is called before the first frame update
    void Start()
    {
        currState = States.STATES_LIQUID;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Get current state of player.
    /// </summary>
    /// <returns></returns>
    public States GetState()
    {
        return currState;
    }

    public void SetState(States newState)
    {
        currState = newState;
        switch (newState)
        {
            case States.STATES_GAS:
                GetComponent<Rigidbody2D>().gravityScale = 0;
                Vector2 thrust = new Vector2(0, 10);
                GetComponent<Rigidbody2D>().AddForce(thrust, ForceMode2D.Impulse);
                break;
            case States.STATES_LIQUID:
                GetComponent<Rigidbody2D>().gravityScale = 1;
                break;
            case States.STATES_SOLID:
                GetComponent<Rigidbody2D>().gravityScale = 0;
                break;
            case States.STATES_CLOUD:
                GetComponent<Rigidbody2D>().gravityScale = 0;
                break;
        }
    }

    public void IncreaseTemp()
    {
        switch (currState)
        {
            case States.STATES_LIQUID:
                GetComponent<Animator>().SetTrigger("Gas");
                break;
            case States.STATES_SOLID:
                GetComponent<Animator>().SetTrigger("Liquid");
                break;
            default:
                break;
        }
    }

    public void DecreaseTemp()
    {
        switch (currState)
        {
            case States.STATES_GAS:
                GetComponent<Animator>().SetTrigger("Cloud");
                break;
            case States.STATES_LIQUID:
                GetComponent<Animator>().SetTrigger("Solid");
                break;
            default:
                break;
        }
    }
    public void Precipitation()
    {
        switch (currState)
        {
            case States.STATES_CLOUD:
                GetComponent<Animator>().SetTrigger("Liquid");
                break;
            default:
                break;
        }
    }
}
