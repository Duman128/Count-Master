using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public int playerCount = 1;
    public static bool isContectGate = false;
    public List<GameObject> SpawnedPlayer = new List<GameObject>();

    public void SpawnFonc(int size)
    {
        if (isContectGate)
            return;

        playerCount += size;

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(player, PlayerPosition(), Quaternion.identity, transform);
            SpawnedPlayer.Add(obj);
        }
    }

    public Vector3 PlayerPosition()
    {
        Vector3 pos = Random.insideUnitSphere * 0.2f;
        Vector3 newPos = transform.position + pos;
        newPos.y = 0.5f;
        return newPos;
    }
}
