using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    private float cameraZDistance;

    // Start is called before the first frame update
    void Start()
    {
        cameraZDistance = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    private void OnMouseDrag() {
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZDistance);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = newPosition;
    }

}
