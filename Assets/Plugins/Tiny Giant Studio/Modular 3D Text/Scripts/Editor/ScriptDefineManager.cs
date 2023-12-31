#if UNITY_EDITOR

using System;
using System.Linq;
using UnityEditor;

namespace MText
{
    internal static class ScriptDefineManager
    {
        readonly private static string mTextDefine = "MODULAR_3D_TEXT";

        [InitializeOnLoadMethod]
        private static void AddScriptDefine()
        {
            BuildTargetGroup currentTarget = EditorUserBuildSettings.selectedBuildTargetGroup;

            if (currentTarget == BuildTargetGroup.Unknown)
                return;

            string scriptDefinesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(currentTarget).Trim(); //TODO: 2023. https://docs.unity3d.com/2023.1/Documentation/ScriptReference/PlayerSettings.GetScriptingDefineSymbolsForGroup.html
            string[] scriptDefines = scriptDefinesString.Split(';');

            if (scriptDefines.Contains(mTextDefine))
                return;

            //This shouldn't be needed for 1 symbol but an existing third party tool was causing issue or this is really needed and i dont understand how this works
            if (scriptDefinesString.EndsWith(";", StringComparison.InvariantCulture) == false)
            {
                scriptDefinesString += ";";
            }

            scriptDefinesString += mTextDefine;

            PlayerSettings.SetScriptingDefineSymbolsForGroup(currentTarget, scriptDefinesString);
        }
    }
}
#endif