using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook2Manager : MyBehaviour {

	public GameObject[] arrows;
	public GameObject arrowsP;
	public GameObject prefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator enterArrows(float speed = 0.01f)
	{
		while (true)
		{
			//foreach (GameObject hook in hooks)
			//{
			//	print(hooksP.transform.position.x);
			if (Mathf.Abs(arrowsP.transform.position.x - 0) < 2.4)
			{
				//StartCoroutine(enterGun());
				yield break;
			}
			arrowsP.transform.position = new Vector3(arrowsP.transform.position.x + 0.1f, arrowsP.transform.position.y, arrowsP.transform.position.z);
			//}
			Instantiate(prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
			yield return new WaitForSeconds(speed);
		}
	}
}
