$env:DB_USER = 'postgres';
$env:DB_PORT = '5432';
$env:DB_NAME = 'WebApp';
$env:DB_PASSWORD = 'qwe123';
$env:DB_HOST = 'localhost';
$env:ASPNETCORE_ENVIRONMENT = 'Development';

dotnet ef --startup-project ../WebApp.API/ migrations add --context Context InitialMigration