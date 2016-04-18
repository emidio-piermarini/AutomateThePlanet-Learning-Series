﻿// <copyright file="CreditCardChargeRule[TRuleResult].cs" company="Automate The Planet Ltd.">
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
using PatternsInAutomatedTests.Advanced.Rules.Data;

namespace PatternsInAutomatedTests.Advanced.Rules
{
    public class CreditCardChargeRule<TRuleResult> : BaseRule
        where TRuleResult : class, IRuleResult, new()
    {
        private readonly PurchaseTestInput purchaseTestInput;
        private readonly decimal totalPriceLowerBoundary;

        public CreditCardChargeRule(PurchaseTestInput purchaseTestInput, decimal totalPriceLowerBoundary)
        {
            this.purchaseTestInput = purchaseTestInput;
            this.totalPriceLowerBoundary = totalPriceLowerBoundary;
        }

        public override IRuleResult Eval()
        {
            if (!string.IsNullOrEmpty(this.purchaseTestInput.CreditCardNumber) &&
                !this.purchaseTestInput.IsWiretransfer &&
                !this.purchaseTestInput.IsPromotionalPurchase &&
                this.purchaseTestInput.TotalPrice > this.totalPriceLowerBoundary)
            {
                this.ruleResult.IsSuccess = true;
                return this.ruleResult;
            }
            return new TRuleResult();
        }
    }
}