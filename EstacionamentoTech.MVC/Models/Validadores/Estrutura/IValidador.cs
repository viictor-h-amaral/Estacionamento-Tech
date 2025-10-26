using EstacionamentoTech.Models;

namespace EstacionamentoTech.MVC.Models.Validadores.Estrutura
{
    internal interface IValidador<T> where T : IEntityModel
    {
        MensagemValidacao? ValidarNoDelete(T entidade);
        MensagemValidacao? ValidarNoCriar(T entidade);
        MensagemValidacao? ValidarNoEditar(T entidade);
    };
}
