# PlayStudio setup
## Clone project
```console
https://github.com/baohoangbk235/PlayStudio.git
```

## Back End
```console
cd PlayStudio\playstudio.server
dotnet restore
dotnet ef database update   
dotnet build
dotnet run
```
Open http://localhost:5157/swagger/index.html to Swagger page.

## Front End
```console
cd PlayStudio\playstudio.clientt
npm install 
npm run dev
```
Open http://localhost:5173/ to access UI page.

