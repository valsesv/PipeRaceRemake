using UnityEngine;

namespace valsesv._Project.Scripts.Helpers
{
    public class BreakingItem : MonoBehaviour
    {
        [SerializeField] private GameObject wholeObject;
        [SerializeField] private GameObject brokenObject;

        protected virtual void Start()
        {
            EnableGravity(false);
        }

        public void BreakItem()
        {
            EnableGravity(true);
        }

        private void EnableGravity(bool isEnabled)
        {
            wholeObject.SetActive(!isEnabled);
            brokenObject.SetActive(isEnabled);
        }
    }
}