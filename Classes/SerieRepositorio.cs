using System;
using System.Collections.Generic;
using GRUDCadastroTVSeries.Series.Interfaces;
      
namespace GRUDCadastroTVSeries.Series
{
	    
		//*************************************************************************************
		//  Class Respositorio de Series
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO		
		//*************************************************************************************

	public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listaSerie = new List<Serie>();
		public void Atualiza(int id, Serie objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Serie RetornaPorId(int id)
		{
			return listaSerie[id];
		}
	}
}