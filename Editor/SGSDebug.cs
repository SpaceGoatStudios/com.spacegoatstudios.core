namespace SpacegoatStudios.Core
{
    public class SGSDebug
    {
        [System.Diagnostics.Conditional("ENABLE_LOG")]
        public static void Log(object message)
        {
            UnityEngine.Debug.Log(message);
        }
        
        [System.Diagnostics.Conditional("ENABLE_LOG")]
        public static void LogError(object message)
        {
            UnityEngine.Debug.LogError(message);
        }
        
        [System.Diagnostics.Conditional("ENABLE_LOG")]
        public static void LogWarning(object message)
        {
            UnityEngine.Debug.LogWarning(message);
        }
    }
}