using UnityEngine;
using UnityEngine.UI;

namespace Idle
{
    public sealed class UIManager : MonoBehaviour
    {
        //enum
        public enum ShopScreenType { Closed, CarProfitsScreen, CarDevelopmentScreen, CompanyAcquisitionScreen, StockScreen, ItemScreen, SocialMovementScreen, SpacecraftDevelopmentScreen, SpaceDevelopmentScreen}

        [Header("Screens")]
        public GameObject CarProfitsScreen;
        public GameObject CarDevelopmentScreen;
        public GameObject CompanyAcquisitionScreen;
        public GameObject StockScreen;
        public GameObject ItemScreen;
        public GameObject SocialMovementScreen;
        public GameObject SpacecraftDevelopmentScreen;
        public GameObject SpaceDevelopmentScreen;

        [Header("Text")]
        public Text MoneyText;
        public Text MoneyPerSecondText;


        ShopScreenType shopScreenType;        //Enum for tracking open store type
        bool isPause;                         //Check pause status

        private void Start()
        {
            UpdateUI();
        }

        //Update UI Total
        public void UpdateUI()
        {
            //Assign text
            MoneyText.text = IntParseToString(DataManager.data.Money);
            MoneyPerSecondText.text = "+" + IntParseToString(DataManager.data.MoneyPerSecond) + " /s";


            //Update upgrades UI
            Managers.Instance.upgradeManager.UpdateUI();

            //Save data to file
            DataManager.SaveData();
        }

        //Convert number to string with zero replaced by letters
        public static string IntParseToString(long value)
        {
            string result = value.ToString();

            if (value >= 1000)
            {
                result = Mathf.Floor(((float)value / 100)) / 10 + " k";
            }

            if (value >= 1000000)
            {
                result = Mathf.Floor(((float)value / 10000)) / 100 + " mi";
            }

            if (value >= 1000000000)
            {
                result = Mathf.Floor(((float)value / 10000000)) / 100 + " bi";
            }

            if (value >= 1000000000000)
            {
                result = Mathf.Floor(((float)value / 1000000000)) / 1000 + " qua";
            }

            return result;
        }

        #region //Shop
        //The method invokes the opening of the store
        public void ClickShop(string screenName)
        {
            switch (screenName)
            {
                case "CarProfitsScreen":
                    //Call open method
                    ChangeShopScreen(ShopScreenType.CarProfitsScreen);
                    break;
                case "CarDevelopmentScreen":
                    ChangeShopScreen(ShopScreenType.CarDevelopmentScreen);
                    break;
                case "CompanyAcquisitionScreen":
                    ChangeShopScreen(ShopScreenType.CompanyAcquisitionScreen);
                    break;
                case "StockScreen":
                    ChangeShopScreen(ShopScreenType.StockScreen);
                    break;
                case "ItemScreen":
                    ChangeShopScreen(ShopScreenType.ItemScreen);
                    break;
                case "SocialMovementScreen":
                    ChangeShopScreen(ShopScreenType.SocialMovementScreen);
                    break;
                case "SpacecraftDevelopmentScreen":
                    ChangeShopScreen(ShopScreenType.SpacecraftDevelopmentScreen);
                    break;
                case "SpaceDevelopmentScreen":
                    ChangeShopScreen(ShopScreenType.SpaceDevelopmentScreen);
                    break;
            }

        }

        public void ChangeShopScreen(ShopScreenType shopScreenType)
        {
            //If shopScreenType is equal to the same Screen that we ship, the store will be closed
            if (shopScreenType == this.shopScreenType)
            {
                //Calling a method to play an animation from AnimatorManager, by calling Singleton, store collapse animation
                Managers.Instance.animatorManager.PlayAnimation(Managers.Instance.animatorManager.shopAnimator, "ShopHide");
                //set the class variable shopScreenType to closed
                this.shopScreenType = ShopScreenType.Closed;
            }
            else
            {
                //Call the method of closing all screens for further replacement.
                CloseShopScreens();
                switch (shopScreenType)
                {
                    case ShopScreenType.CarProfitsScreen:
                        //set the class variable shopScreenType to local shopScreenType
                        this.shopScreenType = shopScreenType;
                        //Turn on the screen
                        CarProfitsScreen.SetActive(true);
                        break;
                    case ShopScreenType.CarDevelopmentScreen:
                        this.shopScreenType = shopScreenType;
                        CarDevelopmentScreen.SetActive(true);
                        break;
                    case ShopScreenType.CompanyAcquisitionScreen:
                        this.shopScreenType = shopScreenType;
                        CompanyAcquisitionScreen.SetActive(true);
                        break;
                    case ShopScreenType.StockScreen:
                        this.shopScreenType = shopScreenType;
                        StockScreen.SetActive(true);
                        break;
                    case ShopScreenType.ItemScreen:
                        this.shopScreenType = shopScreenType;
                        ItemScreen.SetActive(true);
                        break;
                    case ShopScreenType.SocialMovementScreen:
                        this.shopScreenType = shopScreenType;
                        SocialMovementScreen.SetActive(true);
                        break;
                    case ShopScreenType.SpacecraftDevelopmentScreen:
                        this.shopScreenType = shopScreenType;
                        SpacecraftDevelopmentScreen.SetActive(true);
                        break;
                    case ShopScreenType.SpaceDevelopmentScreen:
                        this.shopScreenType = shopScreenType;
                        SpaceDevelopmentScreen.SetActive(true);
                        break;
                }

                //Store open animation
                Managers.Instance.animatorManager.PlayAnimation(Managers.Instance.animatorManager.shopAnimator, "ShopShow");
            }
        }

        //It is necessary to close all stores, previously called from ChangeShopScreen
        void CloseShopScreens()
        {
            //Just turn off all screens, nothing ordinary :)
            CarProfitsScreen.SetActive(false);
            CarDevelopmentScreen.SetActive(false);
            CompanyAcquisitionScreen.SetActive(false);
            StockScreen.SetActive(false);
            ItemScreen.SetActive(false);
            SocialMovementScreen.SetActive(false);
            SpacecraftDevelopmentScreen.SetActive(false);
            SpaceDevelopmentScreen.SetActive(false);
        }
        #endregion
        #region//Screens
        //Method for changing main screens
        public void ChangeScreen(string screenName)
        {
            switch (screenName)
            {
                case "GameScreen":
                    Managers.Instance.animatorManager.PlayAnimation(Managers.Instance.animatorManager.screensAnimator, "GameScreen");
                    break;

                case "PauseMenu":
                    if (!isPause)
                    {
                        Managers.Instance.animatorManager.PlayAnimation(Managers.Instance.animatorManager.screensAnimator, "PauseMenuShow");
                        isPause = true;
                    }
                    else
                    {
                        Managers.Instance.animatorManager.PlayAnimation(Managers.Instance.animatorManager.screensAnimator, "PauseMenuHide");
                        isPause = false;
                    }
                    break;
            }
        }
        #endregion

    }
}