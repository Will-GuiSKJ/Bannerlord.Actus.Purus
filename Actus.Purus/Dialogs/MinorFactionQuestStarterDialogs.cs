using Bannerlord.Actus.Purus.Utils;

namespace Bannerlord.Actus.Purus.Dialogs.MinorFactionQuestStarter
{
    static class TavernWorkQuery
    {
        public static string message = "I'm looking for work. Have you heard of anyone needing a salesword?";
        public static string entry = DialogTokenShortcuts.tavernKeeperStart;
        public static string next = "actus.purus.tavern_work_response";
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class TavernWorkResponse
    {
        public static string message = "I haven't heard anything, sorry.";
        public static string entry = TavernWorkQuery.next;
        public static string next = DialogTokenShortcuts.end;
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class TavernWorkJawwalResponse1
    {
        public static string message = "I hear the Jawwal have been stirring up trouble, ambushing caravans coming out of town.";
        public static string entry = TavernWorkQuery.next;
        public static string next = "actus.purus.jawwal_quest_starter";
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class TavernWorkJawwalResponse2
    {
        public static string message = "Talk to {MERCHANT}. I'm sure {GENDER_PRONOUN} is looking for someone that can help.";
        public static string entry = TavernWorkJawwalResponse1.next;
        public static string next = DialogTokenShortcuts.end;
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }
}
