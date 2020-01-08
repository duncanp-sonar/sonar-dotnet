﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

// <auto-generated />
// This code is not auto-generated but is a copy-paste from https://github.com/DotNetAnalyzers/StyleCopAnalyzers for which
// we want to ignore all issues.

namespace SonarAnalyzer.ShimLayer.CSharp
{
    using System;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static class BaseMethodDeclarationSyntaxExtensions
    {
        private static readonly Func<BaseMethodDeclarationSyntax, ArrowExpressionClauseSyntax> ExpressionBodyAccessor;

        static BaseMethodDeclarationSyntaxExtensions()
        {
            ExpressionBodyAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<BaseMethodDeclarationSyntax, ArrowExpressionClauseSyntax>(typeof(BaseMethodDeclarationSyntax), nameof(ExpressionBody));
        }

        public static ArrowExpressionClauseSyntax ExpressionBody(this BaseMethodDeclarationSyntax syntax)
        {
            if (!LightupHelpers.SupportsCSharp7)
            {
                // Prior to C# 7, the ExpressionBody properties did not override a base method.
                switch (syntax.Kind())
                {
                case SyntaxKind.MethodDeclaration:
                    return ((MethodDeclarationSyntax)syntax).ExpressionBody;

                case SyntaxKind.OperatorDeclaration:
                    return ((OperatorDeclarationSyntax)syntax).ExpressionBody;

                case SyntaxKind.ConversionOperatorDeclaration:
                    return ((ConversionOperatorDeclarationSyntax)syntax).ExpressionBody;

                default:
                    break;
                }
            }

            return ExpressionBodyAccessor(syntax);
        }
    }
}