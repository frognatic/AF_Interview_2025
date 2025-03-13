using AF_Interview.Systems;
using UnityEngine;
using Zenject;

namespace AF_Interview.Installers
{
    public class SystemInstaller : MonoInstaller
    {
        #region Serialized Fields

        [SerializeField] private SystemsManager _systemsManagerPrefab;

        #endregion

        #region Override Methods

        public override void InstallBindings()
        {
            var gameSystemManager = Instantiate(_systemsManagerPrefab);
            gameSystemManager.Construct();
            gameSystemManager.InstallBindings(Container);
            Container.QueueForInject(gameSystemManager);
        }

        #endregion
    }
}
