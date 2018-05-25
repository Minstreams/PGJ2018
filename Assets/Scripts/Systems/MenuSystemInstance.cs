using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    /// <summary>
    /// 菜单系统
    /// </summary>
    [DisallowMultipleComponent]
    public class MenuSystemInstance : SystemInstance<MenuSystemInstance>
    {
#if UNITY_EDITOR
        [Header("【菜单系统】")]
        public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
        private void Reset() { setting.menuParent = transform.GetChild(0).gameObject; }
#endif
        [System.Serializable]
        public class Setting
        {
            /// <summary>
            /// 游戏菜单父物体
            /// </summary>
            [HideInInspector]
            public GameObject menuParent;
        }

        public Setting setting;

    }
}

namespace GameSystem
{
    /// <summary>
    /// 菜单系统
    /// </summary>
    public static class MenuSystem
    {
        /// <summary>
        /// 设置参数
        /// </summary>
        private static GameSystemInstance.MenuSystemInstance.Setting Setting { get { return Instance.setting; } }
        /// <summary>
        /// 实例
        /// </summary>
        private static GameSystemInstance.MenuSystemInstance Instance { get { return GameSystemInstance.MenuSystemInstance.Instance; } }

        //结构--------------------------------
        /// <summary>
        /// 按钮信息枚举
        /// </summary>
        public enum ButtonMessage
        {
            Start,
            Exit
        }



        //变量--------------------------------
        /// <summary>
        /// 菜单是否已经打开
        /// </summary>
        private static bool isOpen = false;
        /// <summary>
        /// 记录按钮信息
        /// </summary>
        private static bool[] buttonMessageReciver = new bool[System.Enum.GetValues(typeof(ButtonMessage)).Length];



        //方法--------------------------------
        /// <summary>
        /// 打开/关闭菜单
        /// </summary>
        public static void TurnMenu()
        {
            if (isOpen)
            {
                CloseMenu();
                isOpen = false;
            }
            else
            {
                OpenMenu();
                isOpen = true;
            }
        }
        private static void OpenMenu()
        {
            Setting.menuParent.SetActive(true);
        }
        private static void CloseMenu()
        {
            Setting.menuParent.SetActive(false);
        }

        /// <summary>
        /// 检查按钮信息，收到则返回true
        /// </summary>
        /// <param name="message">要检查的信息</param>
        /// <returns>检查按钮信息，收到则返回true</returns>
        public static bool GetButtonMessage(ButtonMessage message)
        {
            if (buttonMessageReciver[(int)message])
            {
                buttonMessageReciver[(int)message] = false;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 发送按钮信息
        /// </summary>
        /// <param name="message">信息</param>
        public static void SendButtonMessage(ButtonMessage message)
        {
            buttonMessageReciver[(int)message] = true;
        }
        /// <summary>
        /// 重置
        /// </summary>
        public static void ResetButtonMessage()
        {
            buttonMessageReciver.Initialize();
        }
    }
}