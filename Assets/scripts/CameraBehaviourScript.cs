using UnityEngine;
using System.Collections;

public class CameraBehaviourScript : MonoBehaviour
{
    //Camera
    private Transform cameraTransform;
    private Quaternion cameraRotation;
    public float rotationX;
    public float rotationY;
    public float smooth;
    public float sensitivity;
    public Transform playerTransform;
    private Quaternion playerRotation;

	// Use this for initialization
	void Start ()
    {
        cameraTransform = transform;
        cameraRotation = cameraTransform.localRotation;

        playerRotation = playerTransform.localRotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ReadInput();
        cameraRotation *= Quaternion.Euler(-rotationY, 0, 0); //rotationY es como lo llamamos nosotros, en realidad estamos modiicando el eje X de la camara
        cameraTransform.localRotation = Quaternion.Slerp(cameraTransform.localRotation, cameraRotation, Time.deltaTime * smooth);

        playerRotation *= Quaternion.Euler(0, rotationX, 0); //rotationY es como lo llamamos nosotros, en realidad estamos modiicando el eje X de la camara
        playerTransform.localRotation = Quaternion.Slerp(playerTransform.localRotation, playerRotation, Time.deltaTime * smooth);
    }

    void ReadInput ()
    {
        rotationX = Input.GetAxis("Mouse X") * sensitivity;
        rotationY = Input.GetAxis("Mouse Y") * sensitivity;
    }
}
