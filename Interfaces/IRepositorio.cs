using System.Collections.Generic;

namespace GRUDCadastroTVSeries.Series.Interfaces {
		//*************************************************************************************
		//  Repositoro Entidade Base
		//  Autor: Vagner Renato Bellacosa
		//  Data : 27/05/2021
		//  Local: Itatiba Bootcamp .Net Fundamentals
		//  Baseado no codigo original da DIO
		//*************************************************************************************

    public interface IRepositorio<T> {
        List<T> Lista();
        T RetornaPorId(int id);        
        void Insere(T entidade);        
        void Exclui(int id);        
        void Atualiza(int id, T entidade);
        int ProximoId();
    }

}