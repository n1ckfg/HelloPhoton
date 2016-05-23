using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhotonPlayerHandler : MonoBehaviour {

    private PhotonView photonView;
	private Renderer ren;
	private Transform target;
	private bool firstRun = true;

	void Start() {
		photonView = GetComponent<PhotonView>();
		ren = GetComponent<Renderer>();
		target = GameObject.FindGameObjectWithTag("Player").transform;
		transform.SetParent(target);
		transform.position = Vector3.zero;
	}

	void Update() {
		if (firstRun) {
			if (photonView.isMine) {
				playerToggle(false);
			}
			firstRun = false;
		}
	}

	public void playerToggle(bool _b) {
		ren.enabled = _b;
	}

}