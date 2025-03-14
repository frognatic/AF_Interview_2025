using AF_Interview.Systems;
using UnityEngine;
using Zenject;
namespace AF_Interview.SceneControllers
{
    public class UIGameplaySceneController : BaseSceneController
    {
        #region Injected Fields

        [Inject] private readonly ItemSystem _itemSystem;
        [Inject] private readonly QuestsSystem _questsSystem;
        [Inject] private readonly CraftingSystem _craftingSystem;
        

        #endregion

        #region Protected Methods

        protected override void Start()
        {
            base.Start();

            if (_itemSystem != null)
            {
                Debug.LogWarning($"ItemSystem not null.");
                _itemSystem.IterateAllItems();
            }
            
            if (_questsSystem != null)
            {
                Debug.LogWarning($"QuestsSystem not null.");
            }
            
            if (_craftingSystem != null)
            {
                Debug.LogWarning($"CraftingSystem not null.");
            }
        }

        #endregion
    }
}
