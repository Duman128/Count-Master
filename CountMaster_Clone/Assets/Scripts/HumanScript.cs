using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HumanScript : MonoBehaviour
{
    public static IEnumerator DestroyHuman(SpawnPlayer _spawnPlayer, int HumanToBeDeleted)
    {
        GameObject[] HumanGameObjects;
        HumanGameObjects = new GameObject[HumanToBeDeleted];
        HumanGameObjects = _spawnPlayer.SpawnedPlayer.ToArray();

        if (HumanGameObjects != null)
        {
            for (int i = 0; i < HumanToBeDeleted; i++)
            {
                if (_spawnPlayer.playerCount == 0)
                    GameManager.GameOver = true; 

                else if(HumanGameObjects[i] != null)
                {
                    _spawnPlayer.SpawnedPlayer.Remove(HumanGameObjects[i]);
                    Destroy(HumanGameObjects[i].gameObject);

                    _spawnPlayer.playerCount = _spawnPlayer.SpawnedPlayer.Count;
                    _spawnPlayer.HumanCountText.text = _spawnPlayer.playerCount.ToString();

                    yield return new WaitForSeconds(.2f);
                }

                
            }
        }
    }
}

