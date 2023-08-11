#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace SpacegoatStudios.Core
{
    public class SpacegoatStudiosEditorWindow : MonoBehaviour
    {
        #region Editor Methods

        [MenuItem("Spacegoat Studios/About")]
        public static void ShowWindow()
        {
            Application.OpenURL("https://spacegoatstudios.com/");
        }

        #endregion
    }
}

#endif