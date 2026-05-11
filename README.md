# Customer Notification System

A cloud-native .NET solution built with **ASP.NET Core**, **Azure Functions**, and **Azure Cosmos DB**.
The system automatically reacts to database changes and triggers email notifications when customer data is created or updated.

---

# 🚀 Overview

This project demonstrates an event-driven architecture using Azure services and modern .NET development practices.

## Main Components

### ASP.NET Core Web API

* Handles customer management
* Stores data in Cosmos DB
* Exposes REST endpoints

### Azure Cosmos DB

* Uses containers and partition keys
* Acts as the event source for triggers

### Azure Functions

* Listens to Cosmos DB Change Feed
* Processes changes asynchronously
* Sends automated emails when data changes

### Email Service

* Generates and sends notification emails
* Triggered automatically from the Function App

---

# 🏗️ Architecture

```text
Client/API Request
        │
        ▼
 ASP.NET Core API
        │
        ▼
 Azure Cosmos DB
(CompanyData container)
        │
        ▼
 Cosmos DB Change Feed
        │
        ▼
 Azure Function Trigger
        │
        ▼
 Email Service
        │
        ▼
 Salesman Notification Sent
```

---

# ⚙️ Features

* Create and update customers
* Event-driven email notifications
* Cosmos DB Change Feed integration
* Azure Functions isolated worker model
* Scalable serverless architecture
* Separation of concerns between API and background processing
* Async processing for reliability

---

# 🧱 Tech Stack

## Backend

* .NET 10
* ASP.NET Core Web API
* Azure Functions
* Repository & Service pattern
* Dependency Injection

## Cloud & Infrastructure

* Cosmos DB
* Azure Functions
* Docker 
* Azurite 

## Email

* Resend API

# 🔄 How the Change Feed Works

1. A customer is created or updated through the API
2. Data is stored in Cosmos DB
3. Cosmos DB emits a change event
4. Azure Function detects the change through the Change Feed
5. The function processes the event
6. An email notification is generated and sent to the responible salesman

---

# 🔑 Cosmos DB Design

## Containers

### CompanyDB

Stores customer and salesmen information.


## Partition Keys

Example:

```text
/type
```

Partitioning improves scalability and query performance.

---

# 🛠️ Local Development

## Prerequisites

* .NET SDK 10
* Docker Desktop
* Azure Cosmos DB Emulator
* Azure Functions Core Tools


---

# ☁️ Future Improvements

* Retry policies
* Dead-letter handling
* Service Bus integration
* CI/CD with GitHub Actions
* Monitoring with Application Insights
* Dockerized deployment
* Distributed tracing
* Domain events

---

# 📚 Learning Goals

This project was built to practice:

* Event-driven architecture
* Azure Functions
* Cosmos DB Change Feed
* Cloud-native .NET development
* Async processing
* Scalable backend systems
* Distributed systems concepts

---

# 👨‍💻 Author

Daniel Ränk
.NET Cloud Developer Student
