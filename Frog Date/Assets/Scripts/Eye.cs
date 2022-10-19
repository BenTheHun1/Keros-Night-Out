using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public float speed = 5f;
    public float maxDistance = 1f;

    public Camera mainCamera;
    private Vector3 _origin;
    //private Rigidbody myCanvas = gameObject;


    //Vector2 pos;
    //RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
    //transform.position = myCanvas.transform.TransformPoint(pos);

    //Vector2 pos;
    //RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
    //if we want to follow the mouse we do this:
    //transform.position = myCanvas.transform.TransformPoint(pos);

    void Start()
    {
        _origin = transform.position;
    }

    void Update()
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
