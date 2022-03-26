using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskApi.Entities;


namespace HelpDeskApi
{   
    public class HelpDeskSeeder
    {
        private readonly HelpDeskDbContext _dbContext;

        public HelpDeskSeeder(HelpDeskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }


                if (!_dbContext.Clients.Any())
                {
                    var clients = GetClients();
                    _dbContext.Clients.AddRange(clients);
                    _dbContext.SaveChanges();

                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name="HelpDesk"
                },
                new Role()
                {
                    Name="HelpDeskSenior"
                },
                new Role()
                {
                    Name="HelpDeskMenager"
                },
                new Role()
                {
                    Name="Admin"
                }

            };
            return roles;

            
            
        }


        private IEnumerable<Client> GetClients()
        {
        var clients = new List<Client>()
        {
        new Client()
        {
            Name = "TestSklep",
            ServiceMenager = "Service Menager test",
            Description = "TestSklep Description",
            Contrac = true,
            ProblemPlaces = new List<ProblemPlace>()
                {
                    new ProblemPlace()
                    {
                        Name="PP Test1",
                        Description = "PP Test1 Description ",
                        ProblemsCategory =new List<ProblemCategory>()
                        {
                            new ProblemCategory()
                            {
                                Name="PC Test1.1",
                                Description = "wszytsko co dotyczy stanowiska kasowego i jest pod naszym serwisem",

                                Problem =new List<Problem>()
                                    {
                                        new Problem()
                                        {
                                            Name="Zacięta skanerowaga",
                                            Description = "wszytsko co dotyczy stanowiska kasowego i jest pod naszym serwisem",
                                            UnderService =true,
                                            ProblemSolution = new List<ProblemSolution>
                                            {
                                                new ProblemSolution
                                                {
                                                    Name="ProblemSolution",
                                                    Step1="blabla bla bla",
                                                    Note1 ="Zrobiłe bla bla bla",
                                                    Step2="bla22bla22 bla b2la",
                                                    Note2 ="Zro2b122łe b2la 22bla bla"

                                                },
                                                new ProblemSolution
                                                {
                                                    Name="Podniesienie skanerowagi  ",
                                                    Step1="blabla bla bla",
                                                    Note1 ="Zrobiłe bla bla bla",
                                                    Step2="bla22bla22 bla b2la",
                                                    Note2 ="Zro2b122łe b2la 22bla bla"

                                                }

                                            }
                                        },
                                        new Problem()
                                        {
                                            Name="nie działa Pin pad",
                                            Description = "wszytsko co dotyczy stanowiska kasowego i jest pod naszym serwisem",
                                            UnderService =true,
                                            ProblemSolution = new List<ProblemSolution>
                                            {
                                                new ProblemSolution
                                                {
                                                    Name="Zglosić do e servivr",
                                                    Step1="blabla bla bla",
                                                    Note1 ="Zrobiłe bla bla bla",
                                                    Step2="bla22bla22 bla b2la",
                                                    Note2 ="Zro2b122łe b2la 22bla bla"

                                                },
                                                new ProblemSolution
                                                {
                                                    Name="Podniesienie skanerowagi  ",
                                                    Step1="blabla bla bla",
                                                    Note1 ="Zrobiłe bla bla bla",
                                                    Step2="bla22bla22 bla b2la",
                                                    Note2 ="Zro2b122łe b2la 22bla bla"

                                                }

                                            }
                                        },


                                        }


                             }
                         }


                     },
                    new ProblemPlace()
                    {
                        Name="PP Test2",
                        Description = "PP Test2 Description",
                        ProblemsCategory =new List<ProblemCategory>()
                        {
                            new ProblemCategory()
                            {
                                Name="Reinstalca kasy",
                                Description = "wszytsko co dotyczy stanowiska kasowego i jest pod naszym serwisem",

                                Problem =new List<Problem>()
                                    {
                                        new Problem()
                                        {
                                            Name="Puszczenie reinstalacji",
                                            Description = "wszytsko co dotyczy stanowiska kasowego i jest pod naszym serwisem",
                                            UnderService =true,
                                            ProblemSolution = new List<ProblemSolution>
                                            {
                                                new ProblemSolution
                                                {
                                                    Name="reinstalowanie kasy",
                                                    Step1="blabla bla bla",
                                                    Note1 ="Zrobiłe bla bla bla",
                                                    Step2="bla22bla22 bla b2la",
                                                    Note2 ="Zro2b122łe b2la 22bla bla"

                                                }


                                            }
                                        }



                                    }


                             }

                        }

                    }


                }
        }
        };
        return clients;
    }
        

            


        }

    

}
