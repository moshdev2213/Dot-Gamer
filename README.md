
# Dot Gamer


## Description

Dot Gamer is a simple game store management system API designed to streamline game operations and enhance user experience 🎮. The project offers a robust set of API endpoints that facilitate various actions related to game and genre management:

This project leverages modern web technologies and frameworks such as C#, ASP.NET Core, and Entity Framework Core to ensure efficient data handling and seamless API operations 🌐. It emphasizes best practices in API design, including parameter validation and error handling, to maintain reliability and security.


## API Endpoints

| API                 | EndPoint           | Description                                                |
| :------------------ | :----------------- | :--------------------------------------------------------- |
| `server health`     | `/`                | Server Online 🌐       |
| `Games - List`      | `/games/`          | Retrieves a list of all games with summary details. 🎮       |
| `Games - Details`   | `/games/{id}`      | Retrieves detailed information about a specific game by ID. 🕹️ |
| `Games - Create`    | `POST /games/`     | Creates a new game. 🆕                                      |
| `Games - Update`    | `PUT /games/{id}`  | Updates an existing game by ID. 🔄                          |
| `Games - Delete`    | `DELETE /games/{id}`| Deletes a game by ID. 🗑️                                   |
| `Genres - List`     | `/genres/`         | Retrieves a list of all genres. 📚                          |



## Checking GateWay Status

| Status | Value     | Description                |
| :-------- | :------- | :------------------------- |
| `Online` | `200` | **server Online** |

```javascript
{
    "message": "server Online"
}
```

This README provides a structured overview of the API endpoints, technologies used, and steps to get started with the Dot Gamer API. Adjust the content as per your project's specific details and requirements.