using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner confiner;
    CameraManagment cameraManager;
    [SerializeField] Direction direction;
    [SerializeField] private float additivePos;
    enum Direction { Up, Down, Left, Right };

    private void Awake()
    {
        confiner = FindObjectOfType<CinemachineConfiner>();
        cameraManager = FindObjectOfType<CameraManagment>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            confiner.m_BoundingShape2D = mapBoundry;
            cameraManager.FindRequiredSize(); 
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPosition = player.transform.position;

        switch (direction)
        {
            case Direction.Up:
                newPosition.y += additivePos;
                break;
            case Direction.Down:
                newPosition.y -= additivePos;
                break;
            case Direction.Left:
                newPosition.x -= additivePos;
                break;
            case Direction.Right:
                newPosition.x += additivePos;
                break;
            default:
                break;
        }

        player.transform.position = newPosition;
    }
}
