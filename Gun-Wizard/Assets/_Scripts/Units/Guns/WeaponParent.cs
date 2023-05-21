using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    private Vector2 PointerPosition;
    void Update()
    {
        lookAtPointerPosition();
    }

    private void lookAtPointerPosition()
    {
        transform.right = (PointerPosition-(Vector2)transform.position).normalized;
    }

    public Vector2 GetPointerPosition()
    {
        return PointerPosition;
    }

    public void SetPointerPosition(Vector2 newPointerPosition)
    {
        PointerPosition = newPointerPosition;
    }
}
