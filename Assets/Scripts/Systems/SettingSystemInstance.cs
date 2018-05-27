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
            public GameObject Cook1Prefab;
            public KeyCode Input1;
            public GameObject Cook2Prefab;
            public GameObject Cook3Prefab;

			public AudioClip cook1;
			public AudioClip hookEnter;
			public AudioClip hookLeft;
			public AudioClip[] cook3;
			public AudioClip[] cook1_space;
			public AudioClip cook1_fire;
			public AudioClip cook1_bk;
			public AudioClip[] cook2_kan;
			public AudioClip[] testAudios;
			public AudioClip bgm;
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