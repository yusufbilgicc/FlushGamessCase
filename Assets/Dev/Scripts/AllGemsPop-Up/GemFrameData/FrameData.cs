using UnityEngine;

namespace Dev.Scripts.AllGemsPop_Up.GemFrameData
{
    [CreateAssetMenu(fileName = "FrameData", menuName = "FrameData", order = 0)]
    public class FrameData : ScriptableObject
    {

        public string gemType;
        public Sprite frameIcon;
    }
}