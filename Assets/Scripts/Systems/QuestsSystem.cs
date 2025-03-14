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

        [Inject] private IQuestsService _questsService;

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
            container.Bind<IQuestsService>()
                .To<QuestsService>()
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

        public List<Quest> GetQuests() => _questsService.GetQuests();

        #endregion

        #region Private Methods

        private void PrepareStartQuests()
        {
            List<Quest> initialQuests = new();

            foreach (var startedQuest in _questsLibrary.GetDataModel().InitialQuests)
            {
                switch (startedQuest.QuestData.GetDataModel().QuestType)
                {
                    case QuestsTypes.Craft:
                        CraftingQuest craftingQuest = new CraftingQuest(startedQuest.QuestData as CraftingQuestSO);
                        initialQuests.Add(craftingQuest);
                        break;
                }
            }
            
            _questsService.Init(initialQuests);
        }

        #endregion
    }
}
