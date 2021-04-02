using UnityEngine;

namespace Idle
{
    public class UpgradeManager : MonoBehaviour
    {

        [Header("Components")]
        public CarProfitsUpgrade carProfitsUpgrade;
        public CompanyAcquisitionUpgrade companyAcquisitionUpgrade;
        public CarDevelopmentUpgrade carDevelopmentUpgrade; //버튼 항목별로 다 만들어주기

        private void Awake()
        {
            //load saves from file
            UpgradeLoad();
        }

        ////////////////////////////////// Start: Calls upgrades from buttons
        public void CarProfitsUpgrade(int itemId)
        {
            carProfitsUpgrade.UpgradeItem(itemId); //Call the upgrade method in the City Upgrade script (whose ID item is the upgrade)
        }

        public void CompanyAcquisitionUpgrade(int itemId)
        {
            companyAcquisitionUpgrade.UpgradeItem(itemId);
        }

        public void CarDevelopmentUpgrade(int itemId)
        {
            carDevelopmentUpgrade.UpgradeItem(itemId);
        }
        ////////////////////////////////// End


        //Update UI
        public void UpdateUI()
        {
            carProfitsUpgrade.UpdateUI();
            companyAcquisitionUpgrade.UpdateUI();
            carDevelopmentUpgrade.UpdateUI();
        }

        //saving upgrade data to file
        public void UpgradeSave()
        {
            //We clear the list of all items, in order to avoid writing
            UpgradeListClear();

            //Write items to the cleared list
            for (int i = 0; i < carProfitsUpgrade.items.Count; i++)
            {
                DataManager.upgradeData.carProfitsItems.Add(carProfitsUpgrade.items[i].itemData);
            }
            for (int i = 0; i < companyAcquisitionUpgrade.items.Count; i++)
            {
                DataManager.upgradeData.CompanyAcquisitionItems.Add(companyAcquisitionUpgrade.items[i].itemData);
            }
            for (int i = 0; i < carDevelopmentUpgrade.items.Count; i++)
            {
                DataManager.upgradeData.carDevelopmentItems.Add(carDevelopmentUpgrade.items[i].itemData);
            }

            //save all data
            DataManager.SaveData();
        }
        //load data
        public void UpgradeLoad()
        {
            if (DataManager.upgradeData.carProfitsItems.Count > 0)
                for (int i = 0; i < carProfitsUpgrade.items.Count; i++)
                {
                    //write item from file to item on scene
                    carProfitsUpgrade.items[i].itemData = DataManager.upgradeData.carProfitsItems[i];
                }
            if (DataManager.upgradeData.CompanyAcquisitionItems.Count > 0)
                for (int i = 0; i < companyAcquisitionUpgrade.items.Count; i++)
                {
                    companyAcquisitionUpgrade.items[i].itemData = DataManager.upgradeData.CompanyAcquisitionItems[i];
                }
            if (DataManager.upgradeData.carDevelopmentItems.Count > 0)
                for (int i = 0; i < carDevelopmentUpgrade.items.Count; i++)
                {
                    carDevelopmentUpgrade.items[i].itemData = DataManager.upgradeData.carDevelopmentItems[i];
                }

        }

        //Сlear method
        void UpgradeListClear()
        {
            DataManager.upgradeData.carProfitsItems.Clear(); 
            DataManager.upgradeData.CompanyAcquisitionItems.Clear();
            DataManager.upgradeData.carDevelopmentItems.Clear();
        }
    }
}