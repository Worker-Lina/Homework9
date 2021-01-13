using System;

namespace BackupCopy
{
    public class Flash : Storage
    {
        public double Speed { get; set; }
        public double FlashMemoryVolume { get; set; }
        

        public override bool CopyDataToDevice(double memoryCopyData)
        {
            if(memoryCopyData <= FlashMemoryVolume)
            {
                UsedMemory = memoryCopyData;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override double GetFreeMemoryVolume()
        {
            return FlashMemoryVolume - UsedMemory;
        }

        public override string GetInfoAboutDevice()
        {
            return $"Name: {StorageName}\nModel: {StorageModel}\nSpeed: {Speed}\nMemoryVolume: {FlashMemoryVolume}";
        }

        public override double GetMemorySize()
        {
            return FlashMemoryVolume;
        }
    }
}
