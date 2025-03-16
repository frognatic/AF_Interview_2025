using System;
using System.Collections.Generic;
using AF_Interview.Crafting;
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

        [Inject] private readonly IPublisher<QuestProgressUpdateEvent> _questProgressUpdateEventPublisher;
        [Inject] private readonly IPublisher<QuestCompletedEvent> _questCompletedEventPublisher;
        
        [Inject] private readonly ISubscriber<CraftingFinishedEvent> _craftingFinishedEventSubscriber;
        
        [Inject] private readonly QuestsFactoryProvider _questsFactory;
        [Inject] private readonly ItemSystem _itemSystem;
        [Inject] private readonly CraftingSystem _craftingSystem;

        #endregion
        
        #region Non-serialized Fields
        
        private List<UserQuest> _quests = new List<UserQuest>();
        private IDisposable _eventsBagDisposable;
        
        #endregion

        #region Properties

        public List<UserQuest> Quests => _quests;

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
            container.BindMessageBroker<QuestProgressUpdateEvent>(messagePipeOptions);
            container.BindMessageBroker<QuestCompletedEvent>(messagePipeOptions);
            
            container.Bind<QuestsFactoryProvider>()
                .AsSingle();
        }

        public override async UniTask Init()
        {
            PrepareStartQuests();
            
            var bag = DisposableBag.CreateBuilder();
            _craftingFinishedEventSubscriber.Subscribe(e => TryUpdateQuestsProgressByFinishRecipe(e.Recipe)).AddTo(bag);
            
            _eventsBagDisposable = bag.Build();
            
            IsReady = true;
            await UniTask.CompletedTask;
        }

        public override async UniTask DeInit()
        {
            _eventsBagDisposable?.Dispose();
            
            IsReady = false;
            await UniTask.CompletedTask;
        }

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
        
        private void TryUpdateQuestsProgressByFinishRecipe(Recipe recipe)
        {
            List<UserQuest> updatedQuests = new();
            List<UserQuest> completedQuests = new();

            foreach (var craftingResult in recipe.RecipeData.CraftingResults)
            {
                foreach (var quest in _quests)
                {
                    if (quest.TryUpdateProgress(craftingResult.Key, craftingResult.Value))
                    {
                        updatedQuests.Add(quest);
                        if (quest.IsFinished)
                        {
                            completedQuests.Add(quest);
                        }
                    }
                }
            }
            
            foreach (var quest in updatedQuests)
            {
                _questProgressUpdateEventPublisher.Publish(new QuestProgressUpdateEvent() { UserQuest = quest });
            }

            foreach (var quest in completedQuests)
            {
                _questCompletedEventPublisher.Publish(new QuestCompletedEvent() { UserQuest = quest });
            }
        }

        #endregion
    }
}
