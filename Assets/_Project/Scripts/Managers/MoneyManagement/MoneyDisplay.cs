using TMPro;
using UnityEngine;
using valsesv._Project.Scripts.Helpers;
using Zenject;

namespace valsesv._Project.Scripts.Managers.MoneyManagement
{
    public class MoneyDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyText;

        [Inject] private MoneyWallet _moneyWallet;

        private void Start()
        {
            _moneyWallet.MoneyCountChanged += Display;
            Display();
        }

        private void Display()
        {
            moneyText.text = TextFormatter.NumberWithLetter(_moneyWallet.MoneyCount);
        }
    }
}
