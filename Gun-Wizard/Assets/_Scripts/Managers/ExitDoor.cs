using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField]
    Sprite openDoorSprite;
    [SerializeField]
    Sprite closedDoorSprite;
    SpriteRenderer spriteRenderer;
    private bool canExit;
    public static ExitDoor Instance;
    [SerializeField]
    private int enemies = 0;

    private void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        closeDoor();
    }

    private void closeDoor()
    {
        spriteRenderer.sprite = closedDoorSprite;
        canExit = false;
    }

    public void openDoor() 
    {
        spriteRenderer.sprite = openDoorSprite;
        canExit = true;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag.Equals("Player") && canExit)
        {
            Debug.Log("EXIT");
            LevelManager.Instance.LoadNextScene();
        }
    }
}
