using System;
using System.Threading.Tasks;

namespace SharedCode.Interfaces
{
	public interface INetworkHandler
	{
        Task<T> GetData<T>(string endpoint);
        Task<byte[]> LoadImage(string imageUrl);
    }
}

