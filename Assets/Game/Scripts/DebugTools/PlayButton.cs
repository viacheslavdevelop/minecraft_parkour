using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.DebugTools
{
    public class PlayButton : MonoBehaviour
    {
        public void Play(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}