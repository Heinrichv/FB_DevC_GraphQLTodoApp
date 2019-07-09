# FB_DevC_GraphQLTodoApp
To-Do API built with .NET Core &amp; GraphQL for Facebook Dev Circles JHB Meetup demo

This is an example todo app of [Facebook's GraphQL](https://github.com/facebook/graphql) in .NET Core.

## Installation

You can install the latest version via [NuGet](https://www.nuget.org/packages/GraphQL/).

```
PM> Install-Package GraphQL
```

Or you can get the latest pre-release packages from the [MyGet feed](https://www.myget.org/F/graphql-dotnet/api/v3/index.json).


## Documentation

http://graphql-dotnet.github.io

## Examples

https://github.com/graphql-dotnet/examples

## Training

* [API Development in .NET with GraphQL](https://www.lynda.com/NET-tutorials/API-Development-NET-GraphQL/664823-2.html) - [Glenn Block](https://twitter.com/gblock) demonstrates how to use the GraphQL .NET framework to build a fully functional GraphQL endpoint.

## Upgrade Guides

* [0.17.x to 2.x](https://graphql-dotnet.github.io/docs/guides/migration)
* [0.11.0](/upgrade-guides/v0.11.0.md)
* [0.8.0](/upgrade-guides/v0.8.0.md)

## Basic Usage

Define your schema with a top level query object then execute that query.

Fully-featured examples can be found [here](https://github.com/graphql-dotnet/examples).

### Hello World

```csharp
var schema = Schema.For(@"
  type Query {
    hello: String
  }
");

var root = new { Hello = "Hello World!" };
var json = schema.Execute(_ =>
{
  _.Query = "{ hello }";
  _.Root = root;
});

Console.WriteLine(json);
```

### Schema First Approach

This example uses the [Graphql schema language](https://graphql.org/learn/schema/#type-language).  See the [documentation](https://graphql-dotnet.github.io/docs/getting-started/introduction) for more examples and information.

```csharp
public class Droid
{
  public string Id { get; set; }
  public string Name { get; set; }
}

public class Query
{
  [GraphQLMetadata("droid")]
  public Droid GetDroid()
  {
    return new Droid { Id = "123", Name = "R2-D2" };
  }
}

var schema = Schema.For(@"
  type Droid {
    id: ID
    name: String
  }

  type Query {
    droid: Droid
  }
", _ => {
    _.Types.Include<Query>();
});

var json = schema.Execute(_ =>
{
  _.Query = "{ droid { id name } }";
});
```

### Parameters

```csharp
public class Droid
{
  public string Id { get; set; }
  public string Name { get; set; }
}

public class Query
{
  private List<Droid> _droids = new List<Droid>
  {
    new Droid { Id = "123", Name = "R2-D2" }
  };

  [GraphQLMetadata("droid")]
  public Droid GetDroid(string id)
  {
    return _droids.FirstOrDefault(x => x.Id == id);
  }
}

var schema = Schema.For(@"
  type Droid {
    id: ID
    name: String
  }

  type Query {
    droid(id: ID): Droid
  }
", _ => {
    _.Types.Include<Query>();
});

var json = schema.Execute(_ =>
{
  _.Query = $"{{ droid(id: \"123\") {{ id name }} }}";
});
```
