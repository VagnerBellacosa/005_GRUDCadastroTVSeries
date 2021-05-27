using System;
using System.Collections.Generic;
using System.Threading;

namespace GRUDCadastroTVSeries.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)        {

           string Abertura = TelaAbertura();

           string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")			{

				switch (opcaoUsuario)				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("______________________________________");
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
			Console.WriteLine(" ");
			Console.WriteLine("(c)2021 Bellacosa Adventures ");			
        }

        private static void ExcluirSerie()		{
		//*************************************************************************************
		//  Excluir Serie do Cadastro
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO
		//*************************************************************************************

			Console.Write("Digite o id da série: ");
			
			int indiceSerie = int.Parse(Console.ReadLine());
            			
			string Ax_Confirma =  " " ;

			while (Ax_Confirma.ToUpper() != "Y" && 
			       Ax_Confirma.ToUpper() != "N"  ) {
				
	     	   Console.WriteLine(" ");
		       Console.Write("Confirma exclusao [Y]es [N]o: ");

			   Ax_Confirma = Console.ReadLine();            

			   if (Ax_Confirma == "Y")  {
			      repositorio.Exclui(indiceSerie);
			   }
			}
		}

        private static void VisualizarSerie()		{
		//*************************************************************************************
		//  Visualizar serie
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO
		//*************************************************************************************

			Console.Write("Digite o id da série: ");

			int indiceSerie = int.Parse(Console.ReadLine());

			Console.WriteLine(" ");

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()		{
		//*************************************************************************************
		//  Atualizar Serie
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO
		//*************************************************************************************

			Console.Write("Digite o id da série: ");
			
			int indiceSerie = int.Parse(Console.ReadLine());

			Console.WriteLine(" ");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

        private static void ListarSeries()		{
		//*************************************************************************************
		//  Listar Series
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO
		//*************************************************************************************

			Console.WriteLine("Listar séries");
			Console.WriteLine(" ");

			var lista = repositorio.Lista();

			if (lista.Count == 0)			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()		{
		//*************************************************************************************
		//  Inserir Serie
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO
		//*************************************************************************************

			Console.WriteLine("Inserir nova série");
			Console.WriteLine(" ");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()		{
		//*************************************************************************************
		//  Menu Principal Series
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO
		//*************************************************************************************

			Console.WriteLine();
			Console.WriteLine("______________________________________");			
			Console.WriteLine("Bellacosa Séries a seu dispor!!!");
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine(" ");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine(" ");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static string TelaAbertura()		{
		//*************************************************************************************
		//  Tela Abertura
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO
		//*************************************************************************************
		    Console.Clear();
			Console.WriteLine();
			Console.WriteLine("███████████████████████████");
			Console.WriteLine("███████▀▀▀░░░░░░░▀▀▀███████");
			Console.WriteLine("████▀░░░░░░░░░░░░░░░░░▀████");
			Console.WriteLine("███│░░░░░░░░░░░░░░░░░░░│███");
			Console.WriteLine("██▌│░░░░░░░░░░░░░░░░░░░│▐██");
			Console.WriteLine("██░└┐░░░░░░░░░░░░░░░░░┌┘░██");
			Console.WriteLine("██░░└┐░░░░░░░░░░░░░░░┌┘░░██");
			Console.WriteLine("██░░┌┘▄▄▄▄▄░░░░░▄▄▄▄▄└┐░░██");
			Console.WriteLine("██▌░│██████▌░░░▐██████│░▐██");
			Console.WriteLine("███░│▐███▀▀░░▄░░▀▀███▌│░███");
			Console.WriteLine("██▀─┘░░░░░░░▐█▌░░░░░░░└─▀██");
			Console.WriteLine("██▄░░░▄▄▄▓░░▀█▀░░▓▄▄▄░░░▄██");
			Console.WriteLine("████▄─┘██▌░░░░░░░▐██└─▄████");
			Console.WriteLine("█████░░▐█─┬┬┬┬┬┬┬─█▌░░█████");
			Console.WriteLine("████▌░░░▀┬┼┼┼┼┼┼┼┬▀░░░▐████");
			Console.WriteLine("█████▄░░░└┴┴┴┴┴┴┴┘░░░▄█████");
			Console.WriteLine("███████▄░░░░░░░░░░░▄███████");
			Console.WriteLine("██████████▄▄▄▄▄▄▄██████████");
			Console.WriteLine("███████████████████████████");
			Console.WriteLine(" ");
			Console.WriteLine("Bellacosa Séries a seu dispor!!!");
			Console.WriteLine("     < Press Enter > ");
			Console.WriteLine(" ");
			Console.WriteLine(" ");
			Console.WriteLine("(c)2021 Bellacosa Adventures ");

			string Abertura = Console.ReadLine().ToUpper();

			Console.WriteLine();

			Thread.Sleep(5000);

			return Abertura;
		}

    }

}
