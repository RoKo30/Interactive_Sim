using UnityEditor;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f; 
    [SerializeField] private float verticalLookLimit = 60f; 
    [SerializeField] private Transform cameraTransform; 
    [SerializeField] private GameObject prefabToInstantiate; 

    [SerializeField] private Transform spawnPoint; 

    private float verticalRotation = 0f; 
    private bool canShoot = true;

    void Update()
    {
        RotateWithMouse();
        HandleShooting();
    }

    private void RotateWithMouse()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Horizontal rotation
        transform.Rotate(0, mouseX * rotationSpeed, 0);

        // Vertical rotation
        verticalRotation -= mouseY * rotationSpeed; 
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookLimit, verticalLookLimit);

        
        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(canShoot) {
                canShoot = false;
                if (prefabToInstantiate != null && spawnPoint != null && cameraTransform != null) {
                    Quaternion spawnRotation = Quaternion.LookRotation(cameraTransform.forward);

                    Instantiate(prefabToInstantiate, spawnPoint.position, spawnRotation);
                }
                else {
                    Debug.LogWarning("Prefab, spawn point, or camera transform not assigned!");
                }
            }
        }
    }

}