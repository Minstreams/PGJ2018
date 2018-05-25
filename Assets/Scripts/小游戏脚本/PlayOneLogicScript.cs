using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// little game one logic
/// </summary>
public class PlayOneLogicScript : MyBehaviour
{
    /// <summary>
    /// 设置小游戏一的参数
    /// </summary>
    /// <param name="clickSpeed">能量条衰减的速度，5对应每秒五次点击才能跟上</param>
    /// <param name="time">该游戏持续的时间</param>
    public void SetPlayOneLogicPara(int clickSpeed,float forwardTime)
    {
        this.clickSpeed = clickSpeed;
        this.forwardTime = forwardTime;

    }

    public float TheCompleteDegree()
    {
        return completePercent;
    }
#if UNITY_EDITOR
    [Header("小游戏游戏一物体的初始位置")]
#endif
    [SerializeField]
    private Vector3 initPlace = new Vector3(0, 0, 0);
    public Vector3 InitPlace { get { return initPlace; } }
#if UNITY_EDITOR
    [Header("大能量条的初始位置")]
#endif
    /// <summary>
    /// 小游戏一的子物体的初始位置，包括ui
    /// 这里是能量条
    /// </summary>
    [SerializeField]
    private Vector3 initPlace_1 = new Vector3(0, 0, 0);
#if UNITY_EDITOR
    [Header("能量条的初始位置左和右")]
#endif
    [SerializeField]
    private Vector2 LeftBorderAndRightBorder = new Vector2(0, 3);

    //子物体1 点击的图
    Transform g_1;

    /// <summary>
    /// 设置一秒要点的次数
    /// </summary>
    private int clickSpeed = 5;
    /// <summary>
    /// 此次小游戏持续的时间
    /// </summary>
    private float forwardTime = 5f;
    /// <summary>
    /// 能量条回退的速度对应的位置的值
    /// </summary>
    private float backPositionXscale=0.05f;
    /// <summary>
    /// 在时间结束前的完成度
    /// 时间内完成则是1
    /// </summary>
    private float completePercent = 0f;

    private float myTime = 0;
    private void OnEnable()
    {
        g_1 = transform.GetChild(0).transform.GetChild(0).transform;

        transform.position = initPlace;
        transform.GetChild(0).transform.position = new Vector3(0, 0, 0);
    }

    private void Start()
    {
        StartCoroutine(PlayOneController_1());
        //变量初始化
        backPositionXscale = (float)clickSpeed / 50;
        Debug.Log(clickSpeed);
        Debug.Log(backPositionXscale);
    }

    private void Update()
    {
        if (Input.GetKeyDown(GameSystem.SettingSystem.Setting.Input1))
        {
            Vector3 tmpPos = new Vector3(g_1.position.x + 0.2f, g_1.position.y, g_1.position.z);
            g_1.position = tmpPos;
        }
    }
    
    private IEnumerator PlayOneController_1()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            if (g_1.position.x > initPlace_1.x)
            {
                Vector3 g_1_tMP_P = new Vector3((g_1.position.x - backPositionXscale), g_1.position.y, g_1.position.z);
           
                g_1.position = g_1_tMP_P;
            }
        }
    }


}
