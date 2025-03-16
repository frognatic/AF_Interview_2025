using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AF_Interview.Quests
{
    public class QuestsFactoryProvider
    {
        
        [Inject]
        public QuestsFactoryProvider()
        {
        }
        
        private readonly Dictionary<Type, IUserQuestsFactory> _factories = new Dictionary<Type, IUserQuestsFactory>()
        {
            { typeof(QuestSO), new UserQuestsFactory() }
        };

        public UserQuest CreateQuest(QuestSO data)
        {
            if (_factories.TryGetValue(data.GetType(), out IUserQuestsFactory factory))
            {
                return factory.CreateUserQuest(data);
            }

            Debug.LogError($"Can't create quest {data.GetType().Name}");
            return null;
        }
    }
}
