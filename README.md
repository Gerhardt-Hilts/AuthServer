# Inventory Management

A demo app for tracking arbitrary items.

## TOC

Table of contents

1. [Setup](#setup)
2. [Usage](#usage)
3. [Rundown](#rundown)
4. [Todo](#todo)


## Setup


## Usage

Items are sorted based on a simple format.
```
Item
    id - the table identifier
    uuid - the unique identifier
    name - the name of the item, describes the item i.e. laptop, printer, etc.
    itemCondition - good, ok, bad
```


## Rundown

This app utilizes multi-layered micro-service architecture.
Each micro-service is separated into it's own assembly.
Allowing for easy containerization using popular container platforms, such as docker, which in turn allows for easy container orchestration, allowing easy service lifecycle management.
Micro-services are separated into 2 layers, a simple layer for handling database queries and file fetching, 
and a complex layer for handling the logic that those database actions collectively form.

Micro-services will start out as a single assembly containing three main layers
* the data access layer, which is connected directly to the database, and maps queries to models.
* the business logic layer, which connects only to the data access layer, and later after splitting this micro-service, to other data access layers.
* the controller layer, which organizes routes, handles user given parameters and arguments,

Users will be authenticated via an OAuth 2.0 enabled service.
The service is labeled Auth.


## Dependencies
IdentityServer4 - used for OAuth


## TODO

* Enable GraphQL
* Enable OAuth2.0
* Dockerfiles
* PWA
* Unit Testing
* Developer SSL certificate (*OpenSSL*) [link](https://www.freecodecamp.org/news/how-to-get-https-working-on-your-local-development-environment-in-5-minutes-7af615770eec/)
* Secrets in your app [link](https://medium.com/poka-techblog/the-best-way-to-store-secrets-in-your-app-is-not-to-store-secrets-in-your-app-308a6807d3ed)
