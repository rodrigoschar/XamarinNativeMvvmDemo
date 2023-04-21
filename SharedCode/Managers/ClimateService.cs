using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.DependencyInjection;
using SharedCode.Interfaces;
using SharedCode.Models;
using SharedCode.Utils;

namespace SharedCode.Managers
{
	public class ClimateService : IClimateService
	{
        public INetworkHandler NetworkHandler = Ioc.Default.GetRequiredService<INetworkHandler>();

        public ClimateService(INetworkHandler networkHandler)
		{
            NetworkHandler = networkHandler;
		}

        public async Task<Result<List<ListResponse>>> GetWeatherByCitiName(string cityName)
        {
            try
            {
                var response = await NetworkHandler.GetData<WeatherResponse>(Constants.ClimateFindBaseUrl + cityName + Constants.ClimateFindAppId);
                return Result.Ok(response.ListResponse);
            }
            catch (NetworkErrorException ex)
            {
                switch (ex.Code)
                {
                    case (int)HttpStatusCode.InternalServerError:
                        return Result.Fail<List<ListResponse>>("It seems like WeatherApi server is down");
                    case (int)HttpStatusCode.NotFound:
                        return Result.Fail<List<ListResponse>>("The weather list seems to be unavailable right now");
                    default:
                        return Result.Fail<List<ListResponse>>(ex.Message ?? "Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<List<ListResponse>>($"Check your internet connection {ex}");
            }
        }

        public async Task<Result<byte[]>> GetWeatherImage(string iconId)
        {
            try
            {
                var data = await NetworkHandler.LoadImage(Constants.ClimateIconUrl + iconId + "@2x.png");
                return Result.Ok<byte[]>(data);
            }
            catch (NetworkErrorException ex)
            {
                switch (ex.Code)
                {
                    case (int)HttpStatusCode.NotFound:
                        return Result.Fail<byte[]>("Can't retrieve weather image");
                    default:
                        return Result.Fail<byte[]>(ex.Message ?? "Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<byte[]>($"Check your internet connection {ex.ToString()}");
            }
        }
    }
}

