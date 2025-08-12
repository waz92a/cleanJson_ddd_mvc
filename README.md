# CleanJson — DDD + MVC (.NET 8) with Swagger and NSwag (React)

## Run the API
```bash
cd CleanJson.Web
dotnet run
```

Open Swagger UI: http://localhost:5133/swagger

## Generate the React TypeScript client

From the repo root:

```bash
dotnet tool restore
# emits react-client/src/api/client.ts
dotnet nswag run CleanJson.Web/nswag.json
```

## Run the React app

```bash
cd react-client
npm install
npm run dev
```

Set the `baseUrl` in `App.tsx` to match the API’s HTTPS/HTTP URL.
