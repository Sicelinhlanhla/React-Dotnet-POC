# React + ASP.NET Core + PostgreSQL POC

This repository contains a **full-stack proof-of-concept** demonstrating:

- React (Vite + TypeScript) frontend with routing and auth context
- ASP.NET Core API with JWT authentication
- PostgreSQL database
- Dockerized multi-service setup with Docker Compose
- Minimal CSS, clean architecture, and best practices

---

## Table of Contents

- [Requirements](#requirements)  
- [Setup & Run](#setup--run)  
- [Authentication Flow](#authentication-flow) 

---

## Requirements

- Docker >= 24.x  
- Docker Compose >= 2.x  
- Node.js >= 20.x (for frontend dev)  
- .NET 8 SDK (for backend dev)

---

## Setup & Run

1. Clone the repository:

```bash
git clone <your-repo-url>
cd react-dotnet-postgres-docker-poc
```

2. Start all services using Docker Compose
```bash
docker compose -f infrastructure/docker-compose.yml up --build
```

## Authentication Flow
Register
   - POST /api/auth/register

Login
   - POST /api/auth/login

JWT token returned
   - Stored in localStorage

Protected request
   - GET /api/auth/myProfile (Authorization: Bearer token)
