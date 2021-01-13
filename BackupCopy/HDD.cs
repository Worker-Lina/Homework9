
using System;

namespace BackupCopy
{
    public class HDD : Storage
    {
        public double Speed { get; set; }
        public int CountOfSections { get; set; }
        public double VolumeOfSections { get; set; }


        public override double GetMemorySize()
        {
            return VolumeOfSections * CountOfSections;
        }

        public override bool CopyDataToDevice(double memoryCopyData)
        {
            if(memoryCopyData <= CountOfSections* VolumeOfSections)
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
            return CountOfSections * VolumeOfSections - UsedMemory;
        }

        public override string GetInfoAboutDevice()
        {
            return $"Name: {StorageName}\nModel: {StorageModel}\nSpeed: {Speed}\nCountOfSections: {CountOfSections}\nVolumeOfSections: {VolumeOfSections}";
        }

        
    }
}
