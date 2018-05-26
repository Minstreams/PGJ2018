using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook2Manager : MyBehaviour {

	public List<GameObject> arrows = new List<GameObject>();
	public GameObject arrowsP;
	public GameObject prefab;
	private Queue<int> result = new Queue<int>();
	// Use this for initialization
	void Start () {
		StartCoroutine(enterArrows());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool check()
	{

	}
	private IEnumerator enterArrows(float speed = 0.01f)
	{
		for (int i = 0; i < 7; i++)
		{
			int r = Random.Range(1, 4);
			result.Enqueue(r);
			GameObject arrowN = Instantiate(prefab, new Vector3(-11.6f - i * 3, -3.37f, 0), Quaternion .Euler(0, 0, 0));
			arrows.Add(arrowN);
			arrowN.transform.SetParent(arrowsP.transform);
		}
		int rotation = 0;
		bool flag = false;
		while (true)
		{
			//foreach (GameObject hook in hooks)
			//{
			//	print(hooksP.transform.position.x);
			//if (i == 3)
			//{
			//	yield break;
			//}
			//if (Mathf.Abs(arrowsP.transform.position.x - 3.2f * i) < 0.1f)
			//{
			//	GameObject arrowN = Instantiate(arrow, new Vector3(-11.6f, -3.37f, 0), Quaternion .Euler(0, 0, 0));
			//	arrowN.transform.SetParent(arrowsP.transform);
			//	i++;
			//	flag = true;
			//}
			//arrowsP.transform.position = new Vector3(arrowsP.transform.position.x + 0.1f, arrowsP.transform.position.y, arrowsP.transform.position.z);
			//}
			for (int i = 0; i < arrows.Count; i++)
			{
				print(arrows[0].transform.position.x);
				if (Mathf.Abs(arrows[i].transform.position.x - 5.3f + i) < 0.1f)
				{
					continue;	
				}
				arrows[i].transform.position = new Vector3(arrows[i].transform.position.x + 0.1f, arrows[i].transform.position.y, arrows[i].transform.position.z);
			}
			
			yield return new WaitForSeconds(speed);
		}
	}
}
