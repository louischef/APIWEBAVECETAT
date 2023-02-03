using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIWEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIWEB.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace APIWEB.Controllers.Tests
{
    [TestClass()]
    public class SeriesControllerTests
    {
        
        [TestMethod()]
        public void SeriesControllerTest()
        {
            
        }
        [TestInitialize]
        [TestMethod()]
        public void GetSeriesTest()
        {
            var builder = new DbContextOptionsBuilder<TpdevContext>().UseNpgsql("Server=localhost;port=5432;Database=TPDEV; uid=postgres; password=postgres;"); // Chaine de connexion à mettre dans les ( )
            TpdevContext context = new TpdevContext(builder.Options);
            SeriesController controller = new SeriesController(context);
            var result = controller.GetSeries().Result.Value;

            List<Serie> listeSeriesRecuperees = new List<Serie>();
            //Serie serieExiste = new Serie(1, "AsterixObelix", "Obelix a bu la potion magique", 2, 12, 2015, "AsTCorp");
            listeSeriesRecuperees.Where(s => s.Serieid <= 3).ToList();
        }
        [TestCleanup]


        [TestMethod()]
        public void GetSerieTest()
        {
        }

        [TestMethod()]
        public void PutSerieTest()
        {
        }

        [TestMethod()]
        public void PostSerieTest()
        {
        }

        [TestMethod()]
        public void DeleteSerieTest()
        {
        }
    }
}