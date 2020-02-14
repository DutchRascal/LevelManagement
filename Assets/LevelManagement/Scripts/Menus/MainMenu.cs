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
            LevelLoader.LoadNextLevel();
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

