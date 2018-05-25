using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 开火管理器
/// </summary>
[DisallowMultipleComponent]
public class CookManager : MyBehaviour
{
    /// <summary>
    /// 单例
    /// </summary>
    public static CookManager cookManager { get; private set; }
    private void Awake()
    {
        if (cookManager != null)
        {
            Debug.LogError("有重复的CookManager存在于场景中！");
        }
        cookManager = this;
    }

    //结构-----------------------------------------------------

    /// <summary>
    /// 开火单位
    /// </summary>
	public abstract class CookUnit
    {
        /// <summary>
        /// 对应Manager
        /// </summary>
        protected CookManager manager;
        public CookUnit(CookManager manager)
        {
            this.manager = manager;
        }
        /// <summary>
        /// 载入时执行代码
        /// </summary>
        public abstract void Enter();
        /// <summary>
        /// 退出时执行代码
        /// </summary>
        public abstract void Exit();
    }

    /// <summary>
    /// 开火数据
    /// </summary>
    public class CookData
    {
        public CookData(UnitType type)
        {
            this.type = type;
        }
        public UnitType type;
    }

    /// <summary>
    /// Unit类型
    /// </summary>
    public enum UnitType
    {
        End,
        type1,
        type2,
        type3
    }


    //变量-----------------------------------------------------
    private CookUnit currentUnit = null;

    /// <summary>
    /// 当前Unit数据
    /// </summary>
    public CookData currentData { get; private set; }
    /// <summary>
    /// 下一Unit数据
    /// </summary>
    public CookData nextData { get; private set; }


    //内部实现-------------------------------------------------
    private void Start()
    {
        currentUnit = new CookStart(this);
        currentUnit.Enter();
    }

    private CookUnit TypeToUnit(UnitType type)
    {
        switch (type)
        {
            case UnitType.End:
                return new CookEnd(this);
            case UnitType.type1:
                return new Cook1(this);
            case UnitType.type2:
                return new Cook2(this);
            case UnitType.type3:
                return new Cook3(this);
            default:
                Debug.LogError("不可能有这种问题。");
                return null;
        }
    }

    private void GenerateNewData()
    {
        currentData = nextData;
        //TODO 生成新Data
        nextData = new CookData((UnitType)Random.Range(0, System.Enum.GetValues(typeof(UnitType)).Length));
    }

    //方法-----------------------------------------------------
    /// <summary>
    /// 切换到下一个Unit
    /// </summary>
    public void NextUnit()
    {
        if (currentUnit == null)
        {
            Debug.LogError("指针空了，蛤蛤");
        }
        currentUnit.Exit();
        GenerateNewData();
        currentUnit = TypeToUnit(currentData.type);
        currentUnit.Enter();
    }


}


public class CookStart : CookManager.CookUnit
{
    public CookStart(CookManager manager) : base(manager)
    {
    }

    public override void Enter()
    {
        manager.StartCoroutine(enter());
    }

    public override void Exit()
    {
        
    }

    private IEnumerator enter()
    {
        //TODO 入场动画
        throw new System.NotImplementedException();
    }
}
public abstract class CookPlay : CookManager.CookUnit
{
    private GameObject prefab = null;
    protected abstract GameObject prefabPos { get;}
    public CookPlay(CookManager manager) : base(manager)
    {
    }

    public override sealed void Enter() 
    {
        prefab = GameObject.Instantiate(prefabPos);
    }

    public override sealed void Exit()
    {
        GameObject.Destroy(prefab);
    }
}
public class Cook1 : CookPlay
{
    public Cook1(CookManager manager) : base(manager)
    {
    }

    protected override GameObject prefabPos
    {
        get
        {
            return GameSystem.SettingSystem.Setting.Cook1Prefab;
        }
    }
}
public class Cook2 : CookPlay
{
    private GameObject prefab = null;
    public Cook2(CookManager manager) : base(manager)
    {
    }

    protected override GameObject prefabPos
    {
        get
        {
            return GameSystem.SettingSystem.Setting.Cook2Prefab;
        }
    }
}
public class Cook3 : CookPlay
{
    public Cook3(CookManager manager) : base(manager)
    {
    }

    protected override GameObject prefabPos
    {
        get
        {
            return GameSystem.SettingSystem.Setting.Cook3Prefab;
        }
    }
}
public class CookEnd : CookManager.CookUnit
{
    public CookEnd(CookManager manager) : base(manager)
    {
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}