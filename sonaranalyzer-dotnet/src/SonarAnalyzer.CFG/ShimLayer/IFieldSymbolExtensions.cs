﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace SonarAnalyzer.ShimLayer.CSharp
{
    using System;
    using Microsoft.CodeAnalysis;

    public static class IFieldSymbolExtensions
    {
        private static readonly Func<IFieldSymbol, IFieldSymbol> CorrespondingTupleFieldAccessor;

        static IFieldSymbolExtensions()
        {
            CorrespondingTupleFieldAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<IFieldSymbol, IFieldSymbol>(typeof(IFieldSymbol), nameof(CorrespondingTupleField));
        }

        public static IFieldSymbol CorrespondingTupleField(this IFieldSymbol symbol)
        {
            return CorrespondingTupleFieldAccessor(symbol);
        }
    }
}
