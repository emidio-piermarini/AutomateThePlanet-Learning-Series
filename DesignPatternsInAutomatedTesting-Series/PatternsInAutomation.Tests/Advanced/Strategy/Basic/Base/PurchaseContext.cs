﻿// <copyright file="PurchaseContext.cs" company="Automate The Planet Ltd.">
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
using PatternsInAutomatedTests.Advanced.Strategy.Data;
using PatternsInAutomatedTests.Advanced.Strategy.Pages.ItemPage;
using PatternsInAutomatedTests.Advanced.Strategy.Pages.PreviewShoppingCartPage;
using PatternsInAutomatedTests.Advanced.Strategy.Pages.ShippingAddressPage;
using PatternsInAutomatedTests.Advanced.Strategy.Pages.ShippingPaymentPage;
using PatternsInAutomatedTests.Advanced.Strategy.Pages.SignInPage;

namespace PatternsInAutomatedTests.Advanced.Strategy.Basic.Base
{
    public class PurchaseContext
    {
        private readonly IOrderValidationStrategy orderValidationStrategy;

        public PurchaseContext(IOrderValidationStrategy orderValidationStrategy)
        {
            this.orderValidationStrategy = orderValidationStrategy;
        }

        public void PurchaseItem(string itemUrl, string itemPrice, ClientLoginInfo clientLoginInfo, ClientPurchaseInfo clientPurchaseInfo)
        {
            ItemPage.Instance.Navigate(itemUrl);
            ItemPage.Instance.ClickBuyNowButton();
            PreviewShoppingCartPage.Instance.ClickProceedToCheckoutButton();
            SignInPage.Instance.Login(clientLoginInfo.Email, clientLoginInfo.Password);
            ShippingAddressPage.Instance.FillShippingInfo(clientPurchaseInfo);
            ShippingAddressPage.Instance.ClickContinueButton();
            ShippingPaymentPage.Instance.ClickBottomContinueButton();
            ShippingPaymentPage.Instance.ClickTopContinueButton();
            this.orderValidationStrategy.ValidateOrderSummary(itemPrice, clientPurchaseInfo);
        }
    }
}
