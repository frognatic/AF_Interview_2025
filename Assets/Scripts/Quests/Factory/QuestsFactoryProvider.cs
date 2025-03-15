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
        
        private readonly Dictionary<Type, IQuestsFactory> _factories = new Dictionary<Type, IQuestsFactory>()
        {
            { typeof(QuestSO), new QuestsFactory() }
        };

        public Quest CreateQuest(QuestSO data)
        {
            if (_factories.TryGetValue(data.GetType(), out IQuestsFactory factory))
            {
                return factory.CreateQuest(data);
            }

            Debug.LogError($"Can't create quest {data.GetType().Name}");
            return null;
        }
    }
}
