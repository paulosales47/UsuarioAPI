using System.Collections.Generic;

namespace UsuarioAPI.DAO
{
    public interface IDAO<T>
    {
        void Cadastro(T model);

        IList<T> Busca(T model);

    }
}
