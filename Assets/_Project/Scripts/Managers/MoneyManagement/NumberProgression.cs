using System;
using NaughtyAttributes;
using UnityEngine;

namespace valsesv._Project.Scripts.Managers.MoneyManagement
{
    [Serializable]
    public class NumberProgression
    {
        [SerializeField] protected int startPrice;
        [SerializeField] protected int baseAmount;
        [SerializeField] protected float baseAmountIncreasePrice;
        [SerializeField] private float maxBaseAmount;
        [Space(10)]
        [SerializeField, DisableIf("true")]
        private float[] values;

        [Button("UpdateValues")]
        public void UpdateValues(int sampleValuesAmount)
        {
            values = new float[sampleValuesAmount];
            for (int i = 1; i <= sampleValuesAmount; i++)
            {
                values[i] = GetPrise(i);
            }
        }

        public int GetPrise(int level)
        {
            return level switch
            {
                <= 1 => startPrice,
                _ => GetPrise(level - 1) + GetGrowthPrice(level)
            };
        }

        private int GetGrowthPrice(int level)
        {
            return (int)Mathf.Min((int)(baseAmountIncreasePrice * (level - 1) + baseAmount), maxBaseAmount);
        }
    }
}