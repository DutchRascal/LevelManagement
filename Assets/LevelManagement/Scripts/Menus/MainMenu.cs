using System.Collections;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;


namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {

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

