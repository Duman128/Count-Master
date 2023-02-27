using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform GameOverScreen;
    [SerializeField] private SpawnPlayer PlayerSpawnScript;

    public static bool GameOver = false;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        GameOver = false;
        Instance = this;
        GameOverScreen.gameObject.SetActive(false);
    }


    private void FixedUpdate()
    {
        if (GameOver && PlayerSpawnScript.playerCount == 0)
        {
            StopAllCoroutines();
            GameOverFonc();
        }
            
    }
    public void GameOverFonc()
    {
        GameOverScreen.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(0); 
    }
}
