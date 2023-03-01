using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    private Touch Touch;

    [SerializeField] private float speed = 0.2f;
    [SerializeField] private float handSpeed = 0.01f;
    [SerializeField] private float XBorderValue;

    private void FixedUpdate()
    {
        BorderFonc();
        handMovement();
        MovementFonc();
    }

    private void handMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch = Input.GetTouch(0);
            if (Touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + Touch.deltaPosition.x * handSpeed,
                    transform.position.y,
                    transform.position.z
                    );
            }
        }
    }

    void BorderFonc()
    {
        if (transform.position.x >= XBorderValue)
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        else if (transform.position.x <= -XBorderValue)
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
    }

    private void MovementFonc()
    {
        float InputX = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(InputX, 0, 0) * speed);
    }
}
