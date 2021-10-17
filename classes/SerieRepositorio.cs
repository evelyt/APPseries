using System.Collections.Generic;
using APPseries.interfaces;

namespace APPseries.classes
{
    public class NewBaseType
    {
        public void Atualiza(int id, Series entidade)
        {
            throw new System.NotImplementedException();
        }
        public void Insere(Series entidade)
        {
            throw new System.NotImplementedException();
        }

        public List<Series> Lista()
        {
            throw new System.NotImplementedException();
        }
    }

    public class SerieRepositorio : NewBaseType, IRepositorio<Series>
    {
        public void Exclui(int id)
        {
            throw new System.NotImplementedException();
        }

        public int ProximoId()
        {
            throw new System.NotImplementedException();
        }

        public Series RetornaPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}