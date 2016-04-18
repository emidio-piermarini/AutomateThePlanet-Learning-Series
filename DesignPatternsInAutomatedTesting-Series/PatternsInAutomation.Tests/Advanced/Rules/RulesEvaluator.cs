﻿// <copyright file="RulesEvaluator.cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using System.Linq;
using PatternsInAutomatedTests.Advanced.Rules;

namespace PatternsInAutomatedTests.Advanced.Rules
{
    public class RulesEvaluator
    {
        private readonly List<RulesChain> rules;

        public RulesEvaluator()
        {
            this.rules = new List<RulesChain>();
        }

        public RulesChain Eval(IRule rule)
        {
            var rulesChain = new RulesChain(rule);
            this.rules.Add(rulesChain);
            return rulesChain;
        }

        public void OtherwiseEval(IRule alternativeRule)
        {
            if (this.rules.Count == 0)
            {
                throw new ArgumentException("You cannot add ElseIf clause without If!");
            }
            this.rules.Last().ElseRules.Add(new RulesChain(alternativeRule));
        }

        public void OtherwiseDo(Action otherwiseAction)
        {
            if (this.rules.Count == 0)
            {
                throw new ArgumentException("You cannot add Else clause without If!");
            }
            this.rules.Last().ElseRules.Add(new RulesChain(new NullRule(otherwiseAction), true));
        }

        public void EvaluateRulesChains()
        {
            this.Evaluate(this.rules, false);
        }

        private void Evaluate(List<RulesChain> rulesToBeEvaluated, bool isAlternativeChain = false)
        {
            foreach (var currentRuleChain in rulesToBeEvaluated)
            {
                var currentRulesChainResult = currentRuleChain.Rule.Eval();
                if (currentRulesChainResult.IsSuccess)
                {
                    currentRulesChainResult.Execute();
                    if (isAlternativeChain)
                    {
                        break;
                    }
                }
                else
                {
                    this.Evaluate(currentRuleChain.ElseRules, true);
                }
            }
        }
    }
}