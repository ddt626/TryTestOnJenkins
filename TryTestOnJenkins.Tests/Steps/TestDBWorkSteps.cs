using System;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;
using TryTestOnJenkins.Tests.ModelsForTest;

namespace TryTestOnJenkins.Tests.Steps
{
    [Binding]
    [Scope(Feature = "TestDBWork")]
    public class TestDBWorkSteps
    {
        [BeforeScenario()]
        public void BeforeScenario()
        {
            using (var db = new GoosEntitiesForTest())
            {
                var budget = db.Budgets.AsQueryable();
                db.Budgets.RemoveRange(budget);
                db.SaveChanges();
            }
        }

        [When(@"add budget Year ""(.*)"" Amount (.*)")]
        public void WhenAddBudgetYearAmount(string year, int amt)
        {
            using (var db = new GoosEntitiesForTest())
            {
                var newBudget = new Budgets()
                {
                    Amount = amt,
                    YearMonth = year
                };

                db.Budgets.Add(newBudget);
                db.SaveChanges();
            }
        }
        
        [Then(@"the result should be a budget")]
        public void ThenTheResultShouldBeABudget()
        {
            using (var db = new GoosEntitiesForTest())
            {
                var budget = db.Budgets.FirstOrDefault();
                budget.Should().NotBeNull();
            }
        }
    }
}
