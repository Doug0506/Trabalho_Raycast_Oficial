using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCodigo : MonoBehaviour
{
    public Transform corpoPlayer;
    public Transform cabecaPlayer;
    Transform camera;


    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -90;
    float angleYmax = 90;

    void Start()
    {
        camera = gameObject.GetComponent<Transform>();
    }

    public void LateUpdate()
    {
        transform.position = cabecaPlayer.transform.position;
    }
    void atirar() {
        Ray ray = new Ray(camera.position, camera.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.transform.gameObject != null)
        {
            Destroy(hit.transform.gameObject);
        }
        else
        {
            Debug.Log("errou");
        }
    }
    void camerosa()
	{
        float verticalDelta = Input.GetAxisRaw("Mouse Y");
        float horizontalDelta = Input.GetAxisRaw("Mouse X");

        rotationX += horizontalDelta;
        rotationY += verticalDelta;

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }

    void Update()
    {
        //camera

        camerosa();

        //tiro
        if (Input.GetMouseButtonDown(0))
        {
            atirar();
        }

    }
}
