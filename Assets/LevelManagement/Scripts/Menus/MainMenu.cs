using System.Collections;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;


namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        [SerializeField] private float _playDelay = 0.5f;

        public void OnPlayPressed()
        {
            StartCoroutine(OnPlayPressedRoutine());
        }

        private IEnumerator OnPlayPressedRoutine()
        {
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

