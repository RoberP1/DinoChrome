using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnEnable()
    {
        Player.OnDead += ReloadScene;
    }
    private void OnDisable()
    {
        Player.OnDead -= ReloadScene;
    }
}
