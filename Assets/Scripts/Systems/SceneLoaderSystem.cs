using System;
using AF_Interview.Utilities;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine.SceneManagement;
using Zenject;

namespace AF_Interview.Systems
{
    public class SceneLoaderSystem : SystemBase
    {
        #region Override Methods

        public override Type[] BindingContractTypes => new Type[]
        {
            typeof(SceneLoaderSystem)
        };
        public override void Construct()
        {

        }
        public override void InstallBindings(DiContainer container, MessagePipeOptions messagePipeOptions)
        {

        }

        public override async UniTask Init()
        {
            await LoadGameplay();
            
            IsReady = true;
        }

        #endregion
        
        #region Public Methods

        public async UniTask LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        public async UniTask UnloadSceneAsync(string sceneName)
        {
            await SceneManager.UnloadSceneAsync(sceneName);
        }

        #endregion

        #region Private Methods

        private async UniTask LoadGameplay()
        {
            await LoadSceneAsync(SceneNames.Gameplay, LoadSceneMode.Additive);
            await LoadSceneAsync(SceneNames.UIGameplay, LoadSceneMode.Additive);
            await UnloadSceneAsync(SceneNames.Loader);
        }

        #endregion
    }
}
