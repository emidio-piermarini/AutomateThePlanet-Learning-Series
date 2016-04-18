﻿// <copyright file="ItemPage.cs" company="Automate The Planet Ltd.">
// Copyright 2016 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>http://automatetheplanet.com/</site>
using System;
using OpenQA.Selenium;
using PatternsInAutomatedTests.Conference.Base;

namespace PatternsInAutomatedTests.Conference.Pages.Item
{
    public class ItemPage : BasePage<ItemPageMap>, IItemPage
    {
        public ItemPage(IWebDriver driver)
            : base(driver, new ItemPageMap(driver))
        {
        }

        public override string Url
        {
            get
            {
                return "http://www.ebay.com/itm/";
            }
        }

        public void ClickBuyNowButton()
        {
            this.Map.BuyNowButton.Click();
        }

        public double GetPrice()
        {
            throw new NotImplementedException();
        }

        public override void Open(string part)
        {
            //Casio-G-Shock-Standard-GA-100-1A2-Mens-Watch-Brand-New-/161209550414?pt=LH_DefaultDomain_15&hash=item2588d6864e
            base.Open(part);
        }
    }
}
