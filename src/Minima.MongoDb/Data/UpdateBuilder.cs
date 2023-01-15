﻿using System.Linq.Expressions;
using MongoDB.Driver;

namespace Minima.MongoDb.Data;

public class UpdateBuilder<T>
{
    private readonly List<UpdateDefinition<T>> _list = new();
    private readonly List<MongoDB.Driver.ExpressionFieldDefinition<T, object>> _expressionFieldDefinitions = new();

    protected UpdateBuilder() { }

    public static UpdateBuilder<T> Create()
    {
        return new();
    }

    public UpdateBuilder<T> Set<TProperty>(Expression<Func<T, TProperty>> selector, TProperty value)
    {
        //for mongodb
        _list.Add(Builders<T>.Update.Set(selector, value));
        
        return this;
    }

    public IEnumerable<UpdateDefinition<T>> Fields {
        get { return _list; }
    }

    public IEnumerable<MongoDB.Driver.ExpressionFieldDefinition<T, object>> ExpressionFields {
        get { return _expressionFieldDefinitions; }
    }
}