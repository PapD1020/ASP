using EszkozNyilvantartoApi.Models;
using EszkozNyilvantartoApi.Services;
using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly eszkoz_nyilvantartoContext context;

        private readonly CoworkerService coworkerService;

        public UnitTest1(eszkoz_nyilvantartoContext context, CoworkerService coworkerService)
        {
            this.context = new eszkoz_nyilvantartoContext();
            this.coworkerService = new CoworkerService(context);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
