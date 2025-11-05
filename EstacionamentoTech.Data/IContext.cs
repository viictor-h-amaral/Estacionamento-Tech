using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoTech.Data.Utilidades;
using EstacionamentoTech.Models;
using EstacionamentoTech.Models.Tabelas;

namespace EstacionamentoTech.Data
{
    public interface IContext
    {
        IEnumerable<T> GetMany<T>(ITabela tabela, string? criterioWhere = null) where T : class, IEntityModel;
        T? GetOneOrNull<T>(ITabela tabela, string? criterioWhere = null) where T : class, IEntityModel;
        T? GetOneOrNull<T>(ITabela tabela, CriterioSelecao criterio) where T : class, IEntityModel;
        T GetOne<T>(ITabela tabela, string? criterioWhere = null) where T : class, IEntityModel;
        T GetOne<T>(ITabela tabela, CriterioSelecao criterio) where T : class, IEntityModel;
        bool Exists(ITabela tabela, CriterioSelecao criterio);
        IEnumerable<T> GetManyComPaginacao<T>(ITabela tabela, int offSet = 0, int limit = 10, 
                                            CriterioSelecao? criterioSelecao = null) where T : class, IEntityModel;
        int Count<T>(ITabela tabela, CriterioSelecao? criterioSelecao = null) where T : class, IEntityModel;
        bool Delete<T>(ITabela tabela, T registro) where T : class, IEntityModel;
        bool TemDependencias<T>(T registro, ITabela tabelaDependencia, string colunaFk) where T : class, IEntityModel;
        void Insert(ITabela tabela, IEntityModel registro);
        void Update(ITabela tabela, IEntityModel registro);
    }
}
