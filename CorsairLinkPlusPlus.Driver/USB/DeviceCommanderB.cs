using HidLibrary;

namespace CorsairLinkPlusPlus.Driver.USB
{
    public class DeviceCommanderB : DeviceOld
    {
        internal DeviceCommanderB(RootDevice root, HidDevice hidDevice) : base(root, hidDevice) { }

        public override string GetName()
        {
            return "Corsair Commander (B)";
        }
    }
}