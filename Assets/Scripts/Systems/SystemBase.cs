using System;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using Zenject;

namespace AF_Interview.Systems
{
    public abstract class SystemBase : MonoBehaviour
    {
        #region Public Methods

        public abstract Type[] BindingContractTypes { get; }
        public virtual bool IsReady { get; protected set; }

        public virtual async UniTask Init()
        {
            IsReady = true;
            await UniTask.CompletedTask;
        }

        public virtual async UniTask DeInit()
        {
            IsReady = false;
            await UniTask.CompletedTask;
        }

        public abstract void Construct();
        public abstract void InstallBindings(DiContainer container, MessagePipeOptions messagePipeOptions);

        #endregion
    }
}
