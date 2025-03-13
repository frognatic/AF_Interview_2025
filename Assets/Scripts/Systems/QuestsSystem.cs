using System;
using Cysharp.Threading.Tasks;
using MessagePipe;
using Zenject;

namespace AF_Interview.Systems
{
    public class QuestsSystem : SystemBase
    {
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
        }

        #endregion
    }
}
