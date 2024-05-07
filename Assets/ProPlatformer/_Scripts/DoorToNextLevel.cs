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

        // ӳ�佫���������볡��������������
        Dictionary<string, int> sceneIndexMap = new Dictionary<string, int>()
        {
            { "Level1", 1 },
            { "Level2", 2 },
            { "Level3", 3 },
            { "Level4", 4 },
            { "Level5", 5 },
               // ��Ӹ���ĳ������ƺͶ�Ӧ������
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
                // �첽����ָ�����Ƶĳ���
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

                // �ȴ������������
                while (!asyncLoad.isDone)
                {
                    yield return null;
                }

                // ����������ɺ󲥷Ŷ���
                animator.SetTrigger("Start");
            }
            else
            {
                Debug.LogError("Scene name not found in the scene index map: " + sceneName);
            }
        }
    }
}
