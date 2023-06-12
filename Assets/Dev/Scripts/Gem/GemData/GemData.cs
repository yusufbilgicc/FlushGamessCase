using UnityEngine;

namespace Dev.Scripts.Gem.GemData
{
    [CreateAssetMenu(fileName = "Gem", menuName = "GemData", order = 0)]
    public class GemData : ScriptableObject
    {
        public int id;
        public float gemPrice;
        public float growTime;
        
    }
}