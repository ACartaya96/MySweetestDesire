using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManagment : MonoBehaviour, IDataPersistence
{
    [SerializeField] private float m_MaxSize = 5.0f;
    [SerializeField] private float m_screenEdgeBuffer = 0.5f;
    CinemachineConfiner confiner;
    CinemachineVirtualCamera virtualCamera;
    

    public void LoadData(GameData data)
    {
        if( data.boundingBox != null ) 
            confiner.m_BoundingShape2D = data.boundingBox;

        // Adjust Orthographic size after you gauranteed the boundingBox is pulled from the save data
        FindRequiredSize();
    }

    public void SaveData(ref GameData data)
    {
        data.boundingBox = (PolygonCollider2D)confiner.m_BoundingShape2D;
    }

    private void Awake()
    {
        confiner = GetComponent<CinemachineConfiner>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
            
    }

   
    public void FindRequiredSize()
    {
        // Start camera size calculation at 0
        float size = 0f;

        // Grab the minimum size of the Map Boundaries
        float ySize = Mathf.Abs(confiner.m_BoundingShape2D.bounds.extents.y);
        float xSize = Mathf.Abs(confiner.m_BoundingShape2D.bounds.extents.x);
        size = Mathf.Min(xSize, ySize);

        // reduce the extent with screenedge buffer
        size -= m_screenEdgeBuffer;

        // Compare the size to Max Bounds
        size = Mathf.Min(size, m_MaxSize);
        
        // Finalize adjustments
        virtualCamera.m_Lens.OrthographicSize = size;
    }
   
}
