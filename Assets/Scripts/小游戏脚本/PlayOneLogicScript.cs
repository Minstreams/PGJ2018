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
    /// <param name="time">该游戏持续的时间(在该时间内完成）</param>
    public void SetPlayOneLogicPara(int clickSpeed, float forwardTime)
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
    [Header("能量条的初始位置左和右(中间点的位置）")]
#endif
    [SerializeField]
    private Vector2 LeftBorderAndRightBorder = new Vector2(0, 3);

    /// <summary>
    /// 子物体1 点击出现的能量条图
    /// </summary>
    Transform g_1;
    /// <summary>
    /// 能量条的renderer
    /// </summary>
    SpriteRenderer g_1_sr;
    /// <summary>
    /// 能量条的颜色
    /// </summary>
    Color g_1_sr_color;

    /// <summary>
    /// 设置一秒要点的次数
    /// </summary>
    private int clickSpeed = 5;
    /// <summary>
    /// 此次小游戏持续的时间
    /// </summary>
    private float forwardTime = 10f;
    /// <summary>
    /// 能量条回退的速度对应的位置的值
    /// </summary>
    private float backPositionXscale = 0.05f;
    /// <summary>
    /// 在时间结束前的完成度
    /// 时间内完成则是1
    /// </summary>
    private float completePercent = 0f;
    public float CompletePercent { get { return completePercent; } private set { completePercent = value; } }
    /// <summary>
    /// 小游戏一已经进行的时间
    /// </summary>
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
        g_1_sr = g_1.GetComponent<SpriteRenderer>();
        g_1_sr_color = g_1_sr.color;
    }

    private void Update()
    {
        myTime += Time.deltaTime;
        
        if (completePercent>=0.99f)
        {
            //结束 下一个
            CookManager.cookManager.NextUnit();
            Debug.Log(myTime + "完成度：" + completePercent * 100 + "%");
        }
        if(myTime >= forwardTime)
        {
            //结束  失败
            CookManager.cookManager.NextUnit();
            Debug.Log(myTime + "完成度：" + completePercent * 100 + "%");
        }

        if (Input.GetKeyDown(GameSystem.SettingSystem.Setting.Input1))
        {
            Vector3 tmpPos = new Vector3(g_1.position.x + 0.2f, g_1.position.y, g_1.position.z);
            g_1.position = tmpPos;
            CompletionAndColorController();
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(myTime+"完成度：" + completePercent * 100 + "%");
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
                CompletionAndColorController();
            }
        }
    }

    private void CompletionAndColorController()
    {
        completePercent = (g_1.position.x - initPlace_1.x) / (LeftBorderAndRightBorder.y - LeftBorderAndRightBorder.x);
        g_1_sr_color.g = 1-completePercent;
        g_1_sr.color = g_1_sr_color;
    }
}
