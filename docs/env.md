# Using .env with appsettings


this guide gives a good overview of how to use .env 
https://dusted.codes/dotenv-in-dotnet

# Appsettings format

as seen in `appsettings.json`
	
	"WeatherSettings": {
		"ServiceName": ""
	}

to have `ServiceName`filled have the following in the .env file:
	
	WeatherSettings__ServiceName=ServiceName
