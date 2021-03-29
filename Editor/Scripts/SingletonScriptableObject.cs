using UnityEditor;
using UnityEngine;

namespace ArchNet.DesignPattern.SingletonScriptableObject
{
    /// <summary>
    /// [DESIGN PATTERN] - [ARCH NET] - [SINGLETON SCRIPTABLE OBJECT] Scriptable object Singleton Interface
    /// author : LOUIS PAKEL
    /// </summary>
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance = null;


        public static T Instance(string pPath)
        {
            if (_instance == null)
            {
                T lResult = (T)AssetDatabase.LoadAssetAtPath(pPath, typeof(T));

                if (lResult == null)
                {
                    Debug.LogError("[ARCH NET] - [DESIGN PATTERN] - [SINGLETON SCRIPTABLE OBJECT] Asset is missing");
                    return null;
                }



                _instance = lResult;
                _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
            }

            return _instance;
        }
    }
}
