using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    float followSpeed = 4;
    public Transform target;

    private void Start() {
        this.target = Finder.FindPlayer().GetComponent<Transform>();
    }

    private void FixedUpdate() {
        Vector3 newPosition = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed*Time.fixedDeltaTime);
    }
}
