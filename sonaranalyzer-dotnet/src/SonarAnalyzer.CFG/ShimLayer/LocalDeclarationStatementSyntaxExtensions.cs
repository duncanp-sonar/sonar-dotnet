﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace SonarAnalyzer.ShimLayer.CSharp
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class LocalDeclarationStatementSyntaxExtensions
    {
        private static readonly Func<LocalDeclarationStatementSyntax, SyntaxToken> AwaitKeywordAccessor;
        private static readonly Func<LocalDeclarationStatementSyntax, SyntaxToken> UsingKeywordAccessor;

        private static readonly Func<LocalDeclarationStatementSyntax, SyntaxToken, LocalDeclarationStatementSyntax> WithAwaitKeywordAccessor;
        private static readonly Func<LocalDeclarationStatementSyntax, SyntaxToken, LocalDeclarationStatementSyntax> WithUsingKeywordAccessor;

        static LocalDeclarationStatementSyntaxExtensions()
        {
            AwaitKeywordAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<LocalDeclarationStatementSyntax, SyntaxToken>(typeof(LocalDeclarationStatementSyntax), nameof(AwaitKeyword));
            UsingKeywordAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<LocalDeclarationStatementSyntax, SyntaxToken>(typeof(LocalDeclarationStatementSyntax), nameof(UsingKeyword));

            WithAwaitKeywordAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<LocalDeclarationStatementSyntax, SyntaxToken>(typeof(LocalDeclarationStatementSyntax), nameof(AwaitKeyword));
            WithUsingKeywordAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<LocalDeclarationStatementSyntax, SyntaxToken>(typeof(LocalDeclarationStatementSyntax), nameof(UsingKeyword));
        }

        public static SyntaxToken AwaitKeyword(this LocalDeclarationStatementSyntax syntax)
        {
            return AwaitKeywordAccessor(syntax);
        }

        public static SyntaxToken UsingKeyword(this LocalDeclarationStatementSyntax syntax)
        {
            return UsingKeywordAccessor(syntax);
        }

        public static LocalDeclarationStatementSyntax WithAwaitKeyword(this LocalDeclarationStatementSyntax syntax, SyntaxToken awaitKeyword)
        {
            return WithAwaitKeywordAccessor(syntax, awaitKeyword);
        }

        public static LocalDeclarationStatementSyntax WithUsingKeyword(this LocalDeclarationStatementSyntax syntax, SyntaxToken usingKeyword)
        {
            return WithUsingKeywordAccessor(syntax, usingKeyword);
        }
    }
}
