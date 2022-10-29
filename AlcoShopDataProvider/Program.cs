using AlcoShopDataProvider;

var source = "D:\\SAN\\git\\dotnet\\alco_data.txt";
var dest = "D:\\SAN\\git\\dotnet\\alco.json";
var parser = new FileParser(source);
var alco = parser.GetProducts();
var writer = new FileWriter(dest, alco);
writer.SaveFile();