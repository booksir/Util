﻿using Util.Tenants.Tests.Samples;

namespace Util.Tenants.Tests.Resolvers;

/// <summary>
/// 租户解析器集合测试
/// </summary>
public class TenantResolverCollectionTest {
    /// <summary>
    /// 租户解析器集合
    /// </summary>
    private readonly TenantResolverCollection _resolvers;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public TenantResolverCollectionTest() {
        _resolvers = new TenantResolverCollection();
    }

    /// <summary>
    /// 测试添加租户解析器
    /// </summary>
    [Fact]
    public void TestAddTenantResolver_1() {
        _resolvers.Add( new TestTenantResolver() );
        var result = _resolvers.GetResolvers();
        Assert.Single( result );
    }

    /// <summary>
    /// 测试添加租户解析器 - 重复检测
    /// </summary>
    [Fact]
    public void TestAddTenantResolver_2() {
        _resolvers.Add( new TestTenantResolver() );
        _resolvers.Add( new TestTenantResolver() );
        var result = _resolvers.GetResolvers();
        Assert.Single( result );
    }

    /// <summary>
    /// 测试添加租户解析器 - 指定键
    /// </summary>
    [Fact]
    public void TestAddTenantResolver_3() {
        _resolvers.Add( "a", new TestTenantResolver() );
        _resolvers.Add( "b", new TestTenantResolver() );
        var result = _resolvers.GetResolvers();
        Assert.Equal( 2, result.Count );
    }

    /// <summary>
    /// 测试添加租户解析器集合
    /// </summary>
    [Fact]
    public void TestAddTenantResolvers() {
        _resolvers.Add( new List<ITenantResolver> { new TestTenantResolver(), new Test2TenantResolver() } );
        var result = _resolvers.GetResolvers();
        Assert.Equal( 2, result.Count );
    }

    /// <summary>
    /// 测试移除租户解析器 - 按类型移除
    /// </summary>
    [Fact]
    public void TestRemoveTenantResolver_1() {
        _resolvers.Add( new TestTenantResolver() );
        _resolvers.Remove<TestTenantResolver>();
        var result = _resolvers.GetResolvers();
        Assert.Empty( result );
    }

    /// <summary>
    /// 测试移除租户解析器 - 按键名移除
    /// </summary>
    [Fact]
    public void TestRemoveTenantResolver_2() {
        _resolvers.Add( "a", new TestTenantResolver() );
        _resolvers.Add( "b", new Test2TenantResolver() );
        _resolvers.Remove( "a" );
        var result = _resolvers.GetResolvers();
        Assert.Single( result );
        Assert.Equal( typeof( Test2TenantResolver ), result[0].GetType() );
    }
}