using UnityEngine;

namespace TinyGiantStudio.Text
{
    /// <summary>
    /// Under construction. This will handle all the debugging for modular 3d text in the future
    /// </summary>
    public class DebugLogger
    {
        private Modular3DText text;

        public DebugLogger(Modular3DText myText)
        {
            text = myText;
        }

        public void LogToDeleteCharacters(int toDeleteCount)
        {
#if UNITY_EDITOR
            if (text.debugLogs)
                Debug.Log("To delete : <color=green>" + toDeleteCount + "</color> chars on " + text.gameObject, text);
#endif
        }

        public void LogDeletedCharacters(string name)
        {
#if UNITY_EDITOR
            if (text.debugLogs)
                Debug.Log("Destroy object is being called on " + name + " for being unused character object", text);
#endif
        }
    }
}