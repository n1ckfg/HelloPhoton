using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhotonPlayerHandler : MonoBehaviour {

	public string targetTag = "Player";
	public Vector3 offset = new Vector3(0f, 1f, 0f);
    private PhotonView photonView;
	private Renderer ren;
	private Transform target;
	private bool firstRun = true;

	void Start() {
		photonView = GetComponent<PhotonView>();
		ren = GetComponent<Renderer>();
		target = GameObject.FindGameObjectWithTag(targetTag).transform;
	}

	void Update() {
		if (firstRun) {
			if (photonView != null && target != null) {
				if (photonView.isMine) {
					photonView.ObservedComponents[0] = target;
					transform.position = target.position;
					transform.rotation = target.rotation;
					transform.SetParent(target);
					transform.position += offset;
					playerToggle(false);
				}
			}
			firstRun = false;
		} else {
			if (photonView.isMine) {
				// tasks to do every frame if this is the player
			} else {
				// tasks to do every frame if this is not the player
			}
		}
	}

	public void playerToggle(bool _b) {
		ren.enabled = _b;
	}

}