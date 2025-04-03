# Weather Dashboard

A full-stack weather application built with Angular and .NET Core.

## Features

- User authentication (login/register)
- Real-time weather data
- Weather forecasts
- Favorite locations
- Responsive design

## Tech Stack

- Frontend: Angular
- Backend: .NET Core
- Database: SQLite/SQL Server
- Authentication: JWT

## Setup Instructions

### Prerequisites

- Node.js (v14 or higher)
- .NET Core SDK (v6.0 or higher)
- Angular CLI

### Backend Setup

1. Navigate to the WeatherApi directory:

   ```bash
   cd WeatherApi
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

### Frontend Setup

1. Navigate to the weather-dashboard directory:

   ```bash
   cd weather-dashboard
   ```

2. Install dependencies:

   ```bash
   npm install
   ```

3. Start the development server:
   ```bash
   ng serve
   ```

## Environment Configuration

Create a `.env` file in the WeatherApi directory with the following variables:

```
JWT__Key=YourSecretKeyHere
JWT__Issuer=YourIssuer
JWT__Audience=YourAudience
```

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License.
