using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Classes;

namespace BerlinClock.BDD
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter berlinClock = new TimeConverter();
        private String theTime;
        private String convertedTime;
        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;

            try
            {
                convertedTime = berlinClock.ConvertTime(theTime);
            }
            catch (Exception e)
            {
                ScenarioContext.Current.Add(e.Message, e);
            }
        }

        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(convertedTime, theExpectedBerlinClockOutput);
        }

        [Then(@"we get argument exception")]
        public void ThenWeGetException()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey("Not valid time to convert."));
        }

    }
}
