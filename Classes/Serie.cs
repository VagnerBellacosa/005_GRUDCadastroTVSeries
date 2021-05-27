using System;

namespace GRUDCadastroTVSeries.Series  {

    public class Serie : EntidadeBase {
		//*************************************************************************************
		//  Class Serie Entidade Base
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO
		//*************************************************************************************

        // Atributos
		private Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Serie(int id, Genero genero, string titulo, string descricao, int ano)		{
		//*************************************************************************************
		//  Serie atributos
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO
		//*************************************************************************************
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override string ToString()		{
		//*************************************************************************************
		//  Inicializa retorno
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO
		//*************************************************************************************


			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo() {
			return this.Titulo;
		}

		public int retornaId(){
			return this.Id;
		}

        public bool retornaExcluido()		{
			return this.Excluido;
		}
		
        public void Excluir() {
            this.Excluido = true;
        }

    }

}