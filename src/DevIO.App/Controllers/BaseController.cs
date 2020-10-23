using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.App.Controllers
{
  public abstract class BaseController : Controller
  {
    private readonly INotification _notificador;

    protected BaseController(INotification notificador)
    {
      _notificador = notificador;
    }

    protected bool OperacaoValida()
    {
      return !_notificador.TemNotificacao();
    }
  }
}
