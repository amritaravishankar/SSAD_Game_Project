using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// List of levelPrefabs
    /// </summary>
    public List<GameObject> levels;
    /// <summary>
    /// Player gameobject
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Spawnpoint that the player will spawn at
    /// </summary>
    Vector3 spawnPoint;
    /// <summary>
    /// Current level number
    /// </summary>
    int currLevel, maxCollectibles;

    int numOfCollectiblesCollected = 0;

    public static LevelManager instance;

    public UnityEngine.UI.Text collectibleCountDisplay;

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadLevel(1);
    }

    private void LoadLevel(int levelNum)
    {
        if (transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);
        GameObject.Instantiate(levels[levelNum - 1], transform);
        spawnPoint = GameObject.FindGameObjectWithTag("Spawnpoint").transform.localPosition;
        player.transform.localPosition = spawnPoint;
        player.GetComponent<PlayerController>().SetState(PlayerController.States.STATES_LIQUID);
        currLevel = levelNum;
        numOfCollectiblesCollected = 0;
        maxCollectibles = GameObject.FindGameObjectsWithTag("UseCase").Length;

        collectibleCountDisplay.text = numOfCollectiblesCollected + "/" + maxCollectibles;
    }

    public void AddCollectible()
    {
        numOfCollectiblesCollected++;
        collectibleCountDisplay.text = numOfCollectiblesCollected + "/" + maxCollectibles;
    }

    public bool EndLevel()
    {
        if (numOfCollectiblesCollected == maxCollectibles)
        {
            //End the level
            //LoadLevel(2);
            return true;
        }
        else
        {
            return false;
        }
    }

}
