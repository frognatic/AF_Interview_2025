using System;
using AF_Interview.Quests;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using Zenject;

namespace AF_Interview.Systems
{
    public class QuestsSystem : SystemBase
    {
        #region Serialized Fields

        [SerializeField] protected QuestsLibrary _questsLibrary;

        #endregion
        
        #region Override Methods

        public override Type[] BindingContractTypes => new Type[]
        {
            typeof(QuestsSystem)
        };
        public override void Construct()
        {

        }
        public override void InstallBindings(DiContainer container, MessagePipeOptions messagePipeOptions)
        {

        }

        public override async UniTask Init()
        {
            IsReady = true;
            await UniTask.CompletedTask;
        }

        #endregion
    }
}
