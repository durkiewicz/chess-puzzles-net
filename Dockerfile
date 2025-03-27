FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Create and change to the app directory.
WORKDIR /app

# Copy the files to the container image
# COPY minigamescontroller/package*.json ./

# Install packages
# RUN npm ci

# Copy local code to the container image.
COPY . ./

# Build the app.
RUN dotnet publish -c Release 

# Use the Caddy image
FROM caddy

# Create and change to the app directory.
WORKDIR /app

# Copy Caddyfile to the container image.
COPY Caddyfile ./

# Copy local code to the container image.
RUN caddy fmt Caddyfile --overwrite

# Copy files to the container image.
COPY --from=build /app/bin/Release/net5.0/publish/wwwroot ./dist

# Use Caddy to run/serve the app
CMD ["caddy", "run", "--config", "Caddyfile", "--adapter", "caddyfile"]
