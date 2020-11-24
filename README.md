# A Base Library For Rest APIs

## Controllers

A Controller is used to define the available methods per Entity and dispatch HTTP requests to the respective Handler.

Example:

If you want full CRUD options for a model, simply inherit from CrudController.

```csharp
public class PersonController : CrudController<int, Person, PersonGetSingleResponseModel, PersonGetListResponseModel, PersonPutRequestModel, PersonPostRequestModel> {

    public PersonController(ILogger<PersonController> logger, IMediator mediator) : 
        base(logger, mediator) {
    }

}
```

## Handlers

For each HTTP method, implement a desired Handler by inheriting from Hander.

Example for GET:

```csharp
public class PersonGetSingleHandler : Handler<GetSingleRequest<int, Person, PersonGetSingleResponseModel>> {

    public async Task<PersonGetSingleResponseModel> ExecuteAsync(
        GetSingleRequest<int, Person, PersonGetSingleResponseModel> message, 
        CancellationToken cancellationToken) {

        // do whatever you need to do :)

    }

}
```
