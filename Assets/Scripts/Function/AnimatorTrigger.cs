using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 为了更方便用Animator而写的组件
/// </summary>
[AddComponentMenu("Function/Animator Trigger")]
[RequireComponent(typeof(Animator))]
public class AnimatorTrigger : MonoBehaviour
{
    //变量名表列
    //对应Animator里的一系列bool值
    //保证同时只有一个bool值为true
    [Header("【为了更方便用Animator而写的组件】")]
    [Header("控制变量名称"), SerializeField]
    private string[] parameterName;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private string lastParameterName = "";
    public void Play(int index)
    {
        if (index >= parameterName.Length)
        {
            Debug.LogError("序列超出变量数组大小，index：" + index);
            return;
        }

        if (!lastParameterName.Equals(""))
        {
            animator.SetBool(lastParameterName, false);
        }

        lastParameterName = parameterName[index];
        animator.SetBool(parameterName[index], true);
    }
}
