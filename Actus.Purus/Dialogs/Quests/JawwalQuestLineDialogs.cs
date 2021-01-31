using TaleWorlds.Localization;

namespace Bannerlord.Actus.Purus.Dialogs.Quests.JawwalQuestLineDialogs
{
    internal static class Title
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.Title}";
        private static string _message = "Bedouin Trouble";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    #region Quest Logs

    internal static class QuestStartedLog
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.QuestStartedLog}";
        private static string _message = "Find {QuestGiverName} at {SettlementName} and ask about the Jawwal problem.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class QuestAcceptedLog
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.QuestAcceptedLog}";
        private static string _message = "{QuestGiverName} has asked you to defeat at least one of the Jawwal parties and bring the leader as a prisoner back.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class JawwalLeaderCapturedLog
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.JawwalLeaderCapturedLog}";
        private static string _message = "You have captured at least one Jawwal leader. Return to {QuestGiverName} in {SettlementName}.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class JawwalHelpAcceptedLog
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.JawwalHelpAcceptedLog}";
        private static string _message = "You have decided to help the Jawwal by attacking one of {QuestGiverName}'s Caravans near {SettlementName}.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class QuestTimedOutLog
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.QuestTimedOutLog}";
        private static string _message = "{QuestGiverName} has notified you that {?IsMale}he{?}she{\\?} is tired of waiting for you to act.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class QuestCompletedForMerchantLog
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.QuestCompletedForMerchantLog}";
        private static string _message = "You delivered those Jawwal dogs to {QuestGiverName}. Your work is done.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class QuestCompletedForJawwalLog
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.QuestCompletedForJawwalLog}";
        private static string _message = "You freed the Jawwal prisoners and gained the clan's trust. You have been named Sadiq to all Jawwal.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class QuestFailedOnPurposeLog
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.QuestFailedOnPurposeLog}";
        private static string _message = "You decided to walk away from this mess and let both parties handle this on their own. Neither will like you, but at least your hands are clean.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    #endregion Quest Logs

    #region Merchant Dialogs

    internal static class PlayerAsksMerchantForQuest
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerAsksMerchantForQuest}";
        private static string _message = "I heard the Jawwal are praying upon your caravans. I may be able to help.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class MerchantInitialResponse1
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.MerchantInitialResponse1}";
        private static string _message = "Those jackals hide behind their nomad ways so that they can pillage and plunder civilized folk!";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class MerchantInitialResponse2
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.MerchantInitialResponse2}";
        private static string _message = "They have been raiding my caravans with impunity, lately. If you defeat even one of their rading parties and bring me its leader, I'll make you rich.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerQuestInformationOption1
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerQuestInformationOption1}";
        private static string _message = "Why you? Have they targetd anyone else?";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class MerchantQuestInformationOption1Response
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.MerchantQuestInformationOption1Response}";
        private static string _message = "How would I know? All I can tell you is that I am bleeding denars because of them.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerQuestInformationOption2
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerQuestInformationOption2}";
        private static string _message = "Tell me more about the Jawwal.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class MerchantQuestInformationOption2Response1
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.MerchantQuestInformationOption2Response1}";
        private static string _message = "Their name means Roamers, I think. What they are is simply disguised bandits.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class MerchantQuestInformationOption2Response2
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.MerchantQuestInformationOption2Response2}";
        private static string _message = "They use the veil of their so called old ways to run around claiming territory and demanding tribute.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerAcceptQuest
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerAcceptQuest}";
        private static string _message = "Alright, consider it done.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    #endregion Merchant Dialogs

    #region Jawwal Dialogs

    internal static class PlayerMeetsJawwal
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerMeetsJawwal}";
        private static string _message = "A merchant in {SettlementName} has put a bounty on Jawwal leaders. I intend to collect.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class JawwalMeetingResponse
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.JawwalMeetingResponse}";
        private static string _message = "Let me guess. That vermin {QuestGiverName} has convinced you to hunt us like dogs.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerAttacksJawwal
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerAttacksJawwal}";
        private static string _message = "Enough talk, I am here to do a job.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerAsksJawwalToExplain
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerAsksJawwalToExplain}";
        private static string _message = "So, it is personal between you and {QuestGiverName}?";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class JawwalExplaination1
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.JawwalExplaination1}";
        private static string _message = "Yes. My people brokered an agreement years ago with {?IS_MALE}him{?}her{\\?}. But it didn't last.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class JawwalExplaination2
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.JawwalExplaination2}";
        private static string _message = "Now {?IsMale}he{?}she{\\?} ambushes my people to sell them as slaves. Women and children too.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerNegativeReactionToExplaination
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerNegativeReactionToExplaination}";
        private static string _message = "This changes nothing. I am here to do a job.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerPositiveReactionToExplaination
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerPositiveReactionToExplaination}";
        private static string _message = "That is horrible. My promise to {?IS_MALE}him{?}her{\\?} is over.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class JawwalAsksForHelp
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.JawwalAsksForHelp}";
        private static string _message = "{QuestGiverName} is transporting some of my people and warriors on one of {?IsMale}his{?}her{\\?} Caravans as we speak. We are ready to lead a rescue. Will you join us?";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerNegativeReactionToHelp
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerNegativeReactionToHelp}";
        private static string _message = "No. I wash my hands off this whole affair.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class JawwalNegativeReactionToHelpResponse
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.JawwalNegativeReactionToHelpResponse}";
        private static string _message = "Very well, then be gone. We have nothing left to discuss.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerPositiveReactionToHelp
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerPositiveReactionToHelp}";
        private static string _message = "Yes. Me and my men will help you.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class JawwalPositiveReactionToHelpResponse
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.JawwalPositiveReactionToHelpResponse}";
        private static string _message = "Fate sends you to us, sadiq. We cannot act so close to {SettlementName}. But you can. Wait for the Caravan to aproach the town and attack it.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerSidesWithJawwalResponse
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerSidesWithJawwalResponse}";
        private static string _message = "Very well. I'll go there at once.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerDeclinesToHelpJawwal
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerDeclinesToHelpJawwal}";
        private static string _message = "I will not attack a Caravan for you. I won't help {QuestGiverName}, but you are on your own.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    #endregion Jawwal Dialogs

    #region Sided with Merchant

    internal static class PlayerReturnsToMerchant
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerReturnsToMerchant}";
        private static string _message = "About your Jawwal problem.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class MerchantQueryOnCompletion
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.MerchantQueryOnCompletion}";
        private static string _message = "I hope you are here to tell me you have one of the leaders of those Jackals with you.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerNotCompletedResponse
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerNotCompletedResponse}";
        private static string _message = "No, not yet.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerReadyToSideWithMerchant
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerReadyToSideWithMerchant}";
        private static string _message = "I do, but it is going to cost you.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class MerchantInitialOffer
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.MerchantInitialOffer}";
        private static string _message = $"I'll pay you 1000{DialogIconShortcuts.gold} for each one you have brought me.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    internal static class PlayerAcceptedOffer
    {
        private static string localizationId = "{=ActusPurus.JawwalQuestLineDialogs.PlayerAcceptedOffer}";
        private static string _message = "Deal.";
        public static TextObject message = new TextObject($"{localizationId}{_message}");
    }

    #endregion Sided with Merchant
}