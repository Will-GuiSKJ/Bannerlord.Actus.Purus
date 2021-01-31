using Bannerlord.Actus.Purus.Utils;
using TaleWorlds.Localization;

namespace Bannerlord.Actus.Purus.Dialogs.MinorFactionTroopRecruitment
{
    internal static class MinorFactionTroopRecruitmentQuery
    {
        private static string localizationId = "{=ActusPurus.MinorFactionTroopRecruitmentQuery}";
        private static string _message = "I'm looking to hire some of your warriors.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = DialogTokenShortcuts.mainOptions;
        public static string next = "actus.purus.minor_faction_troop_recruitment_response";
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }

    internal static class MinorFactionTroopRecruitmentResponsePositive
    {
        private static string localizationId = "{=ActusPurus.MinorFactionTroopRecruitmentResponsePositive}";
        private static string _message = $"Some of my men could be persuaded to follow you. But it'll cost you 1000{DialogIconShortcuts.gold} for 20 of my young warriors.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = MinorFactionTroopRecruitmentQuery.next;
        public static string next = "actus.purus.minor_faction_troop_recruitment_options";
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }

    internal static class MinorFactionTroopRecruitmentResponseNegativeRenown
    {
        private static string localizationId = "{=ActusPurus.MinorFactionTroopRecruitmentResponseNegativeRenown}";
        private static string _message = "Why would any of my men want to follow a whelp like you? Come back when any of us have even heard of you.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = MinorFactionTroopRecruitmentQuery.next;
        public static string next = DialogTokenShortcuts.leave;
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }

    internal static class MinorFactionTroopRecruitmentResponseNegativeRelation
    {
        private static string localizationId = "{=ActusPurus.MinorFactionTroopRecruitmentResponseNegativeRelation}";
        private static string _message = "What makes you think my clan would help you? You are no friend of ours.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = MinorFactionTroopRecruitmentQuery.next;
        public static string next = DialogTokenShortcuts.leave;
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }

    internal static class MinorFactionTroopRecruitmentResponseNegativeAlreadyRecruited
    {
        private static string localizationId = "{=ActusPurus.MinorFactionTroopRecruitmentResponseNegativeAlreadyRecruited}";
        private static string _message = "My people are not a swarm of insects for you to pluck whenever you feel like it. You already have some of my warriors, be content they still even fight for you.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = MinorFactionTroopRecruitmentQuery.next;
        public static string next = DialogTokenShortcuts.leave;
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }

    internal static class MinorFactionTroopRecruitmentResponseNegativeNoMoney
    {
        private static string localizationId = "{=ActusPurus.MinorFactionTroopRecruitmentResponseNegativeNoMoney}";
        private static string _message = "A beggar comes to a lion asking for its cubs... Come back when you can afford my warriors.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = MinorFactionTroopRecruitmentQuery.next;
        public static string next = DialogTokenShortcuts.leave;
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }

    internal static class MinorFactionTroopRecruitmentAgreement
    {
        private static string localizationId = "{=ActusPurus.MinorFactionTroopRecruitmentAgreement}";
        private static string _message = "Very well, have your money. It better buy their loyalty.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = MinorFactionTroopRecruitmentResponsePositive.next;
        public static string next = "actus.purus.minor_faction_troop_recruitment_success";
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }

    internal static class MinorFactionTroopRecruitmentDecline
    {
        private static string localizationId = "{=ActusPurus.MinorFactionTroopRecruitmentDecline}";
        private static string _message = "I have changed my mind.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = MinorFactionTroopRecruitmentResponsePositive.next;
        public static string next = DialogTokenShortcuts.lordStart;
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }

    internal static class MinorFactionTroopRecruitmentResponseSuccess
    {
        private static string localizationId = "{=ActusPurus.MinorFactionTroopRecruitmentResponseSuccess}";
        private static string _message = "Gold buys many things but seldom the hearts of men. Still, I'll tell my men to meet you at your camp.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
        public static string entry = MinorFactionTroopRecruitmentAgreement.next;
        public static string next = DialogTokenShortcuts.leave;
        public static string Id { get => QuestIdGenerator.Generate(_message); }
    }
}