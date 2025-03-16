using UnityEngine;

namespace AF_Interview.Utilities
{
    public static class TransformUtilities
    {
        public static void DestroyAllChildren(this Transform transform, bool setLoose = false)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Transform child = transform.GetChild(i);
                if (setLoose)
                    child.SetParent(null);
                Object.Destroy(child.gameObject);
            }
        }
        
        public static void DestroyImmediateAllChildren(this Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
                Object.DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
}
