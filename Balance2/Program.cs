using System;

using RestSharp;

using Newtonsoft.Json.Linq;
 
class Program

{

    static async Task Main(string[] args)

    {

        // Пример публичного адреса для TestNet

        string address = "tb1qqfmqcgf77wfxc44n4a4qpx0y9wcljyqrtl5k9c";

        // Получаем UTXO для адреса

        var utxos = await GetAddressUTXOs(address);

        if (utxos != null)

        {

            Console.WriteLine($"UTXO для адреса: {address}");

            foreach (var utxo in utxos)

            {

                Console.WriteLine($"Транзакция: {utxo["tx_hash"]}");

                Console.WriteLine($"Выход: {utxo["tx_output_n"]}");

                Console.WriteLine($"Сумма: {utxo["value"]} сатоши");

                Console.WriteLine();

                Console.WriteLine(utxo);

            }

        }

        else

        {

            Console.WriteLine("Не удалось получить UTXO для адреса.");
        }
    }

    public static async Task<JArray> GetAddressUTXOs(string address)

    {

        var client = new RestClient($"https://api.blockcypher.com/v1/btc/test3/addrs/{address}?unspentOnly=true");

        var request = new RestRequest($"https://api.blockcypher.com/v1/btc/test3/addrs/{address}?unspentOnly=true", Method.Get);

        var response = await client.ExecuteAsync(request);

        if (response.IsSuccessful)

        {

            var data = JObject.Parse(response.Content);

            return (JArray)data["txrefs"];

        }

        return null;

    }

}

