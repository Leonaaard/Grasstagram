using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

	public Transform playerBody;
	public float mouseSensitivity;
	private float xAxisClamp = 0.0f;

    // Zoom
    private Camera myCamera;
    public float zoomSpeed;

    // Sounds
    private AudioSource[] sounds;
    private AudioSource zoomSFX;

    private void Start()
    {

        myCamera = GetComponent<Camera>();

        sounds = GetComponents<AudioSource>();
        zoomSFX = sounds[1];

    }

    void Awake(){

		Cursor.lockState = CursorLockMode.Locked;

	}

	void Update() {
		
		RotateCamera ();
        ZoomInOut();

	}

	void RotateCamera() {
		
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");

		float rotAmountX = mouseX * mouseSensitivity;
		float rotAmountY = mouseY * mouseSensitivity;

		xAxisClamp -= rotAmountY;

		Vector3 targetRotCam = transform.rotation.eulerAngles;
		Vector3 targetRotBody = playerBody.rotation.eulerAngles;

		targetRotCam.x -= rotAmountY;
		targetRotCam.z = 0;
		targetRotBody.y += rotAmountX;

		if(xAxisClamp > 70){
			xAxisClamp = targetRotCam.x = 70;
			targetRotCam.x = 70;
		}else if(xAxisClamp < -90){
			xAxisClamp = -90;
			targetRotCam.x = 270;
		}

		transform.rotation = Quaternion.Euler(targetRotCam);
		playerBody.rotation = Quaternion.Euler(targetRotBody);

	}

    void ZoomInOut()
    {

        if (Input.GetButton("ZoomIn"))
        {
            myCamera.fieldOfView -= Mathf.Lerp(0, zoomSpeed, Time.deltaTime*10f);
            if (!zoomSFX.isPlaying)
            {
                zoomSFX.pitch = 1.05f;
                zoomSFX.Play();
            }
        }
        else if(!Input.GetButton("ZoomOut"))
        {
            zoomSFX.Stop();

        }
        if (Input.GetButton("ZoomOut"))
        {
            myCamera.fieldOfView += Mathf.Lerp(0, zoomSpeed, Time.deltaTime * 10f);
            if (!zoomSFX.isPlaying)
            {
                zoomSFX.pitch = 1f;
                zoomSFX.Play();
            }
        }
        else if (!Input.GetButton("ZoomIn"))
        {
            zoomSFX.Stop();

        }
        myCamera.fieldOfView = Mathf.Clamp(myCamera.fieldOfView, 20, 60);

    }

}
