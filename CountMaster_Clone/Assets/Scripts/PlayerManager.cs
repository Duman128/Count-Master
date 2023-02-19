using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private SpawnPlayer _spawnPlayer;
    [SerializeField] private LayerMask GateLayer;
    private SpawnPlayer spawnPlayer;
    private int numberToBeCreated;
    private GameObject[] EnemysToBeDeleted;

    private void Start()
    {
        spawnPlayer = GetComponent<SpawnPlayer>();
    }

    private void FixedUpdate()
    {
        DetectGate();
    }

    private void DetectGate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f, GateLayer))
        {
            Gates _gates = hit.transform.GetComponent<Gates>();
            

            switch (_gates._transactionStatus)
            {
                case Gates.transactionStatus.Times:
                    
                    StartCoroutine(Multiplication(_gates));
                    break;


                case Gates.transactionStatus.Plus:
                    StartCoroutine(Addition(_gates));
                    break;

                default:
                    break;
            }
        }
    }

    IEnumerator Multiplication(Gates _gates)
    {
        int _number = _gates.number;
        numberToBeCreated = (spawnPlayer.playerCount * _number) - spawnPlayer.playerCount;

        spawnPlayer.SpawnFonc(numberToBeCreated);

        SpawnPlayer.isContectGate = true;
        yield return new WaitForSeconds(0.5f);
        SpawnPlayer.isContectGate = false;
    }

    IEnumerator Addition(Gates _gates)
    {
        int _number = _gates.number;
        Debug.Log(_number);
        numberToBeCreated = (spawnPlayer.playerCount + _number) - spawnPlayer.playerCount;

        spawnPlayer.SpawnFonc(numberToBeCreated);

        SpawnPlayer.isContectGate = true;
        yield return new WaitForSeconds(0.5f);
        SpawnPlayer.isContectGate = false;
    }

    public IEnumerator DestroyPlayers(int DeletePlayerCount)
    {
        EnemysToBeDeleted = _spawnPlayer.SpawnedPlayer.ToArray();

        if (_spawnPlayer.SpawnedPlayer.Count != 0)
        {
            for (int i = 0; i < DeletePlayerCount; i++)
            {
                _spawnPlayer.SpawnedPlayer.Remove(EnemysToBeDeleted[i]);
                Destroy(EnemysToBeDeleted[i]);
                yield return null;
            }
        }

    }
}