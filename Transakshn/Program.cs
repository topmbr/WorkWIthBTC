using Newtonsoft.Json.Linq;

using System;

using System.Threading.Tasks;

using RestSharp;

 
class Program

{

    static async Task Main(string[] args)

    {

        // Пример идентификатора транзакции (TXID) для TestNet

        string txid = "6fd5c1705709a142a16f04bdfbc466e84527c9740b93eb42451e2c9969020c43";

        // Получаем информацию о транзакции

        var transaction = await GetTransaction(txid);

        if (transaction != null)

        {

            Console.WriteLine($"Транзакция: {txid}");

            Console.WriteLine($"Подтверждения: {transaction["confirmations"]}");

            Console.WriteLine("Входы:");

            foreach (var input in transaction["inputs"])

            {

                Console.WriteLine($"  Адрес: {input["addresses"][0]}");

                Console.WriteLine($"  Сумма: {input["output_value"]} сатоши");

            }

            Console.WriteLine("Выходы:");

            foreach (var output in transaction["outputs"])

            {

                Console.WriteLine($"  Адрес: {output["addresses"][0]}");

                Console.WriteLine($"  Сумма: {output["value"]} сатоши");

            }

        }

        else

        {

            Console.WriteLine("Не удалось получить информацию о транзакции.");

        }

    }

    public static async Task<JObject> GetTransaction(string txid)

    {

        var client = new RestClient($"https://api.blockcypher.com/v1/btc/test3/txs/{txid}");

        var request = new RestRequest($"https://api.blockcypher.com/v1/btc/test3/txs/{txid}", Method.Get);

        var response = await client.ExecuteAsync(request);

        if (response.IsSuccessful)

        {

            return JObject.Parse(response.Content);

        }

        return null;

    }

}

