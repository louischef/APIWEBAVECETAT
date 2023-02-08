using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIWEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIWEB.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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
            var builder = new DbContextOptionsBuilder<TpdevContext>().UseNpgsql("Server=postgresql-laulouis.alwaysdata.net;port=5432;Database=laulouis_seriedb; uid=laulouis; password=AlexBaka74;"); // Chaine de connexion à mettre dans les ( )
            TpdevContext context = new TpdevContext(builder.Options);
            SeriesController controller = new SeriesController(context);
            var result = controller.GetSeries().Result.Value.Where(s => s.Serieid <= 3).ToList();

            List<Serie> listeseriecreer = new List<Serie>();
            listeseriecreer.Add(new Serie(1, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)"));
            listeseriecreer.Add(new Serie(2, "James May's 20th Century", "The world in 1999 would have been unrecognisable to anyone from 1900. James May takes a look at some of the greatest developments of the 20th century, and reveals how they shaped the times we live in now.", 1, 6, 2007, "BBC Two"));
            listeseriecreer.Add(new Serie(3, "True Blood", "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...", 7, 81, 2008, "HBO"));
            CollectionAssert.AreEqual(listeseriecreer, result, "les deux collections ne sont pas égales");
        }
        [TestCleanup]


        [TestMethod()]
        public void GetSerieTest()
        {
            var builder = new DbContextOptionsBuilder<TpdevContext>().UseNpgsql("Server=postgresql-laulouis.alwaysdata.net;port=5432;Database=laulouis_seriedb; uid=laulouis; password=AlexBaka74;"); // Chaine de connexion à mettre dans les ( )
            TpdevContext context = new TpdevContext(builder.Options);
            SeriesController controller = new SeriesController(context);

            var result = controller.GetSerie(1).Result.Value;
            var resultmarchepas = controller.GetSerie(1000).Result.Value;

            Serie listeseriecreer = new Serie(1, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");
            Assert.AreEqual(listeseriecreer, result, "les deux collections ne sont pas egales");
            Assert.AreNotEqual(resultmarchepas, listeseriecreer);
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
            var builder = new DbContextOptionsBuilder<TpdevContext>().UseNpgsql("Server=postgresql-laulouis.alwaysdata.net;port=5432;Database=laulouis_seriedb; uid=laulouis; password=AlexBaka74;"); // Chaine de connexion à mettre dans les ( )
            TpdevContext context = new TpdevContext(builder.Options);
            SeriesController controller = new SeriesController(context);

            var result = controller.DeleteSerie(1).Result;

            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
        }
    }
}