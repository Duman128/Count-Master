using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private Vector3 borderSize;
    [SerializeField] private LayerMask mask;

    private void OnDrawGizmos()//Drawing Borders
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3(7, base.transform.position.y, base.transform.position.z), borderSize);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector3(-7, base.transform.position.y, base.transform.position.z), borderSize);
    }

    private void FixedUpdate()
    {
        MovementFonc();
    }



    private void MovementFonc()
    {
        float InputX = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(InputX, 0, 0) * speed);

        if (Physics.CheckBox(new Vector3(7, base.transform.position.y, base.transform.position.z), borderSize, Quaternion.identity, mask))
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        else if (Physics.CheckBox(new Vector3(-7, base.transform.position.y, base.transform.position.z), borderSize, Quaternion.identity, mask))
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
    }
}
