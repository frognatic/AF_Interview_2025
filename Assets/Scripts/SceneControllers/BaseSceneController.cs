using UnityEngine;

namespace AF_Interview.SceneControllers
{
    public abstract class BaseSceneController : MonoBehaviour
    {
        protected virtual void Start()
        {
            Debug.LogWarning($"Start {gameObject.name}");
        }
    }
}
