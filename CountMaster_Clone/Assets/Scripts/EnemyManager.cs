using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private MoveHorizontal _moveHorizontal;
    [SerializeField] private MoveVertical _moveVertical;
    [SerializeField] private SpawnPlayer _spawnPlayer;

    [SerializeField] private Vector3 boxSize;
    [SerializeField] private Transform boxPoint;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int SpawnEnemyCount;

    private GameObject[] EnemysToBeDeleted;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxPoint.position, boxSize);
    }

    private void Start()
    {
        _spawnPlayer.SpawnFonc(SpawnEnemyCount);

        EnemysToBeDeleted = _spawnPlayer.SpawnedPlayer.ToArray();
    }

    private void FixedUpdate()
    {
        DetectPlayers();
    }

    private void DetectPlayers()
    {
        RaycastHit hit;

        if (_spawnPlayer.SpawnedPlayer.Count == 0)
        {
            _moveHorizontal.enabled = true;
            _moveVertical.enabled = true;
        }
        else if (Physics.BoxCast(boxPoint.position, boxSize, Vector3.back, out hit, Quaternion.identity, 0.5f, playerLayer))
        {
            StartCoroutine(DestroyEnemys());
            StartCoroutine(hit.transform.parent.GetComponent<PlayerManager>().DestroyPlayers(SpawnEnemyCount));
        }

        


    }

    IEnumerator DestroyEnemys()
    {
        if (_spawnPlayer.SpawnedPlayer.Count != 0)
        {
            _moveHorizontal.enabled = false;
            _moveVertical.enabled = false;

            for (int i = 0; i < EnemysToBeDeleted.Length; i++)
            {
                _spawnPlayer.SpawnedPlayer.Remove(EnemysToBeDeleted[i]);
                Destroy(EnemysToBeDeleted[i]);
                yield return null;
            }
        }
    }

}
