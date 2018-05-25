using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystemInstance
{
    /// <summary>
    /// 场景管理系统
    /// </summary>
    public class SceneSystemInstance : SystemInstance<SceneSystemInstance>
    {
#if UNITY_EDITOR
        [Header("【场景管理系统】")]
        public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
        [System.Serializable]
        public class Setting { }

        public Setting setting;
    }
}

namespace GameSystem
{
    /// <summary>
    /// 场景管理系统
    /// </summary>
    public static class SceneSystem
    {
        /// <summary>
        /// 设置参数
        /// </summary>
        private static GameSystemInstance.SceneSystemInstance.Setting Setting { get { return Instance.setting; } }
        /// <summary>
        /// 实例
        /// </summary>
        private static GameSystemInstance.SceneSystemInstance Instance { get { return GameSystemInstance.SceneSystemInstance.Instance; } }





        //变量--------------------------------
        private static string currentSceneName = "";



        //事件--------------------------------
        /// <summary>
        /// 更新加载进度事件
        /// </summary>
        public static event System.Action<float> UpdateProgress;



        //方法--------------------------------
        /// <summary>
        /// 加载并替换游戏场景
        /// </summary>
        /// <param name="sceneName">场景名</param>
        public static void LoadScene(string sceneName)
        {
            Instance.StartCoroutine(YieldLoadScene(sceneName));
        }
        private static IEnumerator YieldLoadScene(string sceneName)
        {
            //加载Loading场景
            SceneManager.LoadScene("LoadingScene", LoadSceneMode.Additive);

            //卸载原场景
            if (!currentSceneName.Equals(""))
            {
                SceneManager.UnloadSceneAsync(currentSceneName);
            }

            //加载前动画
            //TODO

            //加载新场景
            currentSceneName = sceneName;
            AsyncOperation progress = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            while (!progress.isDone)
            {
                //播放加载效果
                if (UpdateProgress != null)
                {
                    //虽然可以把判断置于循环外减少判断次数，不过意义不大，得不偿失
                    UpdateProgress(progress.progress);
                }
                yield return 0;
            }

            //加载后动画
            //TODO

            //卸载Loading场景
            SceneManager.UnloadSceneAsync("LoadingScene");

            yield return 0;
        }
    }
}