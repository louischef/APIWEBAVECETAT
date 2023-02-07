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

            List<Serie> listeSeriesRecuperees = result.Where(s => s.Serieid <= 3).ToList();
            //Serie serieExiste = new Serie(1, "AsterixObelix", "Obelix a bu la potion magique", 2, 12, 2015, "AsTCorp");

            List<Serie> listeseriecreer = new List<Serie>();
            listeseriecreer.Add(new Serie(1, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)"));
            listeseriecreer.Add(new Serie(2, "James May's 20th Century", "The world in 1999 would have been unrecognisable to anyone from 1900. James May takes a look at some of the greatest developments of the 20th century, and reveals how they shaped the times we live in now.", 1, 6, 2007, "BBC Two"));
            listeseriecreer.Add(new Serie(3, "True Blood", "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...", 7, 81, 2008, "HBO"));
            Assert.AreEqual(listeseriecreer, listeSeriesRecuperees);
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