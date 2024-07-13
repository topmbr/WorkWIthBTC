using RestSharp;
using Newtonsoft.Json.Linq;
 
class Program
{
    static async Task Main(string[] args)
    {
        string address = "tb1qqfmqcgf77wfxc44n4a4qpx0y9wcljyqrtl5k9c";
        // Получаем баланс адреса
        var balance = await GetAddressBalance(address);
        if (balance != null)
        {
            Console.WriteLine($"Адрес: {address}");
            Console.WriteLine($"Баланс: {balance["balance"]} сатоши");
            Console.WriteLine($"Не потрачено: {balance["unspent_balance"]} сатоши");
        }
        else
        {
            Console.WriteLine("Не удалось получить баланс адреса.");
        }
    }
    public static async Task<JObject> GetAddressBalance(string address)
    {
        var client = new RestClient($"https://api.blockcypher.com/v1/btc/test3/addrs/{address}/balance");
        var request = new RestRequest($"https://api.blockcypher.com/v1/btc/test3/addrs/{address}/balance", Method.Get);
        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
            return JObject.Parse(response.Content);
        }
        return null;
    }
}