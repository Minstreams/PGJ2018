using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    /// <summary>
    /// 游戏系统流程管理实例
    /// </summary>
    [AddComponentMenu("Components/Game System")]
    [RequireComponent(typeof(AudioSystemInstance))]
    [RequireComponent(typeof(SceneSystemInstance))]
    [RequireComponent(typeof(MenuSystemInstance))]
    [RequireComponent(typeof(SettingSystemInstance))]
    public class GameSystemInstance : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("【游戏系统】")]
        public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
        //编辑器模式下，全局查重，防止有多个游戏系统
        private static GameSystemInstance instance = null;
        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("不允许有多个游戏系统！");
            }
            instance = this;
        }
#endif

        public static int dayNum = 0;
        //游戏启动----------------------------
        private void Start()
        {
            StartCoroutine(start());
        }


        //流程--------------------------------
        private IEnumerator start()
        {
            StartCoroutine(exitCheck());

            GameSystem.SceneSystem.PushScene("StartMenu");
            yield return menuCheck();
        }
        private IEnumerator menuCheck()
        {
            CursorCompo.SetVisible(true);
            //开始场景-------------------------------------
            GameSystem.AudioSystem.PlayMusic(GameSystem.SettingSystem.Setting.bgmSoft);
            while (true)
            {
                if (GameSystem.MenuSystem.GetButtonMessage(GameSystem.MenuSystem.ButtonMessage.Start))
                {
                    print("Start");
                    break;
                }
                yield return 0;
            }

            GameSystem.MenuSystem.ResetButtonMessage();

            //游戏场景-------------------------------------
            CursorCompo.SetVisible(false);

            //此处是每一天的开场动画
            GameSystem.SceneSystem.ChangeScene("Fire");
            yield return cookCheck();
        }

        private IEnumerator cookCheck()
        {
            GameSystem.AudioSystem.PlayMusic(GameSystem.SettingSystem.Setting.bgm);
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameSystem.MenuSystem.SendButtonMessage(GameSystem.MenuSystem.ButtonMessage.OpenMenu);
                }
                if (GameSystem.MenuSystem.GetButtonMessage(GameSystem.MenuSystem.ButtonMessage.OpenMenu))
                {
                    GameSystem.MenuSystem.TurnMenu();
                }
                if (GameSystem.MenuSystem.GetButtonMessage(GameSystem.MenuSystem.ButtonMessage.EndTheDay))
                {
                    GameSystem.MenuSystem.ResetButtonMessage();
                    GameSystem.SceneSystem.ChangeScene("Quanjing");
                    yield return quanJingCheck();
                    break;
                }
                yield return 0;
            }
        }
        private IEnumerator quanJingCheck()
        {
            GameSystem.AudioSystem.PlayMusic(GameSystem.SettingSystem.Setting.bgmSoft);
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameSystem.MenuSystem.SendButtonMessage(GameSystem.MenuSystem.ButtonMessage.OpenMenu);
                }
                if (GameSystem.MenuSystem.GetButtonMessage(GameSystem.MenuSystem.ButtonMessage.OpenMenu))
                {
                    GameSystem.MenuSystem.TurnMenu();
                }
                if (GameSystem.MenuSystem.GetButtonMessage(GameSystem.MenuSystem.ButtonMessage.EndQuanjing))
                {
                    GameSystem.MenuSystem.ResetButtonMessage();
                    dayNum++;
                    if (dayNum >= 2)
                    {
                        GameSystem.SceneSystem.ChangeScene("end");
                        yield return endCheck();
                    }
                    else
                    {
                        GameSystem.SceneSystem.ChangeScene("Fire");
                        yield return cookCheck();
                    }
                    break;
                }
                yield return 0;
            }
        }
        private IEnumerator endCheck()
        {
            GameSystem.AudioSystem.PlayMusic(GameSystem.SettingSystem.Setting.bgm);
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameSystem.SceneSystem.ChangeScene("StartMenu");
                }
            }
        }
        private IEnumerator exitCheck()
        {
            while (true)
            {
                if (GameSystem.MenuSystem.GetButtonMessage(GameSystem.MenuSystem.ButtonMessage.Exit))
                {
                    print("游戏已经结束了！按啥都没用了！");
                    Application.Quit();
                    StopAllCoroutines();
                }
                yield return 0;
            }
        }
    }

    /// <summary>
    /// 游戏子系统父类
    /// </summary>
    /// <typeparam name="InstanceClass"></typeparam>
    public class SystemInstance<InstanceClass> : MonoBehaviour
    {
        private static InstanceClass instance;
        /// <summary>
        /// 实例
        /// </summary>
        public static InstanceClass Instance
        {
            get
            {
                if (instance == null) instance = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<InstanceClass>();
                return instance;
            }
        }
    }
}

#if UNITY_EDITOR
[System.Serializable]
public struct EmptyStruct { }
#endif
