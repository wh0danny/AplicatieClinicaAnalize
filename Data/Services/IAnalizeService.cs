using AplicatieClinicaAnalize.Data.Base;
using AplicatieClinicaAnalize.Data.ViewModels;
using AplicatieClinicaAnalize.Models;

namespace AplicatieClinicaAnalize.Data.Services
{
    public interface IAnalizeService:IEntityBaseRepository<Analiza>
    {
        Analiza GetAnalizaById(int id);
        AnalizaNouaDropdownsVM GetAnalizaNouaDropdownsValues();
        Analiza AdaugaAnalizaNoua(AnalizaNouaVM data);
        Analiza EditeazaAnalizaNoua(AnalizaNouaVM data);

    }
}
