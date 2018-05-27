using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 鼠标控制视角移动
/// </summary>
public class FPSCamera : MonoBehaviour
{
    //参数---------------------------------
    [SerializeField, Range(0.5f, 3),Header("鼠标灵敏度")]
    private float horizontalSensitivity = 1;
    [SerializeField, Range(0.5f, 3)]
    private float verticalSensitivity = 1;
    [SerializeField, Range(0, 80)]
    private float angleLimitUp;
    [SerializeField, Range(0, 80)]
    private float angleLimitDown;



    //供调用以精确控制旋转----------------
    /// <summary>
    /// 水平旋转四元数
    /// </summary>
    [HideInInspector]
    public Quaternion horizontalQuaternion = Quaternion.identity;
    /// <summary>
    /// 垂直旋转四元数
    /// </summary>
    [HideInInspector]
    public Quaternion verticalQuaternion;
    private float angleVertical = 0;

    private const float AngleToHalfPIFactor = Mathf.PI / 360.0f;

    private void Update()
    {
        float h = Input.GetAxis("Mouse X") * horizontalSensitivity;
        float v = Input.GetAxis("Mouse Y") * verticalSensitivity;

        horizontalQuaternion *= new Quaternion(0, Mathf.Sin(h * AngleToHalfPIFactor), 0, Mathf.Cos(h * AngleToHalfPIFactor));
        angleVertical += v;
		
        if (angleVertical > 90 - angleLimitUp) { angleVertical = 90 - angleLimitUp; }
        if (angleVertical < angleLimitDown - 90) { angleVertical = angleLimitDown - 90; }

        verticalQuaternion = new Quaternion(-Mathf.Sin(angleVertical * AngleToHalfPIFactor), 0, 0, Mathf.Cos(angleVertical * AngleToHalfPIFactor));

        transform.rotation = horizontalQuaternion * verticalQuaternion;
    }

    private void Start()
    {
        Cursor.visible = false;
    }
    private void OnDestroy()
    {
        Cursor.visible = true;
    }
}
