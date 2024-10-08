using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour, IDataPersistence
{
    private Vector2 movement;
    private Rigidbody2D rb;

    
    public float speed = 0f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }
    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if(DialogueManager.Instance.dialogueIsPlaying)
        {
            return;
        }
        // Update the movement of the character
        rb.MovePosition(rb.position + InputManager.Instance.GetMovePosition() * speed * Time.deltaTime);
    }

 
    
}
