using System;
using System.Collections.Generic;
using System.Text;

namespace BackupCopy
{
    public abstract class Storage
    {
        public string StorageName { get; set; }
        public string StorageModel { get; set; }
        public double UsedMemory { get; set; }


        public abstract double GetMemorySize();
        public abstract bool CopyDataToDevice(double memoryCopyData);
        public abstract double GetFreeMemoryVolume();
        public abstract string GetInfoAboutDevice();

    }
}
