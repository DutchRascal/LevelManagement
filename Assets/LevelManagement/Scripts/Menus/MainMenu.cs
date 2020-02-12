using System.Collections;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;


namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        public void OnPlayPressed()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadNextLevel();
            }
            if (MenuManager.Instance != null && GameManager.Instance != null)
            {
                MenuManager.Instance.OpenMenu(GameMenu.Instance);
            }
        }

        public void OnSettingsPressed()
        {
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

