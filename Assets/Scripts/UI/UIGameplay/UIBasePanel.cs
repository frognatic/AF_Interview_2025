using UnityEngine;

namespace AF_Interview
{
    public abstract class DataModel { }
    
    public abstract class UIBasePanel : MonoBehaviour
    {
        protected DataModel DataModel { get; private set; }
        
        public virtual void Prepare(DataModel dataModel)
        {
            DataModel = dataModel;
        }
    }
}
