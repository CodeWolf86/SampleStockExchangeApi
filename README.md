# LondonStockApi

## Introduction
This is a small MVP put together to demonstrate a rough structure of a solution idea. It doesn't contain 
everything that a production ready solution should contain but provides a framework for discussion for
direction of travel in terms of design, layout and future iterative versions when scaling is taken into account.

## Data Store
The assumption is the use of Microsoft Sql Server as the back end database with EntityFramework Core as the ORM
but due to time constraints the lower level data interface is not implemented and is simply mocked to give an
out the box working solution that can be ran even if it's not fully functional.

## List of MVP additions
1. Introduction of validation for some of the endpoints, specifically the submission of stock exchanges.
2. Introduce basic security, ideally an Azure JWT implementation.
3. Add in the database structure in the database project to allow it to be published to a local SQL Server instance with a post script to add default values.
4. Implement Entity Framework to bridge the gap between the static data implementation and database project. Refine the relationships between the entities to allow lazy loading of related entities for more complex queries.
5. Extend CQRS implementation to potentially separate Interfaces for Read and Update which would allow a read only DB Connection string.
6. Introduce a configuration implementation to pass in configuration values like DB Connection string.
7. Integration test project to spin up a default database and test the endpoints and data returns with suitable teardown.

## NFR considerations
This will partly roll into enhancements but items to be aware of include:
1. Suitable security specification to restrict access to the Api ( white list of valid accessors, and if they should have different rights e.g. read vs write)
2. Scaling into a larger system with higher volume of traffic, how would the current MVP hold up? how would it be tested?
3. How speedy will the response times be overall? Can any tuning be done?
4. Reliability, how do we ensure a suitable amount of uptime, what's the fallback if the system does go down?
5. Environment's, suitable infrastructure for the deployed application, prod replicas to allow testing before go live.


# Enhancements

## Assessment of current MVP
The current solution will solve the initial problem but it would bottleneck quickly. Either through volume of requests, or through overload of submission of exchange data.

The best way to take it forward would be to make the API front end as light as possible and to hand off to a queue to simply take the message rather than process straight away. The GET's are simple enough and using containers and horizontal scaling behind a load balancer, the GET queries can be taken care of fairly easily, especially if we use cacheing. However given the data may well need to be always the latest, it depends on a suitable time to expire. 

Using Microsoft API Management gateway is also an option, it would provide the load balanced front end and can route to the internal api's deployed via say Kubernetes to restrict external consumption. Kubernetes can then monitor response times and spin up additional instances to allow the API calls to be available.

This can also apply to a new worker or azure function project whose role is to process the stock exchange transfer requests. If there are too many, additional worker containers can be spun up to process the influx and dynamically scale where load is tested.

APIM also provides a suitable security solution whereby APIM keys are given to consumers of the API and need to be supplied in order to gain access. The internal microservices can then be whitelisted to certain ip addresses to lockdown access to only known sources. This can be doubly secure using Azure managed identity to make sure the APIM instance can acquire a JWT to access the hosted micro services.

This approach should address the NFR's of security, scaling and reliability, while also allowing easier environment setups through containers.



