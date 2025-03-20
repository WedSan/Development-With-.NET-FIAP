
# Toy Management Application - Checkpoint

This project is a Toy Management Application built with ASP.NET Core 8.0. It provides functionalities to manage toy inventory, including adding, deleting, and viewing toy details. The application uses a PostgreSQL database for data storage.

## Features

- **View Toys**: List all toys in the inventory.
- **Add Toys**: Add new toys to the inventory.
- **Delete Toys**: Remove toys from the inventory.
- **Toy Details**: View detailed information about each toy, including type, classification, size, and price.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop)

## Running the Application

The application can be run using Docker and Docker Compose. Follow the steps below to set up and run the application:

### Step 1: Build the Docker Images

Navigate to the root directory of the project where the `Dockerfile` and `docker-compose.yml` files are located.

```sh
docker-compose build
```

### Step 2: Start the Containers

Start the containers for the application and the PostgreSQL database.

```sh
docker-compose up -d
```

This command will start the application on port 8080 and the PostgreSQL database on port 5432.

### Step 3: Access the Application

Open a web browser and navigate to `http://localhost:8080` to access the Toy Management Application.

## Configuration

### Connection String

The application connects to a PostgreSQL database using the following connection string:

```
Host=db;Port=5432;Database=wedsanDatabase;Username=wedsan;Password=securepassword
```

This connection string is configured in the `docker-compose.yml` file and passed as an environment variable to the application container.

### Environment Variables

- `ASPNETCORE_ENVIRONMENT=Development`
- `ConnectionStrings__DefaultConnection=Host=db;Port=5432;Database=wedsanDatabase;Username=wedsan;Password=securepassword`

## Project Structure

- **Controllers**: Contains the MVC controllers for handling HTTP requests.
- **Models**: Contains the data models representing the entities in the application.
- **Repositories**: Contains the repository classes for data access.
- **Services**: Contains the service classes for business logic.
- **Views**: Contains the Razor views for the user interface.
- **Program.cs**: The entry point of the application.
- **appsettings.json**: Configuration file for application settings.