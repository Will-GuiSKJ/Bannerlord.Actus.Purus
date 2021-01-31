using Bannerlord.Actus.Purus.Utils;
using TaleWorlds.Localization;

namespace Bannerlord.Actus.Purus.Dialogs.MinorFactionQuestStarter
{
    internal static class TavernWorkQuery
    {
        private static string localizationId = "{=ActusPurus.TavernWorkQuery}";
        private static string _message = "I'm looking for work. Have you heard of anyone needing a salesword?";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = DialogTokenShortcuts.tavernKeeperStart;
        public static string next = "actus.purus.minor_faction_quest_tavern_work_response";
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }

    internal static class TavernWorkResponse
    {
        private static string localizationId = "{=ActusPurus.TavernWorkResponse}";
        private static string _message = "I haven't heard anything, sorry.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = TavernWorkQuery.next;
        public static string next = DialogTokenShortcuts.end;
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }

    internal static class TavernWorkJawwalResponse1
    {
        private static string localizationId = "{=ActusPurus.TavernWorkJawwalResponse1}";
        private static string _message = "I hear the Jawwal have been stirring up trouble, ambushing caravans coming out of town.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = TavernWorkQuery.next;
        public static string next = "actus.purus.jawwal_quest_starter";
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }

    internal static class TavernWorkJawwalResponse2
    {
        private static string localizationId = "{=ActusPurus.TavernWorkJawwalResponse2}";
        private static string _message = "Talk to {MERCHANT}. I'm sure {?IS_MALE}he{?}she{\\?} is looking for someone that can help.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = TavernWorkJawwalResponse1.next;
        public static string next = DialogTokenShortcuts.end;
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }
}