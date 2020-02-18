using System.Collections;
using LevelManagement.Data;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        [SerializeField] private float _playDelay = 0.5f;
        [SerializeField] private TransitionFader startTransitionPrefab;
        [SerializeField] private InputField _inputField;

        private DataManager _dataManager;

        protected override void Awake()
        {
            base.Awake();
            _dataManager = Object.FindObjectOfType<DataManager>();
        }

        private void Start()
        {
            LoadData();
        }

        public void OnPlayPressed()
        {
            StartCoroutine(OnPlayPressedRoutine());
        }

        private IEnumerator OnPlayPressedRoutine()
        {
            TransitionFader.PlayTransition(startTransitionPrefab);
            LevelLoader.LoadNextLevel();
            yield return new WaitForSeconds(_playDelay);
            GameMenu.Open();
        }

        public void OnSettingsPressed()
        {
            SettingsMenu.Open();
        }

        public void OnCreditsPressed()
        {
            CreditsScreen.Open();
        }

        public void OnPlayerNameValueChanged(string name)
        {
            if (_dataManager != null)
            {
                _dataManager.PlayerName = name;
            }
        }

        public void OnPlayerNameEndEdit()
        {
            if (_dataManager != null)
            {
                _dataManager.Save();
            }
        }

        private void LoadData()
        {
            if (_dataManager != null && _inputField != null)
            {
                _dataManager.Load();
                _inputField.text = _dataManager.PlayerName;
            }
        }

        public override void OnBackPressed()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
        }
    }
}

