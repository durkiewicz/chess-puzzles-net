# ChessNET

A Blazor app with chess puzzles. Live demo: [https://chess-puzzles.up.railway.app](https://chess-puzzles.up.railway.app)

## Development

### Running a dev server
```sh
dotnet watch run
```

### Preparing the release
```sh
dotnet publish -c Release
```
The static file to use are in `./bin/Release/net5.0/publish/`