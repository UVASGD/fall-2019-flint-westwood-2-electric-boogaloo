using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Prop", menuName = "Scriptable Objects/Create New Prop", order = 0)]
    public class Prop : ScriptableObject
    {
        public string propName;
        public string propDescription;
        public bool isBreakable;
        public Sprite propImage;
        
    }
}