namespace Bannerlord.Actus.Purus.Utils
{
    static class QuestIdGenerator
    {
        public static string Generate(string msg)
        {
            return $"actus.purus.dialog.{msg.GetHashCode()}";
        } 
    }
}
