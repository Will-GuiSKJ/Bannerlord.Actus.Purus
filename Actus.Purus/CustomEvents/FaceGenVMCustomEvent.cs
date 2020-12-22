using TaleWorlds.Library.EventSystem;

namespace Bannerlord.Actus.Purus.CustomEvents
{
    class FaceGenVMCustomEventOn : EventBase { }

    class FaceGenVMCustomEventOff : EventBase { }

    class FaceGenVMCustomEventUpdate : EventBase { }

    class FaceGenVMCustomEventGenderChanged : EventBase
    {
        public int Gender { get; set; }
        public FaceGenVMCustomEventGenderChanged(int gender) => Gender = gender;
    }
}
