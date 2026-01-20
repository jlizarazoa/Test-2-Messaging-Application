# Messaging Application - Logging System

## Description
This project is a messaging application built using .NET Framework 4.8. It allows to log messages to different destinations such as console, file, and database. The application is designed to be modular and extensible, making it easy to add new logging destinations in the future.

## Requirements

The solution addresses the following requirements:

- Log messages to multiple destinations (e.g., console, file).
- Support message types: Message, Warning, and Error (only one per message).
- Store all configuration in the application configuration file.
- Apply SOLID principles.
- Use the Strategy and Singleton design patterns.
- Use dependency injection.

## Designing Decisions

- **Singleton Pattern**: The LoggerConfiguration class is implemented as a singleton to ensure that there is only one instance of configuration throughout the application.
- **Strategy Pattern**: Different logging strategies (ConsoleLogger, FileLogger, DatabaseLogger) are implemented to allow easy switching and addition of new logging methods.
- **Factory Pattern**: A LoggerFactory class is used to create instances of different logger types based on configuration settings.
- **Dependency Injection**: JobLogger class receives its dependencies through constructor injection, promoting loose coupling and easier testing. Also, FileLogger receives the file path via constructor injection.
- **Separation of Concerns**: Configuration handling, object creation, and logging behavior are separated into distinct components.

## Tech Notes
- Thread-safe singleton implementation for LoggerConfiguration with Double-Check Locking.
- Configuration validation in initialization to ensure correct setup.
- Exception handling for file operations and invalid configuration.

## Configuration
All settings are defined in `App.config` under the `<appSettings>` section.