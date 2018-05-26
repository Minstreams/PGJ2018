using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook2Manager : MyBehaviour {

	public List<GameObject> arrows = new List<GameObject>();
	public GameObject arrowsP;
	public GameObject prefab;
	public GameObject hook;
	public GameObject pupa1;
	public GameObject pupa2;
	public GameObject pupa22;
	private Queue<int> result = new Queue<int>(1);
	private int index = 0;
	private bool flag = false;
	// Use this for initialization
	void Start () {
		StartCoroutine(sendIn()); 
	}
	
	// Update is called once per frame
	void Update () {
		check();
	}

	private IEnumerator sendIn()
	{
		hook.SetActive(true);
		yield return new WaitForSeconds(1.2f);
		pupa1.SetActive(true);
		StartCoroutine(enterArrows());
	}

	private IEnumerator sendOut()
	{
		//print(1);
		//pupa22.SetActive(true);
		pupa1.GetComponent<AnimatorTrigger>().Play(0);
		yield return new WaitForSeconds(1.5f);
		hook.GetComponent<AnimatorTrigger>().Play(0);
		yield return new WaitForSeconds(2f);
		CookManager.cookManager.NextUnit();
	}

	public bool check()
	{
		int input = -1;
		if (result.Count == 0)
		{
			//pupa1.SetActive(false);
			if (flag)
			{
				StartCoroutine(sendOut());
				flag = false;
			}
			return false;
		}
		if (Input.GetButtonDown("w"))
		{
			input = 3;
		}
		if (Input.GetButtonDown("s"))
		{
			input = 1;
		}
		if (Input.GetButtonDown("a"))
		{
			input = 0;
		}
		if (Input.GetButtonDown("d"))
		{
			input = 2;
		}
		if (input == result.Peek())
		{
			result.Dequeue();
			if (arrows.Count == 0)
				return false;
			//arrows[index].GetComponent<AnimatorTrigger>().Play(0);
			arrows[index].SetActive(false);
			input = -1;
			index++;
			flag = true;
		}
		return false;
	}
	private IEnumerator enterArrows(float speed = 0.01f)
	{
		for (int i = 0; i < 7; i++)
		{
			int r = Random.Range(0, 3);
			result.Enqueue(r);
			GameObject arrowN = Instantiate(prefab, new Vector3(-10f - i * 3, -4.5f, 0), Quaternion .Euler(0, 0, 90 * r));
			arrows.Add(arrowN);
			arrowN.transform.SetParent(arrowsP.transform);
		}
		while (true)
		{
			for (int i = 0; i < arrows.Count; i++)
			{
				if (Mathf.Abs(arrows[i].transform.position.x - 3.5f + i) < 0.1f)
				{
					continue;	
				}
				arrows[i].transform.position = new Vector3(arrows[i].transform.position.x + 0.1f, arrows[i].transform.position.y, arrows[i].transform.position.z);
			}
			
			yield return new WaitForSeconds(speed);
		}
	}
}
