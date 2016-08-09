using UnityEngine;
using System.Collections;

[System.Serializable]
public class CameraLevelPositions
{
    [Header("Locais de venda")]
    public Transform[] level_Positions;
    //[HideInInspector]
    public int cameraPositionId;
}

public class CameraBehaviour : MonoBehaviour 
{
    public PlayerBehaviour playerBehaviour;
    public CameraLevelPositions cameraPositionsInstance;
    public Transform[] cameraRotations;
    public Transform[] cameraPositions;
    public int cameraRotationId;
    public float smooth;
    private float cameraZoom;

    void Start()
    {
        cameraZoom = Camera.main.orthographicSize - 0.1f;
    }

    void Update()
    {
        if(GameController.GameControllerProperties.GetCurrentGameState() == GameState.PLAY)
        {
            CameraMovement();
        }
    }

    void CameraMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (cameraRotationId > 0)
            {
                cameraRotationId--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (cameraRotationId < 3)
            {
                cameraRotationId++;
            }
        } 
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.orthographicSize >= 0.5f)
                cameraZoom -= 0.2f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.orthographicSize <= 2.8f)
                cameraZoom += 0.2f;
        }

        Camera.main.orthographicSize = cameraZoom;

        if (cameraRotationId != -1 && cameraRotationId != 4)
        {
            if (cameraPositionsInstance.cameraPositionId != -1)
            {
                transform.position = Vector3.Lerp(transform.position, cameraPositionsInstance.level_Positions[cameraPositionsInstance.cameraPositionId].position, smooth * Time.deltaTime);
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, cameraRotations[cameraRotationId].rotation, smooth * Time.deltaTime);
        }
    }
}
