using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LibrarySystem.Models;

namespace LibrarySystem.DAL
{
    public class LibraryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            var consumers = new List<Consumer>
            {
                new Consumer{FirstName="Chris",LastName = "Flores"},
                new Consumer{FirstName="Harkaran",LastName="Grewal"},
                new Consumer{FirstName="Amin",LastName="Hassan"},
                new Consumer{FirstName="Yi",LastName="Weng"},
                new Consumer{FirstName="Sebastian",LastName="Baba"},
                new Consumer{FirstName="Christine",LastName="Co"},
                new Consumer{FirstName="Armando",LastName="Montoya"},
            };
            consumers.ForEach(s => context.Consumers.Add(s));
            context.SaveChanges();
            var inventories = new List<Inventory>
            {
                new Inventory{BookID=0001,BookTitle="MVC Totorial #1",Price="$49.99"},
                new Inventory{BookID=0002,BookTitle="MVC Totorial #2",Price="$69.99"},
                new Inventory{BookID=0003,BookTitle="MVC Totorial #3",Price="$89.99"},
                new Inventory{BookID=0004,BookTitle="MVC Totorial #4",Price="$99.99"},
                new Inventory{BookID=0005,BookTitle="MVC Totorial #5",Price="$109.99"},
                new Inventory{BookID=0006,BookTitle="MVC Totorial #6",Price="$119.99"},
            };
            inventories.ForEach(s => context.Inventories.Add(s));
            context.SaveChanges();
            var transactions = new List<Transaction>
            {
                new Transaction{ConsumerID=1,BookID=0001,SuccessOrFail=SuccessOrFail.S},
                new Transaction{ConsumerID=2, BookID=0002,SuccessOrFail=SuccessOrFail.S},
                new Transaction{ConsumerID=3, BookID=0002,SuccessOrFail=SuccessOrFail.S},
                new Transaction{ConsumerID=4, BookID=0004,SuccessOrFail=SuccessOrFail.S},
                new Transaction{ConsumerID=5, BookID=0004,SuccessOrFail=SuccessOrFail.F},
            };
            transactions.ForEach(s => context.Transactions.Add(s));
            context.SaveChanges();
        }
    }
}