﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace SonarAnalyzer.ShimLayer.CSharp
{
    using System;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class ConstructorDeclarationSyntaxExtensions
    {
        private static readonly Func<ConstructorDeclarationSyntax, ArrowExpressionClauseSyntax, ConstructorDeclarationSyntax> WithExpressionBodyAccessor;

        static ConstructorDeclarationSyntaxExtensions()
        {
            WithExpressionBodyAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<ConstructorDeclarationSyntax, ArrowExpressionClauseSyntax>(typeof(ConstructorDeclarationSyntax), nameof(BaseMethodDeclarationSyntaxExtensions.ExpressionBody));
        }

        public static ConstructorDeclarationSyntax WithExpressionBody(this ConstructorDeclarationSyntax syntax, ArrowExpressionClauseSyntax expressionBody)
        {
            return WithExpressionBodyAccessor(syntax, expressionBody);
        }
    }
}
