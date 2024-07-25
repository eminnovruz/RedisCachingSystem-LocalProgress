# AzureRedisCachingSystem

**AzureRedisCachingSystem** is a .NET application demonstrating caching mechanisms using Redis. It provides a flexible caching system with features such as cache management, generic cache objects, and logging integration.

## Features

- **Cache Management**: 
  - Create, update, retrieve, and remove cache entries.
  - Support for setting cache expiration with different time units (seconds, minutes, months).

- **Generic Cache Object**:
  - A base cache object class for common cache operations.
  - A generic cache object class for flexible and type-safe caching.

- **Logging Integration**:
  - Configured with Serilog for detailed logging of cache operations and application activities.

- **Hashing Service**:
  - Provides MD5 hashing for generating unique keys and ensuring data integrity.

## Getting Started

### Prerequisites

- .NET 6.0 or later
- Redis server instance

### Installation

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/yourusername/AzureRedisCachingSystem.git
   cd AzureRedisCachingSystem
