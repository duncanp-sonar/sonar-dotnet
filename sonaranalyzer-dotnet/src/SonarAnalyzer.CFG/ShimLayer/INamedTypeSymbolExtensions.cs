﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace SonarAnalyzer.ShimLayer.CSharp
{
    using System;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;

    public static class INamedTypeSymbolExtensions
    {
        private static readonly Func<INamedTypeSymbol, INamedTypeSymbol> TupleUnderlyingTypeAccessor;
        private static readonly Func<INamedTypeSymbol, ImmutableArray<IFieldSymbol>> TupleElementsAccessor;
        private static readonly Func<INamedTypeSymbol, bool> IsSerializableAccessor;

        static INamedTypeSymbolExtensions()
        {
            TupleUnderlyingTypeAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<INamedTypeSymbol, INamedTypeSymbol>(typeof(INamedTypeSymbol), nameof(TupleUnderlyingType));
            TupleElementsAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<INamedTypeSymbol, ImmutableArray<IFieldSymbol>>(typeof(INamedTypeSymbol), nameof(TupleElements));
            IsSerializableAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<INamedTypeSymbol, bool>(typeof(INamedTypeSymbol), nameof(IsSerializable));
        }

        public static INamedTypeSymbol TupleUnderlyingType(this INamedTypeSymbol symbol)
        {
            return TupleUnderlyingTypeAccessor(symbol);
        }

        public static ImmutableArray<IFieldSymbol> TupleElements(this INamedTypeSymbol symbol)
        {
            return TupleElementsAccessor(symbol);
        }

        public static bool IsSerializable(this INamedTypeSymbol symbol)
        {
            return IsSerializableAccessor(symbol);
        }
    }
}
