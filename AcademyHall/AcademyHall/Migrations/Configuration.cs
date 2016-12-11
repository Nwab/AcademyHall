namespace AcademyHall.Migrations
{
    using AcademyHall.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AcademyHall.DataLink.AcademyHallDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AcademyHall.DataLink.AcademyHallDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var banks = new List<Bank>
            {
                new Bank{ BankName ="DIAMOND BANK PLC", BankCode="063",BankSortCode="063150000"},
                new Bank{ BankName ="GUARANTY TRUST BANK PLC", BankCode="058",BankSortCode="058150000"},
                new Bank{ BankName ="ECOBANK NIGERIA PLC", BankCode="050",BankSortCode="050150000"},
                new Bank{ BankName ="ZENITH BANK PLC", BankCode="057",BankSortCode="057150000"},
                new Bank{ BankName ="WEMA BANK PLC", BankCode="035",BankSortCode="035150000"},
                new Bank{ BankName ="FIRST BANK OF NIGERIA PLC", BankCode="011",BankSortCode="011150000"},
                new Bank{ BankName ="UNION BANK OF NIGERIA PLC", BankCode="032",BankSortCode="032150000"},
                new Bank{ BankName ="UNITED BANK FOR AFRICA PLC'", BankCode="033",BankSortCode="033150000"},
                new Bank{ BankName ="UNITY BANK PLC", BankCode="215",BankSortCode="215150000"},
                new Bank{ BankName ="STANDARD CHARTERED BANK NIGERIA LTD", BankCode="068",BankSortCode="068150000"},
                new Bank{ BankName ="STERLING BANK PLC", BankCode="232",BankSortCode="232150000"},
                new Bank{ BankName ="FIRSTCITY MONUMENT BANK PLC", BankCode="214",BankSortCode="214150000"},
                new Bank{ BankName ="SKYE BANK PLC", BankCode="076",BankSortCode="076150000"},
                new Bank{ BankName ="FIDELITY BANK PLC", BankCode="070",BankSortCode="070150000"},
                new Bank{ BankName ="ACCESS BANK PLC", BankCode="044",BankSortCode="044150000"},
                new Bank{ BankName ="STANBIC  IBTC BANK PLC", BankCode="221",BankSortCode="221150000"}
            };

            banks.ForEach(s => context.Banks.AddOrUpdate(p => p.BankName, s));
            context.SaveChanges();

            var roles = new List<AcademyRole>
            {
                new AcademyRole { Name = "Academic Teacher", RoleDescription="Academic Teacher"},
                new AcademyRole { Name = "Non-Academic Teacher", RoleDescription="Non Academic Teacher"},
                new AcademyRole { Name = "AcademyHallAdmin", RoleDescription="AcademyHallAdmin"},
               
            };

            roles.ForEach(s => context.Roles.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}
