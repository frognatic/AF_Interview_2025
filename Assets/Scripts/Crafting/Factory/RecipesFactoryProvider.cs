using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AF_Interview.Crafting
{
    public class RecipesFactoryProvider
    {
        [Inject]
        public RecipesFactoryProvider()
        {
        }
        
        private readonly Dictionary<Type, IRecipesFactory> _factories = new Dictionary<Type, IRecipesFactory>()
        {
            { typeof(RecipeSO), new RecipesFactory() }
        };

        public Recipe CreateRecipe(RecipeSO data)
        {
            if (_factories.TryGetValue(data.GetType(), out IRecipesFactory factory))
            {
                return factory.CreateRecipe(data);
            }

            Debug.LogError($"Can't create recipe {data.GetType().Name}");
            return null;
        }
    }
}
