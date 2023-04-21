using System;
using SharedCode.Utils;
using System.Threading.Tasks;
using SharedCode.Models;
using System.Collections.Generic;

namespace SharedCode.Interfaces
{
	public interface IClimateService
	{
        Task<Result<List<ListResponse>>> GetWeatherByCitiName(string cityName);
        Task<Result<byte[]>> GetWeatherImage(string iconId);
    }
}

