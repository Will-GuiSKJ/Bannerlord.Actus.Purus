using Bannerlord.Actus.Purus.Utils;

namespace Bannerlord.Actus.Purus.Dialogs.RogueryBandit
{
    static class BanditRecruitStart
    {
        public static string message = "You all look in terrible need of new management.";
        public static string entry = DialogTokenShortcuts.attackingBandits;
        public static string next = "actus.purus.roguery_bandit_recruit_offer";
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class BanditRecruitOffer
    {
        public static string message = "What say you all join my party and stop fighting for scraps like dogs?";
        public static string entry = BanditRecruitStart.next;
        public static string next = "actus.purus.roguery_bandit_recruit_question";
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class BanditRecruitQuestion
    {
        public static string message = "And if we decline this amazing offer?";
        public static string entry = BanditRecruitOffer.next;
        public static string next = "actus.purus.roguery_bandit_recruit_answer";
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class BanditRecruitAnswer
    {
        public static string message = "Well... I proceed to run you through and deliver you to the next town.";
        public static string entry = BanditRecruitQuestion.next;
        public static string next = "actus.purus.roguery_bandit_recruit_offer_response";
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class BanditRecruitOfferBestResponse
    {
        public static string message = "When you put it like that, I guess me and mine will agree to join you.";
        public static string entry = BanditRecruitAnswer.next;
        public static string next = DialogTokenShortcuts.end;
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }

    static class BanditRecruitOfferOKResponse
    {
        public static string message = "That threat may work on some of us, but don't expect us all to be so spineless.";
        public static string entry = BanditRecruitAnswer.next;
        public static string next = DialogTokenShortcuts.end;
        public static string Id { get => QuestIdGenerator.Generate(message); }
    }
}