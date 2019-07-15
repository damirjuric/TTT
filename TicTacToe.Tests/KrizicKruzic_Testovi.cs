using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.damir;

namespace TicTacToe.Tests
{
	[TestClass]
	public class KrizicKruzic_Testovi
	{
		/// <summary>
		/// Izvršava pripremu nove igre
		/// </summary>
		[TestMethod]
		public void Test_PripremiNovuIgru()
		{
			var igra = new KrizicKruzic();
			Console.WriteLine(igra.ToString());
		}

		/// <summary>
		/// Priprema novu igru i odigrava jedan potez
		/// </summary>
		[TestMethod]
		public void Test_OdigrajPotez()
		{
			var igra = new KrizicKruzic();
			var moveResult = igra.OdigrajPotez(1, 2);
			Console.WriteLine(igra.ToString());
		}

		/// <summary>
		/// Priprema novu igru i automatski igra igru dok igra na neki način ne završi.
		/// </summary>
		[TestMethod]
		public void Test_AutmatskaIgra()
		{
			// Inicijalizacija nove igre
			var igra = new KrizicKruzic();

			// Inicijalizacija generatora slučajnih brojeva
			var rnd = new Random();

			// Dok igra ne završi, igrači naizmjence rade slučajno generirane poteze
			var stanjeIgre = StanjeIgre.IgraUTijeku;
			var brojacPoteza = 1;
			while (stanjeIgre == StanjeIgre.IgraUTijeku)
			{
				// Dohvatiti slučajnim odabirom neko od praznih polja
				var polje = DohvatiSlucajnoPolje(igra, rnd);
				Console.WriteLine($"Potez broj: {brojacPoteza++}: {igra.IgracNaPotezu} -> ({polje.Redak}, {polje.Stupac})");
				if (polje == null) throw new InvalidOperationException("Nije pronađeno nijedno slobodno polje.");

				// Igrač koji je na potezu postvlja svoju oznaku u odabrano polje 
				var result = igra.OdigrajPotez(polje.Redak, polje.Stupac);

				// Provjera stanja igre
				if (result.State == StanjeIgre.Nerjeseno || result.State == StanjeIgre.Pobjeda)
				{
					// Igra je završila ako je netko pobijedio ili je neriješeno (nema više poteza)
					Console.WriteLine(igra.ToString());
					Console.WriteLine("Igra je završena.");
					if (result.State == StanjeIgre.Nerjeseno)
						Console.WriteLine("» NERIJEŠENO «");
					else if (result.State == StanjeIgre.Pobjeda)
						Console.WriteLine($"» POBJEDNIK JE {result.Winner} «");
					break;
				}
				else
				{
					// Igra se nastavlja ako nema pobjednika i postoje mogući potezi
					Console.WriteLine(igra.ToString());
					Console.WriteLine($"Igra se nastavlja .. na potezu je: {igra.IgracNaPotezu}");
					Console.WriteLine("".PadRight(120, '_'));
				}
			}
		}

		private PoljeKrizicKruzicPloce DohvatiSlucajnoPolje(KrizicKruzic igra, Random rnd)
		{
			var slobodnaPolja = igra.Ploca.Polja.Where(x => !x.Oznaka.HasValue).ToList();
			if (slobodnaPolja.Count == 0) return null;
			return slobodnaPolja[rnd.Next(0, slobodnaPolja.Count)];
		}

	}
}
