using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gates : MonoBehaviour
{
    public enum transactionStatus
    {
        Times,
        Plus
    }

    public int number;
    public transactionStatus _transactionStatus;
    [SerializeField] private TextMeshPro _textMeshPro;

    private void Start()
    {
        switch (_transactionStatus)
        {
            case transactionStatus.Times:
                _textMeshPro.text = "X" + number.ToString();
                break;
            case transactionStatus.Plus:
                _textMeshPro.text = "+" + number.ToString();
                break;
            default:
                break;
        }
    }
}
