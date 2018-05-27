using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    [Header("小游戏游戏一物体的初始位置，不提供在面板里修改")]
#endif
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
    /// 火焰的动画播放控制器
    /// </summary>
    Animator fireAnim_1, fireAnim_2;
    /// <summary>
    /// 左火枪
    /// </summary>
    GameObject firegun_1;
    /// <summary>
    /// 右火枪
    /// </summary>
    GameObject firegun_2;

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
    private float backPositionXscale = 0.1f;
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
    /// <summary>
    /// 进度条的位置
    /// </summary>
    private Vector3 initPlace_1_1;
    /// <summary>
    /// 判断游戏是否结束
    /// </summary>
    private bool isOver = false;

    private void Start()
    {
		GameSystem.AudioSystem.Play(GameSystem.SettingSystem.Setting.cook1_bk);
        StartCoroutine(PlayOneController_1());
        //变量初始化
        transform.GetChild(0).position = initPlace_1;
        g_1 = transform.GetChild(0).GetChild(0).transform;
        initPlace_1_1 = g_1.position;
        backPositionXscale = (float)clickSpeed / 50;
        g_1_sr = g_1.GetChild(0).GetComponent<SpriteRenderer>();
        g_1_sr_color = g_1_sr.color;

        //动画有关初始化
        firegun_1 = transform.GetChild(1).GetChild(0).gameObject;
        firegun_2 = transform.GetChild(1).GetChild(1).gameObject;
        fireAnim_1 = firegun_1.transform.GetChild(0).GetComponent<Animator>();
        fireAnim_2 = firegun_2.transform.GetChild(0).GetComponent<Animator>();
        firegun_1.transform.DOLocalMove(new Vector3(-7.243f, 2.23f, 0f), 2f);
        firegun_2.transform.DOLocalMove(new Vector3(7.243f, 2.23f, 0f), 2f);
    }

    private void Update()
    {
        myTime += Time.deltaTime;
        if (!isOver)
        {

            if (completePercent >= 0.99f)
            {
                StartCoroutine(OverFunc(true));
            }
            else if (myTime >= forwardTime)
            {
                StartCoroutine(OverFunc(false));

            }
        }

        if (Input.GetKeyDown(GameSystem.SettingSystem.Setting.Input1)&&!isOver)
        {
			GameSystem.AudioSystem.Play(GameSystem.SettingSystem.Setting.cook1_space);
            Vector3 tmpPos = new Vector3(g_1.position.x + 0.5f, g_1.position.y, g_1.position.z);
            g_1.position = tmpPos;
            CompletionAndColorController();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
        }
    }

    private IEnumerator PlayOneController_1()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            if ((g_1.position.x > initPlace_1.x)&&!isOver)
            {
                Vector3 g_1_tMP_P = new Vector3((g_1.position.x - backPositionXscale), g_1.position.y, g_1.position.z);
                g_1.position = g_1_tMP_P;
                CompletionAndColorController();
            }
        }
    }

    private void CompletionAndColorController()
    {
        completePercent = (g_1.position.x - initPlace_1_1.x) / (LeftBorderAndRightBorder.y - LeftBorderAndRightBorder.x);
        g_1_sr_color.g = 1 - completePercent;
        g_1_sr_color.b = 1 - completePercent;
        g_1_sr.color = g_1_sr_color;
    }

    private IEnumerator OverFunc(bool isCompleted)
    {
        isOver = true;
        Debug.Log(myTime + "完成度：" + completePercent * 100 + "%");
        yield return new WaitForSecondsRealtime(0.1f);
        fireAnim_1.SetBool("isFire", true);
        fireAnim_2.SetBool("isFire", true);
		GameSystem.AudioSystem.Play(GameSystem.SettingSystem.Setting.cook1);
		yield return new WaitForSeconds(2);
        fireAnim_1.SetBool("isFire", false);
        fireAnim_2.SetBool("isFire", false);
        g_1.parent.gameObject.SetActive(false);
        firegun_1.transform.DOLocalMove(new Vector3(-11.62f, 4.5f, 0f), 2f);
        firegun_2.transform.DOLocalMove(new Vector3(11.62f, 4.5f, 0f), 2f);
        yield return new WaitForSeconds(2);
        CookManager.cookManager.NextUnit();
    }

}
