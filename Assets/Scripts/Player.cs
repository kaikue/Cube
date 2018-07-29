using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	public float jumpSpeed;
	public float gravity;
	public float mouseSensitivity;

	public Transform cam;

	public AudioClip jumpSound;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	private AudioSource audioSrc;

	private const float MIN_VERT_ROTATION = -90;
	private const float MAX_VERT_ROTATION = 90;
	private float horizRotation = 0;
	private float vertRotation = 0;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
		audioSrc = GetComponent<AudioSource>();
	}

	private void Update()
	{
		UpdateCamera();

		if (controller.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //TODO take this outta the grounded check
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
			{
				audioSrc.PlayOneShot(jumpSound);
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	private void UpdateCamera()
	{
		float horizTurn = mouseSensitivity * Input.GetAxis("Mouse X");
		float vertTurn = mouseSensitivity * -Input.GetAxis("Mouse Y");
		horizRotation += horizTurn;
		vertRotation += vertTurn;
		vertRotation = Mathf.Clamp(vertRotation, MIN_VERT_ROTATION, MAX_VERT_ROTATION);

		cam.eulerAngles = new Vector3(vertRotation, horizRotation, 0);
		transform.eulerAngles = new Vector3(0, horizRotation, 0);
	}
}
