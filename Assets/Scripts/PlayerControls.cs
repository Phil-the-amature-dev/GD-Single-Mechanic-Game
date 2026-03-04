using JetBrains.Annotations;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] GameObject cameraPivot;
    [SerializeField] GameObject rocket;
    [SerializeField] GameObject rocketSpawn;
    [SerializeField] private float mousSens;
    [SerializeField] private float VerticalCamMaxClamp;
    [SerializeField] private float VerticalCamMinClamp;

    private float camRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X"),0);

        camRotation -= Input.GetAxis("Mouse Y");
        camRotation = Mathf.Clamp(camRotation, VerticalCamMinClamp, VerticalCamMaxClamp);
        cameraPivot.transform.localRotation = Quaternion.Euler(camRotation, 0, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(rocket, rocketSpawn.transform.position, cameraPivot.transform.rotation);
        }



    }
}
