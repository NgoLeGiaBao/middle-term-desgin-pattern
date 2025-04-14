# 💬 Chat Application - Implementing Mediator & Memento Patterns

## System Requirements

To run the full application, ensure you have the following installed:

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Node.js (v18+)](https://nodejs.org/)
- [npm](https://www.npmjs.com/) or [yarn](https://yarnpkg.com/)

## How to Run the Application

### 1. **Back-End Setup**
   - Open the first terminal and navigate to the back-end directory:
     ```bash
     cd back-end-chat
     ```
   - Restore project dependencies and run the back-end server:
     ```bash
     dotnet restore
     dotnet run
     ```
   - The back-end server will be running at: `http://localhost:5000`.

### 2. **Front-End Setup**
   - Open the second terminal and navigate to the front-end directory:
     ```bash
     cd frontend
     ```
   - Install the necessary front-end dependencies:
     ```bash
     npm install
     ```
   - Start the front-end application:
     ```bash
     npm start
     ```
   - The front-end application will be accessible at: `http://localhost:3000`.

## Application Overview

### Key Features
- **Mediator Pattern**: Decouples users' interactions by routing all communication through a central mediator, simplifying message routing and enhancing system scalability and maintenance.
- **Memento Pattern**: Allows users to save and restore the message history, providing features like "Undo" for messages, making it possible to revert changes in chat history.

### Application Architecture
- **Back-End**: Built with .NET 9, implementing the Mediator and Memento patterns to handle message sending, broadcasting, and history management.
- **Front-End**: A React-based interface that enables users to interact with the chat system, send messages, view message history, and perform "Undo" actions.

## Getting Started

1. **Clone the repository** and navigate to the appropriate directories for back-end and front-end setup.
2. Follow the instructions above to start the server and the application.
3. Open your browser and navigate to `http://localhost:3000` to start interacting with the chat application.

---

For more details, or to contribute to the project, please feel free to open issues or submit pull requests.
