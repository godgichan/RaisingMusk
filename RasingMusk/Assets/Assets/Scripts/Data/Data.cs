using System;
using System.Collections.Generic;

namespace Idle
{
    //This class is used to store the data
    [Serializable]
    public class Data
    {
        public bool isFirstStartComplete;

        public long Money;
        public long MoneyByClick;
        public long MoneyPerSecond;
    }

    [Serializable]
    public class UpgradeData
    {
        public List<ItemData> carProfitsItems = new List<ItemData>();
        public List<ItemData> CompanyAcquisitionItems = new List<ItemData>();
        public List<ItemData> carDevelopmentItems = new List<ItemData>();

        public int companyAcquisitionLvl;
    }


}
