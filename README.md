# Portfolio Tracker

## Running infra locally

```bash
docker compose -f infra/docker-compose.yml up -d
```

Starts Postgres (`localhost:5432`), Redis (`localhost:6379`), and RabbitMQ (`localhost:5672`, management UI at `localhost:15672`).

To stop:

```bash
docker compose -f infra/docker-compose.yml down
```
