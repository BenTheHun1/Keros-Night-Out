using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public float speed = 5f;
    public float maxDistance = 1f;

    public Camera mainCamera;
    private Vector3 _origin;

    void Start()
    {
        _origin = transform.position;
    }

    void Update()
    {

        if (Time.timeScale != 0)
        {
            /* Get the mouse position in world space rather than screen space. */
            var mouseWorldCoord = mainCamera.ScreenPointToRay(Input.mousePosition).origin;

            /* Get a vector pointing from initialPosition to the target. Vector shouldn't be longer than maxDistance. */
            var originToMouse = mouseWorldCoord - _origin;
            originToMouse = Vector3.ClampMagnitude(originToMouse, maxDistance);

            /* Linearly interpolate from current position to mouse's position. */
            transform.position = Vector3.Lerp(transform.position, _origin + originToMouse, speed * Time.deltaTime);
        }
    }
}
