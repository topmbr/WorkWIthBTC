// Создаем объект BitcoinSecret из WIF

using NBitcoin;
using Newtonsoft.Json.Linq;
using RestSharp;

var wif = "cR99qrHN8g8nMrBETCQVLNesphLFpt3pV65ZHCQynT9X1RrVrC2M";

BitcoinSecret bitcoinSecret = new BitcoinSecret(wif, Network.TestNet);

// Получаем публичный адрес

BitcoinAddress address = bitcoinSecret.PubKey.GetAddress(ScriptPubKeyType.Segwit, Network.TestNet);

// Выводим адрес

Console.WriteLine("Address: " + address);

// Используем BlockCypher API для получения баланса

string apiBaseUrl = "https://api.blockcypher.com/v1/btc/test3/addrs/" + address + "/balance";

var client = new RestClient(apiBaseUrl);

var request = new RestRequest();

var response = client.Execute(request);

JObject responseData = JObject.Parse(response.Content);

// Получаем баланс

long balance = responseData["balance"].Value<long>();

// Выводим баланс

Console.WriteLine("Balance: " + balance + " satoshis");
