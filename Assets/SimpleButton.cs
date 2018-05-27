using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    public GameSystem.MenuSystem.ButtonMessage message;
    private void Update()
    {
        RaycastHit info;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out info) && info.collider == GetComponent<Collider>() && Input.GetMouseButtonDown(0))
        {
            GameSystem.MenuSystem.SendButtonMessage(message);
        }
    }
}
