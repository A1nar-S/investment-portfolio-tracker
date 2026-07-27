# Investment Portfolio Tracker

Tracks a personal investment portfolio using the Trading212 API.

Future plans: extend to integrate with other brokers, e.g. IBKR.

## Running infra locally

```bash
docker compose -f infra/docker-compose.yml up -d
```

Starts Postgres (`localhost:5432`), Redis (`localhost:6379`), and RabbitMQ (`localhost:5672`, management UI at `localhost:15672`).

To stop:

```bash
docker compose -f infra/docker-compose.yml down
```
