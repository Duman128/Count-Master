using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform GameOverScreen;
    [SerializeField] private SpawnPlayer PlayerSpawnScript;

    [SerializeField] private MoveHorizontal _moveHorizontal;
    [SerializeField] private MoveVertical _moveVertical;

    public static bool GameOver = false;

    private void Awake()
    {
        GameOver = false;
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

        _moveHorizontal.enabled = false;
        _moveVertical.enabled = false;

        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
            SceneManager.LoadScene(0); 
    }
}
