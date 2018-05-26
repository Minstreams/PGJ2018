using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItSelf : MonoBehaviour {
	public float seconds;
	void Start () {
		StartCoroutine(des());
	}

	IEnumerator des() {
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
	}
}
