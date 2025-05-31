using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using valsesv._Project.Scripts.Interfaces;
using valsesv._Project.Scripts.Managers.MoneyManagement;
using Zenject;

namespace valsesv._Project.Scripts.Managers.SaveManagement
{
    public class SaveManager : MonoBehaviour, IManager
    {
        public SaveData ProgressData { get; private set; } = new();

        private string _progressDataSavePath;

        [Inject] private MoneyWallet _moneyWallet;

        public void Init()
        {
            CreateSaveFile();
            LoadProgressData();
        }

        private void SaveProgressData()
        {
            var jsonString = JsonPrettify(ProgressData);
            File.WriteAllText(_progressDataSavePath, jsonString);
        }

        public void SaveMoney(float amount)
        {
            ProgressData.moneyCount = amount;
            SaveProgressData();
        }

        private void CreateSaveFile()
        {
            _progressDataSavePath = GetSavePath("progressData.json", SaveFileType.ProgressData);

            foreach (SaveFileType statType in Enum.GetValues(typeof(SaveFileType)))
            {
                var directoryName = GetDirectoryPath(statType);
                if (Directory.Exists(directoryName) == false)
                {
                    Directory.CreateDirectory(directoryName);
                }
            }
        }

        private void LoadProgressData()
        {
            if (File.Exists(_progressDataSavePath) == false)
            {
                ProgressData = new SaveData
                {
                    moneyCount = _moneyWallet.MoneyCount
                };
                return;
            }

            var json = File.ReadAllText(_progressDataSavePath);
            ProgressData = JsonConvert.DeserializeObject<SaveData>(json);
        }

        private static string GetSavePath(string fileName, SaveFileType saveFileType)
        {
            fileName = SanitizeFileName(fileName);
            return Path.Combine(GetDirectoryPath(saveFileType), fileName);
        }

        private static string SanitizeFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName,
                (current, invalidChar) => current.Replace(invalidChar.ToString(), ""));
        }

        private static string JsonPrettify(object value)
        {
            var json = JsonConvert.SerializeObject(value, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            using var stringReader = new StringReader(json);
            using var stringWriter = new StringWriter();
            var jsonReader = new JsonTextReader(stringReader);
            var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
            jsonWriter.WriteToken(jsonReader);
            return stringWriter.ToString();
        }

        private static string GetDirectoryPath(SaveFileType saveFileType)
        {
            switch (saveFileType)
            {
                case SaveFileType.ProgressData:
                    return Path.Combine(Application.persistentDataPath, saveFileType.ToString());;
                case SaveFileType.PlayerData:
                    return Path.Combine(Application.streamingAssetsPath, saveFileType.ToString());
                default:
                    throw new ArgumentOutOfRangeException(nameof(saveFileType), saveFileType, null);
            }
        }
    }
}