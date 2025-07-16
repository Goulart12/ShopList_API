# ShopList API

This is a .NET Core API for managing shopping lists. It allows users to create and manage shopping lists.

## How to Run

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/ShopList_API.git
    ```
2.  **Navigate to the project directory:**
    ```bash
    cd ShopList_API
    ```
3.  **Restore the dependencies:**
    ```bash
    dotnet restore
    ```
4.  **Run the application:**
    ```bash
    dotnet run --project GroceryStoreShopListApi
    ```

## API Endpoints

### Product Endpoints

| Method | Route                                       | Description                      | Authorization |
| :----- | :------------------------------------------ | :------------------------------- | :------------ |
| POST   | `Product/Add/{shopListId}`                  | Add a product to a shopping list | Required      |
| GET    | `Product/GetAllProducts/{shopListId}`       | Get all products from a list     | Required      |
| GET    | `Product/GetProduct/{productId}`            | Get a product by its ID          | Required      |
| GET    | `Product/GetProductByName/{shopListId}/{productName}` | Get a product by its name      | Required      |
| PATCH  | `Product/Update/{shopListId}`               | Update a product in a list       | Required      |
| DELETE | `Product/Delete/{shopListId}`               | Delete a product from a list     | Required      |

### ShopList Endpoints

| Method | Route                       | Description                   | Authorization |
| :----- | :-------------------------- | :---------------------------- | :------------ |
| POST   | `ShopList/Create`           | Create a new shopping list    | Required      |
| GET    | `ShopList/GetAllLists`      | Get all shopping lists        | Required      |
| GET    | `ShopList/GetShopListById`  | Get a shopping list by its ID | Required      |
| GET    | `ShopList/GetShopListByName`| Get a shopping list by its name | Required      |
| PATCH  | `ShopList/Update/{shopListId}` | Update a shopping list      | Required      |
| DELETE | `ShopList/Delete/{shopListId}` | Delete a shopping list      | Required      |

### User Endpoints

| Method | Route                  | Description              | Authorization |
| :----- | :--------------------- | :----------------------- | :------------ |
| POST   | `User/Register`        | Register a new user      | No            |
| GET    | `User/GetUser`         | Get a user by their ID   | Required      |
| GET    | `User/GetByEmailUser`  | Get a user by their email| No            |
| POST   | `User/Login`           | Login as a user          | No            |
| POST   | `User/AddRole`         | Add a new role           | No            |
| GET    | `User/GetRoles/{roleId}` | Get a role by its ID     | No            |
