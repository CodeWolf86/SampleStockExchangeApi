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
1. Implement validation of requests, especially TickerSymbols supplied on post of exchange information.
1. Refactor some of the object mapping from Models/Entities DTO's to object mapper or implicit conversions and Unit Testing therein.
1. Introduce a configuration implementation to pass in configuration values like DB Connection string.
1. Extend CQRS implementation to potentially separate Interfaces for Read and Write which would allow a read only DB Connection string.
1. Implement Database project with structure and default data population.
1. Implement an ORM to remove the static data layer.
1. Consider basic security policies for the API to restrict access to the endpoints.
1. Integration test project to spin up a default database and test the endpoints and data returns with suitable teardown.


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

To handle scaling I would look to containerise the api project and deploy it behind a load balancer as part of an auto-scaling cluster. It would also be worth looking at splitting the read and write api's into different containers so they can be scaled independently. This would allow horizontal scaling of the read api's that can either read directly from a datastore, or from a cache of some form either individually to a container or shared which would be dictated by how long the data is "live" for.

The write api's can be deployed into their own containers as the load will be different. Initially this is to handle the submission of the stock exchange information and while this may be fine initially, if the level of load is intermittent, a migration into an asynchronous model may be more beneficial. Handing off any received payloads into an event which is handled by a background worker which subsequently processes the updates. This could then callback to the requester with an id to confirm that the update has occurred. 

From a security perspective, use of some form of API management gateway which would handle the authentication of external users before passing through to the microservices may be beneficial. Especially if the link from the Api gateway to the microservices can be locked down via network restrictions removing the need for direct authentication to the services. Allowing the API gateway to handle the authentication with external clients and key rotation making the back end authentication agnostic. Dependent on if knowledge of the caller is required at the service level.

This approach should address the NFR's of security, scaling and reliability, while also allowing easier environment setups through containerisation.



