using NBitcoin;

//Private Key(Base58): cR99qrHN8g8nMrBETCQVLNesphLFpt3pV65ZHCQynT9X1RrVrC2M
//Address: tb1qqfmqcgf77wfxc44n4a4qpx0y9wcljyqrtl5k9c


var mnemo = new Mnemonic("sister nothing crime ginger cushion solar update save ankle injury canyon two\r\n", Wordlist.English);
var hdroot = mnemo.DeriveExtKey();
var pKey = hdroot.Derive(new KeyPath("m/84'/0'/0'/0/0"));
var pKey2 = hdroot.Derive(new KeyPath("m/84'/0'/0'/0/1"));

var fullkey = pKey.GetWif(Network.TestNet);
Console.WriteLine(fullkey);

var key1 = pKey.GetWif(Network.TestNet).PrivateKey;
Console.WriteLine(key1);

var key4 = pKey.GetWif(Network.TestNet).PrivateKey.ToHex();
Console.WriteLine(key4);

Console.WriteLine(pKey.PrivateKey.PubKey.GetAddress(ScriptPubKeyType.Segwit, Network.TestNet));
//Console.WriteLine(pKey2.PrivateKey.PubKey.GetAddress(ScriptPubKeyType.Segwit, Network.TestNet));


// Преобразуем приватный ключ в WIF для TestNet
BitcoinSecret bitcoinSecret = key1.GetWif(Network.TestNet);

// Получаем Base58 строку из WIF
string base58PrivateKey = bitcoinSecret.ToWif();

// Выводим приватный ключ в формате Base58
Console.WriteLine("Private Key (Base58): " + base58PrivateKey);

// Получаем публичный адрес (Segwit) для TestNet
BitcoinAddress address = bitcoinSecret.PubKey.GetAddress(ScriptPubKeyType.Segwit, Network.TestNet);

// Выводим публичный адрес
Console.WriteLine("Address: " + address);

