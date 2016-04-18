﻿// <copyright file="BasePageSingletonDerived.cs" company="Automate The Planet Ltd.">
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
using PatternsInAutomatedTests.Advanced.Base;

namespace PatternsInAutomatedTests.Advanced.Core
{
    public abstract class BasePageSingletonDerived<S, M> : ThreadSafeNestedContructorsBaseSingleton<S>
        where M : BasePageElementMap, new()
        where S : BasePageSingletonDerived<S, M>
    {
        public BasePageSingletonDerived()
        {
        }

        protected M Map
        {
            get
            {
                return new M();
            }
        }

        public virtual void Navigate(string url = "")
        {
            Driver.Browser.Navigate().GoToUrl(string.Concat(url));
        }
    }

    public abstract class BasePageSingletonDerived<S, M, V> : BasePageSingletonDerived<S, M>
        where M : BasePageElementMap, new()
        where V : BasePageValidator<M>, new()
        where S : BasePageSingletonDerived<S, M, V>
    {
        public V Validate()
        {
            return new V();
        }
    }
}