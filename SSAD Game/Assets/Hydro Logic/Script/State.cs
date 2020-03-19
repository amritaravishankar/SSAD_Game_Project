using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public characterState currentState;
    public Vector2 thrust;
    public Sprite cloud;
    public Sprite gas;
    public Sprite liquid;
    public Sprite iceCube;
    GameObject player;
    Rigidbody2D rb;
    MouseMove mouseM;
    SpriteRenderer sr;
    float fadeTime = 0.1f;
    public enum characterState
    {
        liquid = 0,
        solid = 1,
        gas = 2,
        cloud = 3
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = characterState.liquid;
        player = GameObject.FindWithTag("Player");
        sr = player.GetComponent<SpriteRenderer>();
        rb = player.GetComponent<Rigidbody2D>();
        mouseM = player.GetComponent<MouseMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Button 0 = Evaporation/Melting
    //Button 1 = Precipitation 
    //Button 2 = Condensation/Solidification
    public void transformState(int buttonType){
        if (buttonType == 0)
        {
            if(currentState == characterState.liquid){
                StartCoroutine(TurnToGas());
            }
            else if (currentState == characterState.solid)
            {
                StartCoroutine(TurnToLiquid());
            }
            
        }
        else if (buttonType == 2)
        {
            if (currentState == characterState.gas)
                StartCoroutine(TurnToCloud());
            else if (currentState == characterState.liquid)
            {
                StartCoroutine(TurnToSolid());
            }

        }
        else {
            if (currentState == characterState.cloud)
                StartCoroutine(TurnToLiquid());
        }
    }
    private IEnumerator TurnToSolid()
    {
        StartCoroutine(FadeTo(0, fadeTime));
        yield return new WaitForSeconds(fadeTime);
        sr.sprite = iceCube;
        StartCoroutine(FadeTo(1, fadeTime));
        yield return new WaitForSeconds(fadeTime);

        currentState = characterState.solid;
        yield return null;
    }
    private IEnumerator TurnToCloud()
    {
        StartCoroutine(FadeTo(0,fadeTime));
        yield return new WaitForSeconds(fadeTime);
        currentState = characterState.cloud;
        sr.sprite = cloud;
        StartCoroutine(FadeTo(1, fadeTime));
        yield return new WaitForSeconds(fadeTime);
        yield return null;

    }
    IEnumerator FadeTo(float aValue, float aTime)
     {
         float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
         for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
         {
             Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
             transform.GetComponent<SpriteRenderer>().material.color = newColor;
             yield return null;
         }
     }
 
    private IEnumerator TurnToGas()
    {
        mouseM.setIsMoving(true);
        StartCoroutine(FadeTo(0, fadeTime));
        yield return new WaitForSeconds(fadeTime);
        sr.sprite = gas;
        StartCoroutine(FadeTo(1, fadeTime));
        yield return new WaitForSeconds(fadeTime);
        rb.gravityScale = 0;
        currentState = characterState.gas;

        thrust = new Vector2(0, 30);
        rb.AddForce(thrust, ForceMode2D.Impulse);
        
        
        while (!Mathf.Approximately(rb.velocity.magnitude, 0))
        {
            yield return null;
        }
        mouseM.setIsMoving(false);
    }

    private IEnumerator TurnToLiquid()
    {
        mouseM.setIsMoving(true);
        rb.gravityScale = 1;
        StartCoroutine(FadeTo(0, 0.5f));
        yield return new WaitForSeconds(fadeTime);
        sr.sprite = liquid;
        StartCoroutine(FadeTo(1, fadeTime));
        yield return new WaitForSeconds(fadeTime);

        thrust = new Vector2(0, -30);
        rb.AddForce(thrust, ForceMode2D.Impulse);

        currentState = characterState.liquid;
        while (!Mathf.Approximately(rb.velocity.magnitude, 0))
        {
            yield return null;
        }
        mouseM.setIsMoving(false);
    }

}
