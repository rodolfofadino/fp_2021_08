using Fiap.Domain.Models;
using System.Collections.Generic;

namespace Fiap.Application.Interfaces
{
    public interface INoticiaService
    {
        List<Noticia> Load(int totalDeNoticias);
    }
}