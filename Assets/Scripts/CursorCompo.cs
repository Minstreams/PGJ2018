using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCompo : MonoBehaviour
{

    private static GameObject child;
    private void Awake()
    {
        child = transform.GetChild(0).gameObject;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Camera.current != null)
        {
            transform.position = Camera.current.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        }
    }

    public static void SetVisible(bool b)
    {
        child.SetActive(b);
    }
}
