using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class SettingSystemInstance : SystemInstance<SettingSystemInstance>
    {
#if UNITY_EDITOR
        [Header("【系统配置】")]
        public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
        [System.Serializable]
        public class Setting {
            public KeyCode Input1;
            public KeyCode Input2;
        }

        public Setting setting;
    }
}

namespace GameSystem
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public static class SettingSystem
    {
        /// <summary>
        /// 设置参数
        /// </summary>
        public static GameSystemInstance.SettingSystemInstance.Setting Setting { get { return Instance.setting; } }
        /// <summary>
        /// 实例
        /// </summary>
        private static GameSystemInstance.SettingSystemInstance Instance { get { return GameSystemInstance.SettingSystemInstance.Instance; } }





        //变量--------------------------------



        //事件--------------------------------



        //方法--------------------------------
    }
}