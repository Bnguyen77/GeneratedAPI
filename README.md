# Receipt Reward Point Processor

A simple API that processes receipts and awards points based on receipt content.  
Built with **ASP.NET Core 8.0** and **OpenAPI (Swagger)**, containerized with **Docker Compose**.

---

## Route Overview

### POST `/receipts/process`

Submits a receipt for processing.

- **Request Body:**
  - JSON receipt with fields like `retailer`, `purchaseDate`, `items`, and `total`
- **Returns:**
  - `{ "id": "some-uuid" }` — a unique receipt ID

### GET `/receipts/{id}/points`

Fetches the number of reward points associated with a previously submitted receipt.

- **Path Parameter:**
  - `id` — the receipt ID returned by the `/process` endpoint
- **Returns:**
  - `{ "points": 100 }`

---

##  Run with Docker Compose

###  Prerequisites

- [Docker](https://www.docker.com/products/docker-desktop)
- [Git](https://git-scm.com/)

---

##  Get Started

1. **Clone the repo then navigate to Dockerfile in local repo**

```bash
git clone https://github.com/Bnguyen77/GeneratedAPI.git
cd src/GeneratedAPI/
```
2. **Run docker-compose command to build image**
```bash
docker-compose up --build
```
3. **Endpoints are accessible at:**
[https://localhost:8081/openapi/index.html](https://localhost:8081/openapi/index.html)