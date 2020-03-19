using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    public UseCase usecase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelManager.instance.AddCollectible();
        gameObject.SetActive(false);
    }
}
