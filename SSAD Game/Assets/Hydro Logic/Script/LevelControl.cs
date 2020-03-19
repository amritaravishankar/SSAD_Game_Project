using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public void OnButtonClick(int level) {
        SceneManager.LoadScene(level);
    }
}
