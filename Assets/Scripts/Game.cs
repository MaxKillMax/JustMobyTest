using JMT.Scenes;
using UnityEngine;
using Time = JMT.Times.Time;

namespace JMT
{
    /// <summary>
    /// Initializator and core logic of all application
    /// </summary>
    public class Game : MonoBehaviour
    {
        [SerializeField] private SceneType _loadingScene;

        private readonly Time _time = new Time();

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneLauncher.Open(_loadingScene);
        }

        private void Update()
        {
            _time.Update();
        }
    }
}