using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.damir
{
	/// <summary>
	/// "Motor" igre. Imeplemntira metode (funkcije) u terminologiji igre.
	/// Npr. PlayMove: Izvršava zadani potez u igri i provjerava stanje igre (je li netko pobijedio, ima li još poteza, ...)
	/// </summary>
	public class KrizicKruzic
	{
		private Random _rnd = new Random();

		/// <summary>
		/// Konstruktor. Odmah kod kreiranja, priprema se nove igra.
		/// </summary>
		public KrizicKruzic()
		{
			PripremiNovuIgru();
		}

		/// <summary>
		/// Ploča na kojoj se igra
		/// </summary>
		public KrizicKruzicPloca Ploca { get; private set; }

		/// <summary>
		/// Igrači koji sudjeluju u igri
		/// </summary>
		public List<Igrac> Igraci { get; private set; }

		/// <summary>
		/// Igrač koji je trenutno na potezu
		/// </summary>
		public Igrac IgracNaPotezu { get; private set; }


		/// <summary>
		/// Priprema nove igre.
		/// </summary>
		public void PripremiNovuIgru()
		{
			// Kreira se nova (prazna) ploča
			Ploca = new KrizicKruzicPloca();
			// Kreiraju se i u igru dodaju igrači
			Igraci = new List<Igrac>
			{
				new Igrac("Igrač X", Oznaka.X),
				new Igrac("Igrač O", Oznaka.O)
			};
			// Slučajnim odabirom odabire se igrač koji igra prvi
			IgracNaPotezu = Igraci[_rnd.Next(0, 2)];
		}

		/// <summary>
		/// Izvršava potez igre
		/// </summary>
		/// <param name="redak">Koordinata polja .. redak</param>
		/// <param name="stupac">Koordinata polja .. supac</param>
		/// <returns>Vraća stanje igre i pobjednika ako postoji.</returns>
		public (StanjeIgre State, Igrac Winner) OdigrajPotez(int redak, int stupac)
		{
			var stanje = Ploca.ProvjeriStanjeIgre();
			if (stanje.State == StanjeIgre.IgraUTijeku)
			{
				Ploca.OznaciPolje(redak, stupac, IgracNaPotezu.Oznaka);
				PostaviSlijedecegIgracaNaPotezu();
				var novoStanje = Ploca.ProvjeriStanjeIgre();
				return (novoStanje.State, Igraci.FirstOrDefault(igrac => igrac.Oznaka == novoStanje.Pobjednik));
			}
			else throw new InvalidOperationException("Igra je završena. Započnite novu igru.");
		}

		/// <summary>
		/// Postavljanje slijedećeg igrača koji je na potezu
		/// </summary>
		private void PostaviSlijedecegIgracaNaPotezu()
		{
			var trenutniIgrac = IgracNaPotezu ?? Igraci[_rnd.Next(0, 2)];
			var slijdedeciIgracOznaka = (Oznaka)(((int)trenutniIgrac.Oznaka + 1) % 2);
			IgracNaPotezu = Igraci.FirstOrDefault(igrac => igrac.Oznaka == slijdedeciIgracOznaka);
			if (IgracNaPotezu == null) throw new InvalidOperationException("Nije uspjelo postavljanje slijedećeg igrača.");
		}


		/// <summary>
		/// Prikaz stanja ploče koristeći znakove (slova, brojke, ...)
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Ploca.ToString();
		}

	}

	/// <summary>
	/// "Ploča" za igru. Definira prostor igre ("ploču") i implementira pravila igre.
	/// </summary>
	public class KrizicKruzicPloca
	{
		public KrizicKruzicPloca()
		{
			Redaka = 3;
			Stupaca = 3;
		}

		/// <summary>
		/// Broj redaka na ploči
		/// </summary>
		public int Redaka { get; }

		/// <summary>
		/// Broj stupaca na ploči
		/// </summary>
		public int Stupaca { get; }

		private List<PoljeKrizicKruzicPloce> _polja = null;
		/// <summary>
		/// Polja koja su sadržana na ploči
		/// </summary>
		public List<PoljeKrizicKruzicPloce> Polja
		{
			get
			{
				if (_polja == null) Inicijaliziraj();
				return _polja;
			}
		}

		/// <summary>
		/// Dohvaća polje ploče za zadani redak i supac
		/// </summary>
		/// <param name="redak">Redak ploče</param>
		/// <param name="stupac">Stupac ploče</param>
		/// <returns>Polje ploče na zadanom mjestu ili null ako na zadanom mjestu ne postoji polje.</returns>
		public PoljeKrizicKruzicPloce Polje(int redak, int stupac)
		{
			return Polja.FirstOrDefault(tile => tile.Redak == redak && tile.Stupac == stupac);
		}

		/// <summary>
		/// Postavlja zadanu oznaku na zadano polje ploče. 
		/// Uzrokuje pogrešku ako zadano polje već ima postavljenu oznaku.
		/// </summary>
		/// <param name="redak">Redak polja</param>
		/// <param name="stupac">Stupac polja</param>
		/// <param name="oznaka">Oznaka koju treba postaviti u polje</param>
		public void OznaciPolje(int redak, int stupac, Oznaka? oznaka)
		{
			var polje = Polje(redak, stupac);
			if (polje.Oznaka.HasValue) throw new Exception("Zadano polje je već označeno. Odaberite drugo polje.");
			polje.Oznaka = oznaka;
		}

		/// <summary>
		/// Provjera stanja igre i uvjeta za pobjedu
		/// </summary>
		/// <returns>Stanje igre i pobjednika ako pobjednik postoji.</returns>
		public (StanjeIgre State, Oznaka? Pobjednik) ProvjeriStanjeIgre()
		{
			var pobjednik = PronadjiPobjednika();
			if (pobjednik != null) return (StanjeIgre.Pobjeda, pobjednik);
			else
			{
				if (Polja.All(tile => tile.Oznaka.HasValue)) return (StanjeIgre.Nerjeseno, null);
			}
			return (StanjeIgre.IgraUTijeku, null);
		}

		/// <summary>
		/// Provjera da li postoji pobjednik i ako postoji, određivanje koja oznaka nosi pobjedu.
		/// </summary>
		/// <returns>Oznaka koja pobjeđuje ili null ako nema pobjednika</returns>
		private Oznaka? PronadjiPobjednika()
		{
			// Priovjeriti sve uvjete pobjede:
			// 1. Provjeriri da li je neki igrač popunio sva polja u nekom retku. Ako jeste vratiti tog igrača.
			for (int redak = 0; redak < Redaka; redak++)
			{
				var redakValues = Polja.Where(polje => polje.Redak == redak).Select(polje => polje.Oznaka).Distinct().ToList();
				if (redakValues.Count == 1 && (redakValues[0] == Oznaka.X || redakValues[0] == Oznaka.O))
					return redakValues[0];
			}
			// 2. Provjeriti da li je neki igrač popunio sva polja u nekom stupcu. Ako jeste vratiti tog igrača.
			for (int stupac = 0; stupac < Stupaca; stupac++)
			{
				var stupacValues = Polja.Where(polje => polje.Stupac == stupac).Select(polje => polje.Oznaka).Distinct().ToList();
				if (stupacValues.Count == 1 && (stupacValues[0] == Oznaka.X || stupacValues[0] == Oznaka.O))
					return stupacValues[0];
			}
			// 3. Provjeriti da li je naki igrač popunio sva polja po nekoj od dijagonala. Ako jeste vratiti tog igrača.

			// Dijagonala (0,0), (1,1), (2,2)
			var diagonalValues1 = Polja.Where(polje => polje.Redak == polje.Stupac).Select(polje => polje.Oznaka).Distinct().ToList();
			if (diagonalValues1.Count == 1 && (diagonalValues1[0] == Oznaka.X || diagonalValues1[0] == Oznaka.O))
				return diagonalValues1[0];
			// Dijagonala (0,2), (1,1), (2,0)
			var diagonalValues2 = Polja.Where(polje => polje.Redak == Redaka - 1 - polje.Stupac).Select(polje => polje.Oznaka).Distinct().ToList();
			if (diagonalValues2.Count == 1 && (diagonalValues2[0] == Oznaka.X || diagonalValues2[0] == Oznaka.O))
				return diagonalValues2[0];

			return null; // Nema pobjednika
		}

		/// <summary>
		/// Inicijalizacija ploče
		/// </summary>
		private void Inicijaliziraj()
		{
			// Kreiranje liste polja ploče
			_polja = new List<PoljeKrizicKruzicPloce>();

			for (int redak = 0; redak < Redaka; redak++)
			{
				for (int stupac = 0; stupac < Stupaca; stupac++)
				{
					// Za svaku lokalciju (redak, stupac) kreirati novu instancu 
					// klase polja i dodati je u listu
					_polja.Add(new PoljeKrizicKruzicPloce(redak, stupac, null));
				}
			}
		}

		/// <summary>
		/// Grafička reprezentacija ploče koristeći niz znakova (string)
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			var s = "";
			for (int row = 0; row < Redaka; row++)
			{
				for (int col = 0; col < Redaka; col++)
				{
					s += $"| {Polje(row, col).ToString()} ";
				}
				s += "|" + Environment.NewLine;
			}
			return s;
		}

	}

	/// <summary>
	/// Element ploče za igru
	/// </summary>
	public class PoljeKrizicKruzicPloce
	{

		/// <summary>
		/// Konstruktor. Kreiranje polja ploče.
		/// </summary>
		/// <param name="redak">Redak polja na ploči</param>
		/// <param name="stupac">Stupac polja na ploči.</param>
		/// <param name="oznaka">Oznaka pšostavljena u polje.</param>
		public PoljeKrizicKruzicPloce(int redak, int stupac, Oznaka? oznaka)
		{
			Redak = redak;
			Stupac = stupac;
			Oznaka = oznaka;
		}

		/// <summary>
		/// Redak polja na ploči
		/// </summary>
		public int Redak { get; private set; }

		/// <summary>
		/// Stupac polja na ploči
		/// </summary>
		public int Stupac { get; private set; }

		/// <summary>
		/// Oznaka polja (ili null ako nema oznake)
		/// </summary>
		public Oznaka? Oznaka { get; set; }

		/// <summary>
		/// String reprezentacija polja
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Oznaka?.ToString() ?? " ";
		}

	}

	/// <summary>
	/// Igrač koji sudjeluje u igri
	/// </summary>
	public class Igrac
	{
		/// <summary>
		/// Konstruktor. Kreiranje igrača.
		/// </summary>
		/// <param name="naziv">Naziv igrača</param>
		/// <param name="oznaka">Oznaka koju igrač koristi.</param>
		public Igrac(string naziv, Oznaka oznaka)
		{
			Naziv = naziv;
			Oznaka = oznaka;
		}

		/// <summary>
		/// Naziv igrača
		/// </summary>
		public string Naziv { get; set; }
		/// <summary>
		/// Oznaka igrača
		/// </summary>
		public Oznaka Oznaka { get; private set; }

		/// <summary>
		/// Reprezentacija igrača u string obliku
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Naziv;
		}
	}

	/// <summary>
	/// Enumeracija oznaka kojima se mogu označiti polja ploče
	/// </summary>
	public enum Oznaka : int
	{
		X = 0,
		O = 1
	}

	/// <summary>
	/// Enumeracija mogućih stanja igre
	/// </summary>
	public enum StanjeIgre
	{
		IgraUTijeku,
		Pobjeda,
		Nerjeseno
	}
}
