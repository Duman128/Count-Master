using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxPoint.position, boxSize);
    }

    private void Start()
    {
        _spawnPlayer.SpawnFonc(SpawnEnemyCount);

    }

    private void FixedUpdate()
    {
       if(_spawnPlayer.playerCount != 0)
            DetectPlayers();

        else
        {
            StopAllCoroutines();
            _moveHorizontal.enabled = true;
            _moveVertical.enabled = true;
            _spawnPlayer.HumanCountText.text = "";
        }
        
    }

    private void DetectPlayers()
    {
        RaycastHit hit;

        if (Physics.BoxCast(boxPoint.position, boxSize, Vector3.back, out hit, Quaternion.identity, 0.5f, playerLayer))
        {
            SpawnPlayer _playerSpawnScript = hit.transform.parent.GetComponent<SpawnPlayer>();

            if (_spawnPlayer.playerCount != 0)
            {
                _moveHorizontal.enabled = false;
                _moveVertical.enabled = false;

                StartCoroutine(HumanScript.DestroyHuman(_playerSpawnScript, _spawnPlayer.SpawnedPlayer.Count));
                StartCoroutine(HumanScript.DestroyHuman(_spawnPlayer, _spawnPlayer.SpawnedPlayer.Count));
            }
        }
    }

}
