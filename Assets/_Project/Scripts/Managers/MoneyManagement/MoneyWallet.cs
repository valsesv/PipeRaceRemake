using System;
using UnityEngine;
using valsesv._Project.Scripts.Interfaces;
using valsesv._Project.Scripts.Managers.SaveManagement;
using Zenject;

namespace valsesv._Project.Scripts.Managers.MoneyManagement
{
    public class MoneyWallet : MonoBehaviour, IManager
    {
        [SerializeField] private float moneyCount;

        [Inject] private SaveManager _saveManager;

        public event Action MoneyCountChanged;

        public float MoneyCount
        {
            private set
            {
                moneyCount = value;
                _saveManager.SaveMoney(MoneyCount);
                MoneyCountChanged?.Invoke();
            }
            get => moneyCount;
        }

        public void Init()
        {
            Load();
        }

        public void Add(float addAmount) => MoneyCount += addAmount;

        public void Get(float getAmount) => Add(-getAmount);

        private void Load()
        {
            MoneyCount = _saveManager.ProgressData.moneyCount;
        }
    }
}
