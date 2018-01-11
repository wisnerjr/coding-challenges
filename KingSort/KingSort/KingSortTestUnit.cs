using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KingSort
{
    [TestClass]
    public class KingSortTestUnit
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void TesteUm_DevePassar()
        {
            KingSort kingSort = new KingSort();
            string[] kings = new string[] { "Philippe VI", "Jean II", "Charles V", "Charles VI", "Charles VII", "Louis XI" };
            string resultadoCorreto = "Charles V, Charles VI, Charles VII, Jean II, Louis XI, Philippe VI";

            var list = kingSort.getSortedList(kings);

            string resultado = string.Empty;

            foreach (var l in list)
            {
                resultado += String.Concat(l, ", ");
            }

            resultado = resultado.Substring(0, resultado.Length - 2);

            Assert.AreEqual(resultado, resultadoCorreto);
        }

        [TestMethod]
        public void TesteDois_DevePassar()
        {
            KingSort kingSort = new KingSort();
            string[] kings = new string[] { "A XLIX", "A XLI", "A XLII", "A XLIV", "A XLIII", "A XLV", "A XLVI", "A XLVII", "A XLVIII" };
            string resultadoCorreto = "A XLI, A XLII, A XLIII, A XLIV, A XLV, A XLVI, A XLVII, A XLVIII, A XLIX";



            var list = kingSort.getSortedList(kings);

            string resultado = string.Empty;

            foreach (var l in list)
            {
                resultado += String.Concat(l, ", ");
            }

            resultado = resultado.Substring(0, resultado.Length - 2);

            Assert.AreEqual(resultado, resultadoCorreto);
        }

        [TestMethod]
        public void TesteTres_DeveFalhar()
        {
            KingSort kingSort = new KingSort();
            string[] kings = new string[] { "Rom XLII", "Rom XLIII" };
            string resultadoErrado = "Rom XLIII, Rom XLII";

            //Resultado Correto = "Rom XLII, Rom XLIII"

            var list = kingSort.getSortedList(kings);

            string resultado = string.Empty;

            foreach (var l in list)
            {
                resultado += String.Concat(l, ", ");
            }

            resultado = resultado.Substring(0, resultado.Length - 2);

            Assert.AreNotEqual(resultado, resultadoErrado);
        }

        [TestMethod]
        public void TesteQuatro_DeveFalhar()
        {
            KingSort kingSort = new KingSort();
            string[] kings = new string[] { "Louis IX", "Philippe II", "Phillippe XXX", "Phillippe XXXI", "Phillippe XXXII" };
            string resultadoErrado = "Phillippe XXX, Louis IX, Philippe II, Phillippe XXXII, Phillippe XXXI";

            //Resultado Correto = "Louis IX, Philippe II, Phillippe XXX, Phillippe XXXI, Phillippe XXXII"

            var list = kingSort.getSortedList(kings);

            string resultado = string.Empty;

            foreach (var l in list)
            {
                resultado += String.Concat(l, ", ");
            }

            resultado = resultado.Substring(0, resultado.Length - 2);

            Assert.AreNotEqual(resultado, resultadoErrado);
        }
        
        // todos reis tem o mesmo nome e contém todos os algarismos romanos de 1 a 50
        [TestMethod]
        public void TesteCinco_DevePassar()
        {
            KingSort kingSort = new KingSort();
            string[] kings = new string[] { "Carlos XXI", "Carlos IX", "Carlos XLIX", "Carlos XLIV", "Carlos XXXV", "Carlos XXIX", "Carlos XXXIII", "Carlos XXVI", "Carlos XIII", "Carlos XLVIII", "Carlos XL", "Carlos XXXVIII", "Carlos XI", "Carlos XXIII", "Carlos XXXVII", "Carlos XXVIII", "Carlos XXV", "Carlos XXX", "Carlos XLII", "Carlos XVIII", "Carlos III", "Carlos XV", "Carlos VIII", "Carlos XXIV", "Carlos XLVI", "Carlos II", "Carlos XIV", "Carlos VI", "Carlos L", "Carlos I", "Carlos XXXIX", "Carlos XLVII", "Carlos XXXVI", "Carlos XXVII", "Carlos XX", "Carlos XXII", "Carlos XIX", "Carlos XII", "Carlos XXXIV", "Carlos XVII", "Carlos XVI", "Carlos XXXII", "Carlos X", "Carlos V", "Carlos XXXI", "Carlos IV", "Carlos XLIII", "Carlos XLI", "Carlos XLV", "Carlos VII" };
            string resultadoCorreto = "Carlos I, Carlos II, Carlos III, Carlos IV, Carlos V, Carlos VI, Carlos VII, Carlos VIII, Carlos IX, Carlos X, Carlos XI, Carlos XII, Carlos XIII, Carlos XIV, Carlos XV, Carlos XVI, Carlos XVII, Carlos XVIII, Carlos XIX, Carlos XX, Carlos XXI, Carlos XXII, Carlos XXIII, Carlos XXIV, Carlos XXV, Carlos XXVI, Carlos XXVII, Carlos XXVIII, Carlos XXIX, Carlos XXX, Carlos XXXI, Carlos XXXII, Carlos XXXIII, Carlos XXXIV, Carlos XXXV, Carlos XXXVI, Carlos XXXVII, Carlos XXXVIII, Carlos XXXIX, Carlos XL, Carlos XLI, Carlos XLII, Carlos XLIII, Carlos XLIV, Carlos XLV, Carlos XLVI, Carlos XLVII, Carlos XLVIII, Carlos XLIX, Carlos L";

            var list = kingSort.getSortedList(kings);

            string resultado = string.Empty;

            foreach (var l in list)
            {
                resultado += String.Concat(l, ", ");
            }

            resultado = resultado.Substring(0, resultado.Length - 2);

            Assert.AreEqual(resultado, resultadoCorreto);
        }
    }
}
