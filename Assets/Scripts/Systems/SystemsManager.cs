using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using Zenject;

namespace AF_Interview.Systems
{
    public class SystemsManager : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private List<SystemBase> _systemsInitializeOrder;

        #endregion

        #region Non-Serialized Fields

        private MessagePipeOptions _messagePipeOptions;

        #endregion

        #region Properties

        public bool IsReady { protected set; get; }

        #endregion

        #region Public Methods

        public void Construct()
        {
            for (var i = 0; i < _systemsInitializeOrder.Count; i++)
            {
                var gameSystem = _systemsInitializeOrder[i];
                if (gameSystem == null)
                {
                    Debug.LogError($"Game system with initialization order index of {i} is null!");
                }
                gameSystem.Construct();
            }
        }

        public void InstallBindings(DiContainer container)
        {
            _messagePipeOptions = container.BindMessagePipe();

            for (var i = 0; i < _systemsInitializeOrder.Count; i++)
            {
                var gameSystem = _systemsInitializeOrder[i];

                foreach (var contractType in gameSystem.BindingContractTypes)
                {
                    container.Bind(contractType).FromInstance(gameSystem);
                }

                if (gameSystem == null)
                {
                    Debug.LogError($"Game system with initialization order index of {i} is null!");
                }
                
                gameSystem.InstallBindings(container, _messagePipeOptions);
                container.QueueForInject(gameSystem);
            }
        }

        [Inject]
        public async UniTask Init()
        {
            if (IsReady)
            {
                Debug.LogError("Systems are already initialized!");
                return;
            }
            
            foreach (var gameSystem in _systemsInitializeOrder)
            {
                await gameSystem.Init();
            }
        }

        public async UniTask DeInit()
        {
            foreach (var gameSystem in _systemsInitializeOrder)
            {
                await gameSystem.DeInit();
            }
            
            IsReady = false;
        }

        #endregion

        #region Private Methods

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private async void OnDestroy()
        {
            await DeInit();
        }

        #endregion
    }
}
