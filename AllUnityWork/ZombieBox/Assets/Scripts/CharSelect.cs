﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour {

	public static GameObject selected;
	public CanvasGroup canvasGroup;

	void Update () {

		if (Input.GetMouseButtonUp (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit ();

			if (Physics.Raycast (ray, out hit, 100)) {
				GameObject found = GameObject.Find (hit.collider.name);
				if (found.GetComponentInParent<Animator> ()) {
					if (selected) {
						selected.GetComponentInParent<Animator> ().SetBool ("selected", false);
					} else {
						canvasGroup.interactable = true;
						canvasGroup.blocksRaycasts = true;
						canvasGroup.alpha = 1; 
					}
					selected = found;
					selected.GetComponentInParent<Animator> ().SetBool ("selected", true);
					Debug.Log (selected);
				}
			}
		}
	}
}