using System.Collections;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;


namespace LevelManagement
{
    public class MainMenu : Menu
    {
        private static MainMenu _instance;

        public static MainMenu Instance { get { return _instance; } }

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        private void OnDestroy()
        {
            _instance = null;
        }

        public void OnPlayPressed()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadNextLevel();
            }
        }

        public void OnSettingsPressed()
        {
            var sm = SettingsMenu.Instance;
            if (MenuManager.Instance != null && SettingsMenu.Instance != null)
            {
                MenuManager.Instance.OpenMenu(SettingsMenu.Instance);
            }
        }

        public void OnCreditsPressed()
        {
            if (MenuManager.Instance != null && CreditsScreen.Instance != null)
            {
                MenuManager.Instance.OpenMenu(CreditsScreen.Instance);
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

