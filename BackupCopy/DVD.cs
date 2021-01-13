using System;

namespace BackupCopy
{
    public class DVD : Storage
    {
        public double SpeedOfReadAndWrite { get; set; }
        public TypeOfDVD TypeOfDVD { get; set; }
        public double DVD1 { get; } = 4.7;
        public double DVD2 { get; } = 9;


        public override bool CopyDataToDevice(double memoryCopyData)
        {
            if(TypeOfDVD==TypeOfDVD.DoubleSidedDVD && memoryCopyData <= DVD2)
            {
                UsedMemory = memoryCopyData;
                return true;
            }
            else if (TypeOfDVD==TypeOfDVD.SingleSidedDVD && memoryCopyData <= DVD1 )
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
            if(TypeOfDVD == TypeOfDVD.DoubleSidedDVD)
            {
                return DVD2 - UsedMemory;
            }
            else
            {
                return DVD1 - UsedMemory;
            }
        }


        public override string GetInfoAboutDevice()
        {
            string type;
            if (TypeOfDVD == TypeOfDVD.SingleSidedDVD)
            {
                type = "односторонний ";
            }
            else 
            {
                type = "двусторонний";
            }
            return $"Name: {StorageName}\nModel: {StorageModel}\nSpeed: {SpeedOfReadAndWrite}\nType: {type}";
        }


        public override double GetMemorySize()
        {
            if (TypeOfDVD == TypeOfDVD.SingleSidedDVD)
            {
                return DVD1;
            }
            else
            {
                return DVD2;
            }
        }
    }
}
