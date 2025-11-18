using System.Collections.Generic;
using System.Threading.Tasks;
using RentCar.Models;
using RentCar.Models.Entity;
using RentCar.Models.Request;
using RentCar.Models.Response;

namespace RentCar.Service.CarService
{
    public interface ICarService
    {
        Task<(HttpError?, PaginationBaseResponse<CarEntity>)> GetCar(PaginationRequest request);
        Task<(HttpError?, CarEntity)> GetCarById(int id);
        Task<(HttpError?, CarEntity)> PostCar(CarRequest request);
        Task<(HttpError?, CarEntity)> PatchCar(int id, Dictionary<string, object> updates);
        Task<HttpError?> DeleteCar(int id);
        Task<(HttpError?, CarEntity)> PutCar(int id, CarRequest product);
    }
}