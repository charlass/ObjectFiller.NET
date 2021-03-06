﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectFiller.FillerPlugins;
using ObjectFiller.FillerPlugins.String;
using ObjectFiller.Test.TestPoco.Person;

namespace ObjectFiller.Test
{
    [TestClass]
    public class ObjectFillerTest
    {
        [TestMethod]
        public void TestFillPerson()
        {
            Person p = new Person();
            ObjectFiller<Person> objectFiller = new ObjectFiller<Person>(p);
            objectFiller.Setup()
                .RegisterInterface<IAddress, Address>()
                .RandomizerForType(new MnemonicStringPlugin(10))
                .RandomizerForProperty(new MnemonicStringPlugin(1), person => person.FirstName)
                .RandomizerForProperty(new RandomListItem<string>(new List<string>() { "Maik", "Tom", "Anton" }), person => person.LastName)
                .RandomizerForProperty(() => new Random().Next(12, 83), person => person.Age)
                .SetupFor<Address>()
                .IgnoreProperties(a => a.City, a => a.Country);



            Person pFilled = objectFiller.Fill();


        }
    }
}
