using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook3FireDestory : MyBehaviour {

	
	void Start () {
        StartCoroutine(DestoryMySelf());
	}
	
    IEnumerator DestoryMySelf()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
