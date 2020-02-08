# urlShortener
A web application which make a short url with 8 characters for a given url and let you redirect to that
url using short url.
## Initialize 
If you don't have dotnet core, install it using this link [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

Use the following commands for creating the database:
```bash
dotnet tool install --global dotnet-ef

dotnet ef database update

```

## How to run
Open the terminal or command prompt at the API root path and run the project using this command:
```bash
dotnet run

```
## Make short url
Run the project, then run the following command:
```bash

curl -X POST -d "\"{long url}\"" -H "Content-Type: application/json" http://localhost:5000/urls

```
## Redirect using a short url
Run the project, then run the following command:
```bash

curl -i -L -k http://localhost:5000/Redirect/{short url}

```

## Test
Run the project, then use the following command at tests path to run the tests:

```bash

dotnet run

```


