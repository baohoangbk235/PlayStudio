# PlayStudio setup
## Back End
cd PlayStudio\playstudio.server
dotnet restore
dotnet ef database update   
dotnet build
dotnet run

Open http://localhost:5157/swagger/index.html to Swagger page.

## Front End
cd PlayStudio\playstudio.clientt
npm install 
npm run dev

Open http://localhost:5173/ to access UI page.

