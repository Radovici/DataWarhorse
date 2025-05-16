# DataWarhorse

DataWarhorse combines battle-tested financial software to provide the best financial analysis and risk management on the street. Now modernized with the latest generative AI to construct and optimize portfolios. It’s a modular, datastore-agnostic platform designed for clarity, extensibility, and correctness—revived and open-sourced after years of sitting on the shelf after an unsuccessful startup.

![CI](https://github.com/Radovici/DataWarhorse/actions/workflows/ci.yml/badge.svg)

---

## Why DataWarhorse?

I built DataWarhorse because I wanted a better foundation for risk technology. After working across several firms, one thing became clear: building robust risk systems is hard—and the industry often falls short.

In 2025, many platforms still rely on spreadsheets or legacy tools, struggle with basic requirements like hypothetical rebalances, ETF look-throughs, or unadjusted market data, and fall into avoidable traps due to poor modeling decisions.

This isn’t a criticism—it’s a reflection of how complex and fragmented the financial data and software space is. But with the right models, the right abstractions, and the right provider patterns, many of these problems can be solved elegantly.

DataWarhorse is an attempt to capture that.

The original business may have failed, but the technology didn’t—and I didn’t want that work to disappear.

---

## Target Release

A community-ready version of DataWarhorse is planned for **late summer 2025**. Contributions and collaboration will be welcome then.

---

## Key Concepts

- **Datastore-Agnostic**: Built on EF Core with pluggable support for SQL Server, PostgreSQL, SQLite, MySQL, and cloud backends.
- **Native Providers**: Intra-process providers (e.g., `TradeProvider`, `PositionProvider`, `MarketDataProvider`) used for efficient, service-layer-free operations in memory.
- **Server Providers**: Remote-capable alternatives for distributed systems or cloud-based deployment.
- **Unified Data Models (UDM)**: Materialized, enriched domain objects like `ITrade`, `IPosition`, `ISecurity`, which can access metadata, price targets, and more.
- **Queryable Abstractions**: Interfaces like `IQueryableTrade` allow consumers to filter and slice data at the EF Core level before materialization.
- **Hypotheticals & Rebalancing**: Explicitly modeled to support hypothetical positions, trade overrides, SMA-style rebalancing, and saved positions.
- **AI Integration**: Long-term support for AI-native workflows, portfolio agents, onboarding bots, and scenario generation using LLMs.
- **Cross-Platform UI**: Uno-based frontends (desktop, web, mobile) for intuitive interaction, dashboards, and live analytics.

---

## Architecture

- **EF Core Entities**: Used for lightweight, high-performance LINQ queries.
- **IQueryable Models**: Like `IQueryableTrade` and `IQueryablePosition`, exposed for custom filtering without EF Core internals.
- **Native Providers**: Provide intra-process access to trades, positions, securities, users, and metadata.
- **Server Providers**: Provide equivalent capabilities over HTTP or messaging protocols.
- **UDMs**: Final materialized models with full provider access.

---

## Use Cases

- Portfolio construction and optimization
- Risk analysis with stress, factor, and what-if scenarios
- Daily position generation and trade aggregation
- Alternative data integration
- AI-guided workflows and dashboards
- Efficient modeling of price targets, exposures, lookthroughs, and constraints

---

## Coming Soon

As the platform is brought back online and modernized, we’ll add:
- Setup and usage instructions
- Example portfolios and integrations
- A roadmap and contribution guidelines

---

![CI](https://github.com/Radovici/DataWarhorse/actions/workflows/ci.yml/badge.svg)

---

- OpenApi and MCP LLM integration using ModelContextProtocol C# SDK
- Note on hedge fund software and why their software is turrible (sic).
