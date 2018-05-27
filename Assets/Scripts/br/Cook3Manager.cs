using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook3Manager : MyBehaviour {

	public GameObject hooksP;
	//public GameObject[] hooks;
	public GameObject gun;
	public GameObject fire;
	private GameObject pupa2;
	private GameObject pupa3;
	private List<GameObject> hooks = new List<GameObject>();
	public GameObject hookP;

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
		GameSystem.AudioSystem.Play(GameSystem.SettingSystem.Setting.hookEnter);
		for (int i = 0; i < 5; i++)
		{
			hooks.Add(Instantiate(hookP, new Vector3(-10 - i * 3, 6f, 0), Quaternion.Euler(0, 0, 0)));
			hooks[i].transform.SetParent(transform);
		}
		while (true)
		{
			int j = 0;
			foreach (GameObject hook in hooks)
			{
				if (j == hooks.Count / 2 && Mathf.Abs(hook.transform.position.x - 0) < 0.1f)
				{
					StartCoroutine(enterGun());
					yield break;
				}
				hook.transform.position = new Vector3(hook.transform.position.x + 0.1f, hook.transform.position.y, hook.transform.position.z);
				j++;
			}
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
			if (Mathf.Abs(gameObject.transform.position.x - 17f) < 0.3f)
			{
				CookManager.cookManager.NextUnit();
				yield break;
			}
			gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
			//}
			yield return new WaitForSeconds(speed);
		}
	}

	private IEnumerator enterGun(float speed = 0.01f)
	{
		int i = 1;
		while (true)
		{
			GameSystem.AudioSystem.WaitForRythm();
			if (Mathf.Abs(gun.transform.position.x - 7.5f) < 0.1f)
			{
				i = -1;
			}
			if ((Mathf.Abs(gun.transform.position.x + 14f) < 0.1f) && i == -1)
			{
				gun.transform.SetParent(transform.parent);
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
			GameObject.Instantiate(fire, gun.transform.position, Quaternion.identity, null);
			foreach (GameObject hook in hooks)
			{
				if (Mathf.Abs(gun.transform.position.x - hook.transform.position.x) < 1.2)
				{
					//fire.SetActive(true);
					//hook.GetComponent<SpriteRenderer>().color = Color.red;
					GameSystem.AudioSystem.Play(GameSystem.SettingSystem.Setting.cook3);
					hook.transform.GetChild(0).gameObject.SetActive(false);
					hook.transform.GetChild(1).gameObject.SetActive(true);
					return true;
				}
			}
		}
		return false;
	}
}
