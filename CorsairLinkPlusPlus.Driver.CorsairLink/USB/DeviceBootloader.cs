using HidLibrary;

namespace CorsairLinkPlusPlus.Driver.CorsairLink.USB
{
    public class DeviceBootloader : DeviceOld
    {
        internal DeviceBootloader(CorsairRootDevice root, HidDevice hidDevice) : base(root, hidDevice) { }

        public override string GetName()
        {
            return "Corsair Bootloader";
        }
    }
}