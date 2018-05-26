using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook3Manager : MyBehaviour {

	public GameObject hooksP;
	public GameObject[] hooks;
	public GameObject gun;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(enterHooks());
	}
	
	// Update is called once per frame
	void Update () {
		check();
	}

	private IEnumerator enterHooks(float speed = 0.01f)
	{
		while (true)
		{
			//foreach (GameObject hook in hooks)
			//{
			//	print(hooksP.transform.position.x);
			if (Mathf.Abs(hooksP.transform.position.x - 0) < 2.4)
			{
				StartCoroutine(enterGun());
				yield break;
			}
			hooksP.transform.position = new Vector3(hooksP.transform.position.x + 0.1f, hooksP.transform.position.y, hooksP.transform.position.z);
			//}
			yield return new WaitForSeconds(speed);
		}
	}

	private IEnumerator hideHooks(float speed = 0.01f)
	{
		while (true)
		{
			//foreach (GameObject hook in hooks)
			//{
			//	print(hooksP.transform.position.x);
			if (Mathf.Abs(hooksP.transform.position.x - 16.9f) < 2.4)
			{
				yield break;
			}
			hooksP.transform.position = new Vector3(hooksP.transform.position.x + 0.1f, hooksP.transform.position.y, hooksP.transform.position.z);
			//}
			yield return new WaitForSeconds(speed);
		}
	}

	private IEnumerator enterGun(float speed = 0.01f)
	{
		int i = 1;
		while (true)
		{
			if (Mathf.Abs(gun.transform.position.x - 7.5f) < 0.1f)
			{
				i = -1;
			}
			if ((Mathf.Abs(gun.transform.position.x + 14f) < 0.1f) && i == -1)
			{
				StartCoroutine(hideHooks());
				yield break;
			}
			gun.transform.position = new Vector3(gun.transform.position.x + 0.1f * i, gun.transform.position.y, gun.transform.position.z);
			yield return new WaitForSeconds(speed);
		}

	}

	private bool check()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			foreach (GameObject hook in hooks)
			{
				if (Mathf.Abs(gun.transform.position.x - hook.transform.position.x) < 1.5)
				{
					print("中了");
					hook.GetComponent<SpriteRenderer>().color = Color.red;
					return true;
				}
			}
		}
		return false;
	}
}
