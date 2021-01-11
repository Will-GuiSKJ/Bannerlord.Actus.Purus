using TaleWorlds.Library.EventSystem;

namespace Bannerlord.Actus.Purus.CustomEvents
{
    internal class FaceGenVMCustomEventOn : EventBase
    { }

    internal class FaceGenVMCustomEventOff : EventBase
    { }

    internal class FaceGenVMCustomEventUpdate : EventBase
    { }

    internal class FaceGenVMCustomEventGenderChanged : EventBase
    {
        public int Gender { get; set; }

        public FaceGenVMCustomEventGenderChanged(int gender) => Gender = gender;
    }
}