# E-commerce App

The E-commerce App is a modern shopping application with a React frontend and an ASP.NET backend. 
## Description

This project features a frontend developed with React and a backend powered by ASP.NET Core.

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Features

- Browse products
- View product details
- Search and filter products
- Responsive design
- Backend API with ASP.NET Core

## Installation

To get started with the E-commerce App, follow these steps:

### Frontend

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/ecommerce-app-2.git
    ```
2. Navigate to the project directory:
    ```sh
    cd ecommerce-app-2
    ```
3. Install the necessary dependencies:
    ```sh
    npm install
    ```
4. Start the React application:
    ```sh
    npm start
    ```
5. Frontend runs on localhost:3000
    ```sh
    localhost:3000
    ```

### Backend

1. Navigate to the backend directory:
    ```sh
    cd ecommerce-backend
    ```
2. Install the necessary dependencies:
    ```sh
    dotnet restore
    ```
3. Configure the database by updating the `appsettings.json` file with your connection string.
4. Run migrations to set up the database:
    ```sh
    dotnet ef database update
    ```
5. Start the ASP.NET Core server:
    ```sh
    dotnet run
    ```
6. Backend runs on localhost:5080
    ```sh
    localhost:5080
    ```

## Screenshots

### Home Page

<table>
  <tr>
    <td><img src="/homepage.png?raw=true" alt="Home Page" width="400"/></td>
  </tr>
</table>

### Products

<table>
  <tr>
    <td><img src="/products.png?raw=true" alt="Product Details 1" width="400"/></td>
  </tr>
</table>

### Product Hover
<table>
  <tr>
    <td><img src="/productHover.png?raw=true" alt="Product Details 2" width="300"/></td>
  </tr>
</table>


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For any inquiries, please contact [Huzuntu](https://github.com/Huzuntu).
