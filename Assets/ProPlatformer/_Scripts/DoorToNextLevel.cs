using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YourNamespace
{
    public class DoorToNextLevel : MonoBehaviour
    {
        public static DoorToNextLevel instance;

        [SerializeField] Animator animator;

        // 映射将场景名称与场景索引关联起来
        Dictionary<string, int> sceneIndexMap = new Dictionary<string, int>()
        {
            { "Level1", 1 },
            { "Level2", 2 },
            { "Level3", 3 },
            { "Level4", 4 },
            { "Level5", 5 },
               // 添加更多的场景名称和对应的索引
        };

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void nextLevel(string sceneName)
        {
            StartCoroutine(LoadLevel(sceneName));
        }

        IEnumerator LoadLevel(string sceneName)
        {
            animator.SetTrigger("End");
            yield return new WaitForSeconds(1);

            int sceneIndex;
            if (sceneIndexMap.TryGetValue(sceneName, out sceneIndex))
            {
                // 异步加载指定名称的场景
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

                // 等待场景加载完成
                while (!asyncLoad.isDone)
                {
                    yield return null;
                }

                // 场景加载完成后播放动画
                animator.SetTrigger("Start");
            }
            else
            {
                Debug.LogError("Scene name not found in the scene index map: " + sceneName);
            }
        }
    }
}
