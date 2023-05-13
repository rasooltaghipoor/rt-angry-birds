using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    //viewArea is your player and change the off position to make the player in the center of the screen as per you want. Try changing its y axis up or down, and same with the x and z axis.
    private GameObject viewArea;
    [SerializeField] Vector3 off;
    private Vector3 _initialPosition;
    // This is how smoothly your camera follows the player
    [SerializeField]
    [Range(0, 3)]
    private float smoothness = 0.175f;
    private Vector3 velocity = Vector3.zero;
    private bool _canMove;

    private void Start()
    {
        _initialPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (viewArea.transform.position.x > transform.position.x && _canMove)
        {
            Vector3 desiredPosition = new Vector3(viewArea.transform.position.x + off.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothness);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, _initialPosition, ref velocity, smoothness);
        }

        if (viewArea.GetComponent<Rigidbody2D>().velocity.x < 0 && _canMove)
        {
            _canMove = false;
        }
    }

    public void SetViewArea(GameObject viewArea)
    {
        this.viewArea = viewArea;
        _canMove = true;
    }
}
