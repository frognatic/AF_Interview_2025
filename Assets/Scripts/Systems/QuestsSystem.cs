using System;
using System.Collections.Generic;
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
        
        #region Injected Fields

        [Inject] private QuestsFactoryProvider _questsFactory;

        #endregion
        
        #region Non-serialized Fields
        
        private List<Quest> _quests = new List<Quest>();
        
        #endregion

        #region Properties

        public List<Quest> Quests => _quests;

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
            container.Bind<QuestsFactoryProvider>()
                .AsSingle();
        }

        public override async UniTask Init()
        {
            PrepareStartQuests();
            
            IsReady = true;
            await UniTask.CompletedTask;
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void PrepareStartQuests()
        {
            foreach (var startedQuest in _questsLibrary.InitialQuests)
            {
                var quest = _questsFactory.CreateQuest(startedQuest);
                _quests.Add(quest);
            }
        }

        #endregion
    }
}
