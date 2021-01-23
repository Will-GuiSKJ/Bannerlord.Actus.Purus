using TaleWorlds.CampaignSystem;

namespace Bannerlord.Actus.Purus.Behaviors
{
    internal class DebugBehavior : CampaignBehaviorBase
    {
        private bool _doSetup = true;

        public override void RegisterEvents()
        {
        }

        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData<bool>("_doSetup", ref _doSetup);
        }
    }
}