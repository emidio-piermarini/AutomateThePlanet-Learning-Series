﻿// <copyright file="AdvancedBingTests.cs" company="Automate The Planet Ltd.">
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternsInAutomatedTests.Advanced.Core;
using P = PatternsInAutomatedTests.Advanced.BingMainPage;

namespace PatternsInAutomatedTests.Advanced
{
    [TestClass]
    public class AdvancedBingTests
    {       
        [TestInitialize]
        public void SetupTest()
        {
            Driver.StartBrowser();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            Driver.StopBrowser();
        }

        [TestMethod]
        public void SearchTextInBing_Advanced_PageObjectPattern()
        {
            P.BingMainPage bingMainPage = new P.BingMainPage();
            bingMainPage.Navigate();
            bingMainPage.Search("Automate The Planet");
            bingMainPage.Validate().ResultsCount(",000 RESULTS");
        }
    }
}