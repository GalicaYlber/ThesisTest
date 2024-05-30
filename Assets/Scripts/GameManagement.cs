using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;

public class GameManagement : MonoBehaviour
{
	[SerializeField] GameObject mainCamera;
	[SerializeField] GameObject UI;
	[SerializeField] Transform chatBox;
	[SerializeField] GameObject player;
	[SerializeField] GameObject playerObject;

	private ExampleCharacterController characterController;
	private Vector3 startPos;
	private Quaternion startRot;

	private bool playMode = false;

	void Start() {
		characterController = player.GetComponent<ExampleCharacterController>();
		startPos = player.transform.position;
	}

    public void Play() {
		UI.SetActive(false);
		mainCamera.SetActive(false);
		playerObject.SetActive(true);

		playMode = true;
	}

	public void StopGame() {
		characterController.enabled = false;
		player.transform.position = startPos;
		// player.transform.rotation = Quaternion.Euler(0, 90, 0);
		characterController.enabled = true;

		playerObject.SetActive(false);
		UI.SetActive(true);
		mainCamera.SetActive(true);

		playMode = false;
		Cursor.lockState = CursorLockMode.None;

		for (int i = 1; i < chatBox.childCount; i++) {
			Destroy(chatBox.GetChild(i).gameObject);
		}
	}

	void Update() {
		if (playMode && Input.GetKeyDown(KeyCode.Escape)) {
			StopGame();
		}
	}
}
