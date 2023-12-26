using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{

    public static Vector3 GetMouseWorldPosition(Camera worldCamera, Vector3 screenInput)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenInput);
        worldPosition.z = 0f;

        return worldPosition;
    }
    
    public static Vector3 GetMouseWorldPosition()
    {
        Camera worldCamera = Camera.main;
        Vector3 screenInput = Input.mousePosition;

        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenInput);
        worldPosition.z = 0f;

        return worldPosition;
    }
}
