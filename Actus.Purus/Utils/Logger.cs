using TaleWorlds.Core;
using TaleWorlds.Library;

namespace Bannerlord.Actus.Purus.Utils
{
    static class Logger
    {
        public static bool debugMode = false;

        public static void Log(string message, bool force = false)
        {
            if (debugMode || force)
                InformationManager.DisplayMessage(new InformationMessage(message, new Color(1f, 0.84f, 0f, 1f)));
        }
    }
}
