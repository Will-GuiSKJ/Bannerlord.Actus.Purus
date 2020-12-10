using Bannerlord.Actus.Purus.Utils;

namespace Bannerlord.Actus.Purus.Dialogs.MinorFactionTroopRecruitment
{
    static class MinorFactionTroopRecruitmentQuery
    {
        public static string message = "I'm looking to hire some of your warriors.";
        public static string entry = DialogTokenShortcuts.mainOptions;
        public static string next = "actus.purus.minor_faction_troop_recruitment_response";
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class MinorFactionTroopRecruitmentResponsePositive
    {
        public static string message = $"Some of my men could be persuaded to follow you. But it'll cost you. 1000{DialogIconShortcuts.gold} for 20 of my young warriors.";
        public static string entry = MinorFactionTroopRecruitmentQuery.next;
        public static string next = "actus.purus.minor_faction_troop_recruitment_options";
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class MinorFactionTroopRecruitmentResponseNegativeRenown
    {
        public static string message = "Why would any of my men want to follow a whelp like you? Come back when any of us have even heard of you.";
        public static string entry = MinorFactionTroopRecruitmentQuery.next;
        public static string next = DialogTokenShortcuts.end;
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class MinorFactionTroopRecruitmentResponseNegativeRelation
    {
        public static string message = "What makes you think my clan would help you? You are no friend of ours.";
        public static string entry = MinorFactionTroopRecruitmentQuery.next;
        public static string next = DialogTokenShortcuts.end;
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class MinorFactionTroopRecruitmentResponseNegativeAlreadyRecruited
    {
        public static string message = "My people are not a swarm of insects for you to pluck whenever you feel like it. You already have some of my warriors, be content they still even fight for you.";
        public static string entry = MinorFactionTroopRecruitmentQuery.next;
        public static string next = DialogTokenShortcuts.end;
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class MinorFactionTroopRecruitmentResponseNegativeNoMoney
    {
        public static string message = "A beggar comes to a lion asking for its cubs... Come back when you can afford my warriors.";
        public static string entry = MinorFactionTroopRecruitmentQuery.next;
        public static string next = DialogTokenShortcuts.end;
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class MinorFactionTroopRecruitmentAgreement
    {
        public static string message = "Very well, have your money. It better buy their loyalty.";
        public static string entry = MinorFactionTroopRecruitmentResponsePositive.next;
        public static string next = "actus.purus.minor_faction_troop_recruitment_success";
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class MinorFactionTroopRecruitmentDecline
    {
        public static string message = "I have changed my mind";
        public static string entry = MinorFactionTroopRecruitmentResponsePositive.next;
        public static string next = DialogTokenShortcuts.lordStart;
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class MinorFactionTroopRecruitmentResponseSuccess
    {
        public static string message = "Gold buys many things but seldom the hearts of men. Still, I'll tell my men to meet you at your camp.";
        public static string entry = MinorFactionTroopRecruitmentAgreement.next;
        public static string next = DialogTokenShortcuts.leave;
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }
}
